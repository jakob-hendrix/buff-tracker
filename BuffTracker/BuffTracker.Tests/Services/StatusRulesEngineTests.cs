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
    public void IncrementRound_DurationRunsOut()
    {
        _state.CurrentRound = 1;
        var effect = new StatusEffect { RoundWhenCast = 1, MaxDurationInRounds = 1 };

        _timelineEngine.IncrementRound();
        var remainingRounds = _statusRulesEngine.CalculateRemainingRounds(effect);

        Assert.That(remainingRounds == 0);
    }

    [Test]
    public void CastRoundAfterCurrentRound_DurationIsZero()
    {
        _state.CurrentRound = 1;
        var effect = new StatusEffect { RoundWhenCast = 2, MaxDurationInRounds = 1 };

        var remainingRounds = _statusRulesEngine.CalculateRemainingRounds(effect);

        Assert.That(effect.RoundWhenCast > _state.CurrentRound);
        Assert.That(remainingRounds == 0);
    }
}
