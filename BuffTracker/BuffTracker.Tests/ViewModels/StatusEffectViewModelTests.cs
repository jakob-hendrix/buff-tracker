using BuffTracker.App;
using BuffTracker.Shared.Models;
using BuffTracker.ViewModels;

namespace BuffTracker.Tests.ViewModels;

[TestFixture]
public class StatusEffectViewModelTests
{
    //private AppState _state;
    //private StatusEffectViewModel _viewModel;
    //private StatusEffect _effect;

    //[SetUp]
    //public void SetUp()
    //{
    //    _state = new();
    //    _effect = new();
    //    _viewModel = new StatusEffectViewModel(_effect);
    //}

    //[Test]
    //public void DurationOfOneRoundPerLevel_DisplaysCorrectly()
    //{
    //    _viewModel.StatusEffect.DurationUnit = DurationUnit.Rounds;
    //    _viewModel.StatusEffect.UnitRatio = 1;

    //    string duration = _viewModel.DisplayDuration();
    //    Assert.That(duration,Is.EqualTo("1 round/level"));
    //}

    //[Test]
    //public void DurationOfTwoRoundsPerLevel_DisplaysCorrectly()
    //{
    //    _viewModel.StatusEffect.DurationUnit = DurationUnit.Rounds;
    //    _viewModel.StatusEffect.UnitRatio = 2;

    //    string actual = _viewModel.DisplayDuration();
    //    string expected = "2 rounds/level";

    //    Assert.That(actual,Is.EqualTo(expected)); 
    //}

    //[Test]
    //public void DurationOf3HoursPerLevel_DisplaysCorrectly()
    //{
    //    _viewModel.StatusEffect.DurationUnit = DurationUnit.Hours;
    //    _viewModel.StatusEffect.UnitRatio = 3;

    //    string actual = _viewModel.DisplayDuration();
    //    string expected = "3 hours/level";

    //    Assert.That(actual, Is.EqualTo(expected));
    //}
}