using BuffTracker.App.Models;
using BuffTracker.App.ViewModels;

namespace BuffTracker.App.Services;

public class BuffTrackerState : NotifyPropertyChangedBase
{
    private int _currentRound;

    public BuffTrackerState()
    {
        var statusSeeds = new List<StatusEffect>
        {
            new StatusEffect { Name = "Haste", MaxDurationInRounds = 5, RoundWhenCast = 1},
            new StatusEffect { Name = "Staggered", MaxDurationInRounds = 1, RoundWhenCast = 2},
        };

        StatusEffects = new();

        foreach (var statusEffect in statusSeeds)
        {
            StatusEffects.Add(new StatusEffectViewModel(statusEffect));
        }

        CurrentRound = 0;
    }

    public int CurrentRound
    {
        get => _currentRound;
        set => SetProperty(ref _currentRound, value);
    } 

    public List<StatusEffectViewModel> StatusEffects { get; set; }
}
