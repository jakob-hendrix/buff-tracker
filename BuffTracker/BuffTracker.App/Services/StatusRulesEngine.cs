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
            return effect.RoundWhenCast + effect.MaxDurationInRounds - _appState.CurrentRound;
        }
    }
}
