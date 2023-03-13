using Blazored.LocalStorage;
using BuffTracker.App.Models;
using BuffTracker.App.ViewModels;

namespace BuffTracker.App.Services;

public class BuffTrackerState : NotifyPropertyChangedBase
{
    private readonly ILocalStorageService _localStorage;
    private int _currentRound;
    private List<StatusEffectViewModel> _statusEffectViewModels;

    public BuffTrackerState(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;

        LoadState();

        if (StatusEffects is null)
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
        }

        CurrentRound = 0;
    }

    public int CurrentRound
    {
        get => _currentRound;
        set
        {
            SetProperty(ref _currentRound, value);
            SaveState();
        }
    }

    public List<StatusEffectViewModel> StatusEffects
    {
        get => _statusEffectViewModels;
        set
        {
            SetProperty(ref _statusEffectViewModels, value);
            SaveState();
        }
    }

    //https://github.com/Blazored/LocalStorage/blob/main/samples/BlazorWebAssembly/Pages/Index.razor

    private void LoadState()
    {
        // look in local storage for previous state
    }

    public void SaveState()
    {
        // save the current state to local storage
    }

    public void ClearState()
    {
        // clear browser storage
    }

}
