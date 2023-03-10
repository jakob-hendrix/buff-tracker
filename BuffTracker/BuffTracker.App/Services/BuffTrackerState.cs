using BuffTracker.App.Models;

namespace BuffTracker.App.Services;

public class BuffTrackerState
{
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
    }

    public int CurrentRound { get; set; } = 0;
    public List<StatusEffectViewModel> StatusEffects { get; set; }
}
