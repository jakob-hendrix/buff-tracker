using BuffTracker.App.Services;

namespace BuffTracker.Tests.Services
{
    [TestFixture]
    public class BuffTrackerStateTests
    {
        private BuffTrackerState _state;

        [SetUp]
        public void SetUp()
        {
            _state = new();
        }

        [Test]
        public void ChangingCurrentRound_SetsCurrentRound()
        {
            _state.CurrentRound = 1;
            Assert.That(_state.CurrentRound, Is.EqualTo(1));
        }
    }
}
