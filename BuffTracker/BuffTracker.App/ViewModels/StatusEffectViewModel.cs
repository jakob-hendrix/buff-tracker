using BuffTracker.App.Models;
using System.Runtime.CompilerServices;

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

            return $"{DurationUnitToString(StatusEffect.UnitRatio.Value, StatusEffect.DurationUnit.Value)}";
        }

        private string DurationUnitToString(int amount, DurationUnit unit)
        {
            if (unit == DurationUnit.Permanent)
                return "permanent";

            string unitDescription = "";
            switch (unit)
            {
                case DurationUnit.Days:
                    unitDescription = "day";
                    break;
                case DurationUnit.Hours:
                    unitDescription = "hour";
                    break;
                case DurationUnit.Minutes:
                    unitDescription = "minute";
                    break;
                case DurationUnit.Rounds:
                    unitDescription = "round";
                    break;
            }
            if (amount > 1)
                unitDescription += "s";

            return $"{amount} {unitDescription}/level";
        }
    }
}
