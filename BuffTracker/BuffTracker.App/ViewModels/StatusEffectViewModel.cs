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

        public string DisplayDuration()
        {
            if (StatusEffect.DurationUnit is null)
                return "";

            if (StatusEffect.UnitRatio is null || StatusEffect.UnitRatio == 0)
                return "";

            return $"{StatusEffect.UnitRatio.Value} {DurationUnitMethods.DurationUnitToString(StatusEffect.UnitRatio.Value, StatusEffect.DurationUnit.Value)}/level";
        }
    }
}
