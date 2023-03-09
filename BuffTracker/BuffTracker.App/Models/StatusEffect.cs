namespace BuffTracker.App.Models
{
    public class StatusEffect
    {
        public string Name { get; set; }
        public int MaxDurationInRounds { get; set; }
        public int RoundWhenCast { get; set; }
        public int RemainingRounds { get; }
    }
}
