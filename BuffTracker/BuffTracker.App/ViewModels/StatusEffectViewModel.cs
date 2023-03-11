using BuffTracker.App.Models;

namespace BuffTracker.App.ViewModels
{
    public class StatusEffectViewModel
    {
        public StatusEffectViewModel(StatusEffect statusEffect)
        {
            StatusEffect = statusEffect;
            IsBeingEdited = false;
        }

        public StatusEffect StatusEffect { get; }
        public bool IsBeingEdited { get; set; }
    }
}
