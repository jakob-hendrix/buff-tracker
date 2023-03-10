namespace BuffTracker.App.Models
{
    public class StatusEffectViewModel
    {
        public StatusEffectViewModel(StatusEffect statusEffect)
        {
            StatusEffect = statusEffect;
            IsBeingEdited = false;
        }

        public StatusEffect StatusEffect { get; }
        public bool IsBeingEdited {  get; set; }
    }
}
