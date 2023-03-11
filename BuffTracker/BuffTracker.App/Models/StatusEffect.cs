namespace BuffTracker.App.Models;

public class StatusEffect
{
    public string Name { get; set; }
    public string? EffectSource { get; set; }
    public string? EffectDescription { get; set; }
    public int? CasterLevel { get; set; }
    public int? SpellLevel { get; set; }
    public string? Notes { get; set; }
    public string? URL { get; set; }
    //public string DurationDescription { get; set; }
    public DurationUnit? DurationUnit { get; set; }
    public int? UnitRatio { get; set; }
    public bool IsActive { get; set; }
    public bool IsDebuff { get; set; }
    public int? MaxDurationInRoundsOverride { get; set; }
    public int RoundWhenCast { get; set; }

}
