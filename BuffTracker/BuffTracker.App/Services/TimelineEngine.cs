namespace BuffTracker.App.Services
{
    public class TimelineEngine
    {
        private readonly BuffTrackerState _appState;

        public TimelineEngine(BuffTrackerState appState)
        {
            _appState = appState;
        }

        public void IncrementRound() => _appState.CurrentRound++;

        public void DecrementRound()
        {
            _appState.CurrentRound--;
            if (_appState.CurrentRound < 0)
            {
                _appState.CurrentRound = 0;
            }
        }
    }
}
