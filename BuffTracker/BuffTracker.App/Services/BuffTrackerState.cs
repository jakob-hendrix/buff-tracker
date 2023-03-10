using BuffTracker.App.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BuffTracker.App.Services;

public class BuffTrackerState : INotifyPropertyChanged
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
        set
        {
            _currentRound = value;
            OnPropertyChanged(nameof(CurrentRound));
        } 
    } 
    public List<StatusEffectViewModel> StatusEffects { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
