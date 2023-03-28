using BuffTracker.Shared.Models;

namespace BuffTracker.ViewModels
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

        public string DisplayDuration => ShowDisplayDuration();

        public string ShowDisplayDuration()
        {
            if (StatusEffect.UnitRatio is null || StatusEffect.UnitRatio == 0)
                return "";

            return $"{StatusEffect.UnitRatio.Value} {DurationUnitMethods.DurationUnitToString(StatusEffect.UnitRatio.Value, StatusEffect.DurationUnit)}/level";
        }
    }
}
