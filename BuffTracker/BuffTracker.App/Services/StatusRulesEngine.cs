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

        public int CalculateRemainingRounds(StatusEffect effect)
        {
            int remainingRounds = 0;
            if (effect.RoundWhenCast <= _appState.CurrentRound)
            {
                remainingRounds = effect.RoundWhenCast + effect.MaxDurationInRounds - _appState.CurrentRound;
            }
            return remainingRounds;
        }
    }
}
