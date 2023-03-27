using BuffTracker.Shared.Services;

namespace BuffTracker.ViewModels;

public class BuffTrackerViewModel
{
    public BuffTrackerViewModel(TimelineViewModel timelineEngine, StatusRulesEngine statusRulesEngine)
    {
        TimelineEngine = timelineEngine;
        StatusRulesEngine = statusRulesEngine;  
    }

    public TimelineViewModel TimelineEngine { get; }
    public StatusRulesEngine StatusRulesEngine { get; }
}