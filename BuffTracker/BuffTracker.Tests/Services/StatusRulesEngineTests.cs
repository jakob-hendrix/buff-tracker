using BuffTracker.App.Services;

namespace BuffTracker.Tests.Services;

[TestFixture]
public class StatusRulesEngineTests
{
    private BuffTrackerState _state;
    private StatusRulesEngine _statusRulesEngine;

    [SetUp]
    public void SetUp()
    {
        _state = new();
        _statusRulesEngine = new StatusRulesEngine(_state);
    }

    [Test]
    public void IncrementRound_AddsOne()
    {
        // Arrange

        // Act

        // Assert
    }
}
