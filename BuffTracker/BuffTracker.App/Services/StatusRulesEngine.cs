using BuffTracker.App.Models;

namespace BuffTracker.App.Services
{
    public class StatusRulesEngine
    {
        private readonly BuffTrackerState _appState;

        public StatusRulesEngine(BuffTrackerState appState)
        {
            _appState = appState;
        }

        public string DisplayRemainingRounds(StatusEffect effect)
        {
            if (effect.DurationUnit == DurationUnit.Permanent)
            {
                return "endless";
            }

            if (effect.MaxDurationInRoundsOverride is null && (effect.CasterLevel is null || effect.DurationUnit is null || effect.UnitRatio is null))
            {
                return "Unable to calculate";
            }

            int remainingRounds = CalculateRemainingRounds(effect);

            if (_appState.CurrentRound < effect.RoundWhenCast)
                return "not yet taken effect";

            // expired?
            if (remainingRounds < 0)
            {
                return $"expired {remainingRounds * -1} {DurationUnitMethods.DurationUnitToString(remainingRounds * -1, DurationUnit.Rounds)} ago";
            }
            else if (remainingRounds == 0)
            {
                return "expired at the start of your turn";
            }


            string timeLeft = RoundsToTime(remainingRounds);
            return $"{remainingRounds} ({timeLeft})";
        }

        public string RoundsToTime(int rounds)
        {
            double counter = rounds;

            if (rounds < 0)
                throw new ArgumentOutOfRangeException(nameof(rounds));

            // break down the rounds: 1 r = 6s = 1/10m = 1/600h = 1/14400d
            var days = Math.Floor(counter / 14400);
            counter -= days * 14400;

            var hours = Math.Floor(counter / 600);
            counter -= hours * 600;

            var minutes = Math.Floor(counter / 10);
            counter -= minutes * 10;

            var seconds = counter * 6;

            // TODO: string builder?
            string dayDisplay = days > 0 ? $"{days}d " : "";
            string hourDisplay = hours > 0 ? $"{hours}h " : "";
            string minuteDisplay = minutes > 0 ? $"{minutes}m " : "";
            string secondDisplay = seconds > 0 ? $"{seconds}s " : "";
            string timeDisplay = $"{dayDisplay}{hourDisplay}{minuteDisplay}{secondDisplay}";

            return timeDisplay.TrimEnd();
        }

        public int CalculateRemainingRounds(StatusEffect effect)
        {
            int remainingRounds = 0;

            // If an override value is provided, use that
            if (effect.MaxDurationInRoundsOverride is not null && effect.MaxDurationInRoundsOverride > 0)
            {
                if (effect.RoundWhenCast <= _appState.CurrentRound)
                {
                    remainingRounds = effect.RoundWhenCast + effect.MaxDurationInRoundsOverride.Value - _appState.CurrentRound;
                }
                return remainingRounds;
            }

            // Otherwise, calculate the amount from the duration and caster level
            if (effect.CasterLevel is null)
                throw new NullReferenceException($"{nameof(effect.CasterLevel)} is null");
            if (effect.DurationUnit is null)
                throw new NullReferenceException($"{nameof(effect.DurationUnit)} is null");
            if (effect.UnitRatio is null)
                throw new NullReferenceException($"{nameof(effect.UnitRatio)} is null");

            int maxRounds = CalcMaxDuration(effect.CasterLevel.Value, effect.DurationUnit.Value, effect.UnitRatio.Value);

            if (effect.RoundWhenCast <= _appState.CurrentRound)
            {
                remainingRounds = effect.RoundWhenCast + maxRounds - _appState.CurrentRound;
            }
            return remainingRounds;
        }

        private int CalcMaxDuration(int casterLevel, DurationUnit unit, int unitAmount) => casterLevel * unitAmount * RoundsPerDurationUnit(unit);

        private int RoundsPerDurationUnit(DurationUnit unit) => unit switch
        {
            DurationUnit.Rounds => 1,
            DurationUnit.Minutes => 10,
            DurationUnit.Hours => 600,
            DurationUnit.Days => 14400,
            _ => throw new ArgumentException($"A duration unit of {unit} cannot be coverted into rounds")
        };
    }
}
