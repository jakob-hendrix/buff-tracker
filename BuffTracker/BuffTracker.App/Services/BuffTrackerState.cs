using Blazored.LocalStorage;
using BuffTracker.App.Models;
using BuffTracker.App.ViewModels;

namespace BuffTracker.App.Services;

public class BuffTrackerState : NotifyPropertyChangedBase
{
    private readonly ILogger<BuffTrackerState> _logger;
    private readonly ILocalStorageService _localStorage;
    private int _currentRound;
    private List<StatusEffectViewModel> _statusEffectViewModels;

    public BuffTrackerState(ILogger<BuffTrackerState> logger,ILocalStorageService localStorage)
    {
        _logger = logger;
        _localStorage = localStorage;

        _localStorage.Changed += (sender, e) =>
        {
            _logger.LogDebug($"Value for key {e.Key} changed from {e.OldValue} to {e.NewValue}");
            Console.WriteLine($"Value for key {e.Key} changed from {e.OldValue} to {e.NewValue}");
        };

        _statusEffectViewModels = new List<StatusEffectViewModel>();
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

    public async Task LoadState()
    {
        try
        {
            var savedEffects = await _localStorage.GetItemAsync<List<StatusEffectViewModel>>(nameof(StatusEffects));
            if (savedEffects is null || savedEffects.Count == 0)
            {
                SeedStatusEffects();
            }
        }
        catch (Exception)
        {
            _logger.LogError($"Error reading {nameof(StatusEffects)} from local storage");
            SeedStatusEffects();
        }
    }
    
    public void SaveState()
    {
        _localStorage.SetItemAsync(nameof(CurrentRound), CurrentRound);
        _localStorage.SetItemAsync(nameof(StatusEffects), StatusEffects);
    }

    public async Task ClearState()
    {
        // clear browser storage
        await _localStorage.ClearAsync();
    }

    private void SeedStatusEffects()
    {
        var statusSeeds = new List<StatusEffect>
        {
            new StatusEffect { Name = "Haste", RoundWhenCast = 1, URL = @"https://www.aonprd.com/SpellDisplay.aspx?ItemName=Haste", SpellLevel = 3, CasterLevel = 3, DurationUnit = DurationUnit.Rounds, UnitRatio = 1 },
            new StatusEffect { Name = "Staggered", MaxDurationInRoundsOverride = 1, RoundWhenCast = 2 }
        };

        StatusEffects = new();

        foreach (var statusEffect in statusSeeds)
        {
            StatusEffects.Add(new StatusEffectViewModel(statusEffect));
        }

        CurrentRound = 0;
    }
}
