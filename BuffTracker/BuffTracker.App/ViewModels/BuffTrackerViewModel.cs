using BuffTracker.App.Services;

namespace BuffTracker.App.ViewModels
{
    public class BuffTrackerViewModel
    {
        public BuffTrackerViewModel(BuffTrackerState appState, TimelineEngine timelineEngine, StatusRulesEngine statusRulesEngine)
        {
            AppState = appState;
            TimelineEngine = timelineEngine;
            StatusRulesEngine = statusRulesEngine;  
        }

        public BuffTrackerState AppState { get; }
        public TimelineEngine TimelineEngine { get; }
        public StatusRulesEngine StatusRulesEngine { get; }
    }
}
