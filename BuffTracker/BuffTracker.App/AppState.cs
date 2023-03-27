using System.Collections.ObjectModel;
using Blazored.LocalStorage;
using BuffTracker.Shared;
using BuffTracker.Shared.Models;
using BuffTracker.ViewModels;

namespace BuffTracker.App;

public class AppState : NotifyStateChangedBase
{
    private readonly ILogger<AppState> logger;
    private readonly ILocalStorageService localStorage;
    private int currentRound;
    private ObservableCollection<StatusEffectViewModel> statusEffectViewModels;
    private bool isLoading;

    public AppState(ILogger<AppState> logger,ILocalStorageService localStorage)
    {
        isLoading = true;
        currentRound = 0;
        statusEffectViewModels = new();

        this.logger = logger;
        this.localStorage = localStorage;

        this.localStorage.Changed += (sender, e) =>
        {
            this.logger.LogDebug($"Value for key {e.Key} changed from {e.OldValue} to {e.NewValue}");
            Console.WriteLine($"Value for key {e.Key} changed from {e.OldValue} to {e.NewValue}");
        };
    }

    public bool IsLoading
    {
        get => isLoading;
        set
        {
            SetProperty(ref isLoading, value);
            SaveState();
        }
    }

    public int CurrentRound
    {
        get => currentRound;
        set
        {
            SetProperty(ref currentRound, value);
            SaveState();
        }
    }

    public ObservableCollection<StatusEffectViewModel> StatusEffects
    {
        get => statusEffectViewModels;
        set
        {
            SetProperty(ref statusEffectViewModels, value);
            SaveState();
        }
    }

    //https://github.com/Blazored/LocalStorage/blob/main/samples/BlazorWebAssembly/Pages/Index.razor

    public async Task LoadState()
    {
        try
        {
            // todo: get list of status effects, not the view model
            CurrentRound = await localStorage.GetItemAsync<int>(nameof(CurrentRound));
            statusEffectViewModels = await localStorage.GetItemAsync<ObservableCollection<StatusEffectViewModel>>(nameof(StatusEffects));
            if (statusEffectViewModels is null || statusEffectViewModels.Count == 0)
            {
                SeedStatusEffects();
            }
            else
            {
                
            }
        }
        catch (Exception)
        {
            logger.LogError($"Error reading {nameof(StatusEffects)} from local storage");
            SeedStatusEffects();
        }

        IsLoading = false;
    }
    
    public void SaveState()
    {
        // TODO: serialize our items to JSON
        localStorage.SetItemAsync(nameof(CurrentRound), CurrentRound);
        localStorage.SetItemAsync(nameof(StatusEffects), StatusEffects);
    }

    public async Task ClearState()
    {
        // clear browser storage
        await localStorage.ClearAsync();
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
    }
}
