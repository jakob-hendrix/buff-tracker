using BuffTracker.App.Models;
using BuffTracker.App.Services;

namespace BuffTracker.Tests.Services;

[TestFixture]
public class StatusRulesEngineTests
{
    private BuffTrackerState _state;
    private StatusRulesEngine _statusRulesEngine;
    private TimelineEngine _timelineEngine;

    [SetUp]
    public void SetUp()
    {
        _state = new();
        _statusRulesEngine = new StatusRulesEngine(_state);
        _timelineEngine = new TimelineEngine(_state);
    }

    [Test]
    public void IncrementRound_OverrideDurationRunsOut()
    {
        _state.CurrentRound = 1;
        var effect = new StatusEffect { RoundWhenCast = 1, MaxDurationInRoundsOverride = 1 };

        _timelineEngine.IncrementRound();
        var remainingRounds = _statusRulesEngine.CalculateRemainingRounds(effect);

        Assert.That(remainingRounds == 0);
    }

    [Test]
    public void CastRoundAfterCurrentRound_OverrideDurationIsZero()
    {
        _state.CurrentRound = 1;
        var effect = new StatusEffect { RoundWhenCast = 2, MaxDurationInRoundsOverride = 1 };

        var remainingRounds = _statusRulesEngine.CalculateRemainingRounds(effect);

        Assert.That(effect.RoundWhenCast > _state.CurrentRound);
        Assert.That(remainingRounds,Is.EqualTo(0));
    }

    [Test]
    public void JustCastEffectDuration_OneRound()
    {
        _state.CurrentRound = 1;
        var effect = new StatusEffect { RoundWhenCast = 1, DurationUnit = DurationUnit.Rounds, UnitRatio = 1, CasterLevel = 1 };

        var remainingRounds = _statusRulesEngine.CalculateRemainingRounds(effect);

        Assert.That(remainingRounds, Is.EqualTo(1));
    }

    [Test]
    public void JustCastEffectDuration_OneMinute()
    {
        _state.CurrentRound = 1;
        var effect = new StatusEffect { RoundWhenCast = 1, DurationUnit = DurationUnit.Minutes, UnitRatio = 1, CasterLevel = 1 };

        var remainingRounds = _statusRulesEngine.CalculateRemainingRounds(effect);

        Assert.That(remainingRounds, Is.EqualTo(10));
    }

    [Test]
    public void JustCastEffectDuration_OneHour()
    {
        _state.CurrentRound = 1;
        var effect = new StatusEffect { RoundWhenCast = 1, DurationUnit = DurationUnit.Hours, UnitRatio = 1 , CasterLevel = 1 };

        var remainingRounds = _statusRulesEngine.CalculateRemainingRounds(effect);

        Assert.That(remainingRounds, Is.EqualTo(600));
    }

    [Test]
    public void JustCastEffectDuration_OneDay()
    {
        _state.CurrentRound = 1;
        var effect = new StatusEffect { RoundWhenCast = 1, DurationUnit = DurationUnit.Days, UnitRatio = 1 , CasterLevel = 1 };

        var remainingRounds = _statusRulesEngine.CalculateRemainingRounds(effect);

        Assert.That(remainingRounds, Is.EqualTo(14400));
    }

    [Test]
    public void JustCastEffectDuration_Permanent()
    {
        _state.CurrentRound = 1;
        var effect = new StatusEffect { RoundWhenCast = 1, DurationUnit = DurationUnit.Permanent };

        var remainingRounds = _statusRulesEngine.CalculateRemainingRounds(effect);

        Assert.That(remainingRounds, Is.EqualTo(0));
    }
    
    [Test]
    public void FutureBuff_DisplaysCorrectly()
    {
        _state.CurrentRound = 1;
        var effect = new StatusEffect { RoundWhenCast = 2, DurationUnit = DurationUnit.Rounds, UnitRatio = 1 };
        var displayedDuration = _statusRulesEngine.DisplayRemainingRounds(effect);

        Assert.That(effect.RoundWhenCast, Is.GreaterThan(_state.CurrentRound));
        Assert.That(displayedDuration, Is.EqualTo("not yet taken effect"));
    }

    [Test]
    public void ExpiringBuff_DisplaysCorrectly()
    {
        _state.CurrentRound = 2;
        var effect = new StatusEffect { RoundWhenCast = 1, CasterLevel = 1, DurationUnit = DurationUnit.Rounds, UnitRatio = 1 };

        var remainingRounds = _statusRulesEngine.CalculateRemainingRounds(effect);
        var displayedDuration = _statusRulesEngine.DisplayRemainingRounds(effect);

        Assert.That(remainingRounds,Is.EqualTo(0));
        Assert.That(displayedDuration, Is.EqualTo("expired at the start of your turn"));
    }

}
