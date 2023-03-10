using BuffTracker.App.Services;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace BuffTracker.Tests.Services;

[TestFixture]
public class TimelineEngineTests
{
    private BuffTrackerState _state;
    private TimelineEngine _timelineEngine;
    
    [SetUp]
    public void SetUp()
    {
        _state = new();
        _timelineEngine = new TimelineEngine(_state);
    }

    [Test]
    public void IncrementRound_AddsOne() 
    {
        // Arrange
        _state.CurrentRound = 0;

        // Act
        _timelineEngine.IncrementRound();
        
        // Assert
        Assert.IsTrue( _state.CurrentRound == 1 );
    }

    [Test]
    public void DecrementRound_SubtractsOne()
    {
        // Arrange
        _state.CurrentRound = 1;

        // Act
        _timelineEngine.DecrementRound();

        // Assert
        Assert.IsTrue(_state.CurrentRound == 0);
    }

    [Test]
    public void DecrementRound_BelowZeroFloorsToZero()
    {
        // Arrange
        _state.CurrentRound = 0;

        // Act
        _timelineEngine.DecrementRound();

        // Assert
        Assert.IsTrue(_state.CurrentRound == 0);
    }

}
