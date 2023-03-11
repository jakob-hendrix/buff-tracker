using BuffTracker.App.Models;
using BuffTracker.App.ViewModels;
using static System.Net.WebRequestMethods;

namespace BuffTracker.App.Services;

public class BuffTrackerState : NotifyPropertyChangedBase
{
    private int _currentRound;

    public BuffTrackerState()
    {
        var statusSeeds = new List<StatusEffect>
        {
            new StatusEffect { Name = "Haste", RoundWhenCast = 1, URL = @"https://www.aonprd.com/SpellDisplay.aspx?ItemName=Haste", SpellLevel = 3, CasterLevel = 3, DurationUnit = DurationUnit.Rounds, UnitRatio = 1},
            new StatusEffect { Name = "Staggered", MaxDurationInRoundsOverride = 1, RoundWhenCast = 2}
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
