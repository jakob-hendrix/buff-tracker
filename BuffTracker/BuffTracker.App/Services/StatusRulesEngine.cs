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

            // expired?
            if (remainingRounds < 0)
            {
                return $"expired {remainingRounds * -1} {DurationUnitMethods.DurationUnitToString(remainingRounds * -1, DurationUnit.Rounds)} ago";
            }
            else if (remainingRounds == 0)
            {
                return "not yet taken effect";
            }
                

            return $"{remainingRounds}";
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
                return 0;
            if (effect.DurationUnit is null)
                return 0;
            if (effect.UnitRatio is null)
                return 0;

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
