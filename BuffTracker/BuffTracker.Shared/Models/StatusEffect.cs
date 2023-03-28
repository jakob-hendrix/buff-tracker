namespace BuffTracker.Shared.Models;

public class StatusEffect : NotifyPropertyChangedBase
{
    private string name;
    private string? effectSource;
    private string? effectDescription;
    private int? casterLevel;
    private int? spellLevel;
    private string? notes;
    private string? url;
    private DurationUnit durationUnit = DurationUnit.Rounds;
    private int? unitRatio;
    private bool isActive;
    private bool isDebuff;
    private int? maxDurationInRoundsOverride;
    private int roundWhenCast;

    public string Name
    {
        get => name;
        set => Set(ref name, value);
    }

    public string? EffectSource
    {
        get => effectSource;
        set => Set(ref effectSource, value);
    }

    public string? EffectDescription
    {
        get => effectDescription;
        set => Set(ref effectDescription, value);
    }

    public int? CasterLevel
    {
        get => casterLevel;
        set => Set(ref casterLevel, value);
    }

    public int? SpellLevel
    {
        get => spellLevel;
        set => Set(ref spellLevel, value);
    }

    public string? Notes
    {
        get => notes;
        set => Set(ref notes, value);
    }

    public string? URL
    {
        get => url;
        set => Set(ref url, value);
    }

    //public string DurationDescription { get; set; }
    public DurationUnit DurationUnit
    {
        get => durationUnit;
        set => Set(ref durationUnit, value);
    }

    public int? UnitRatio
    {
        get => unitRatio;
        set => Set(ref unitRatio, value);
    }

    public bool IsActive
    {
        get => isActive;
        set => Set(ref isActive, value);
    }

    public bool IsDebuff
    {
        get => isDebuff;
        set => Set(ref isDebuff, value);
    }

    public int? MaxDurationInRoundsOverride
    {
        get => maxDurationInRoundsOverride;
        set => Set(ref maxDurationInRoundsOverride, value);
    }

    public int RoundWhenCast
    {
        get => roundWhenCast;
        set => Set(ref roundWhenCast, value);
    }
}
