namespace BuffTracker.Shared.Models;

public enum DurationUnit
{
    Rounds,
    Minutes,
    Hours,
    Days,
    Permanent
}

public static class DurationUnitMethods
{
    public static string DurationUnitToString(int amount, DurationUnit unit)
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

        return unitDescription;
    }
}
