using Bowling.Algorithmic;
using FluentAssertions;
using Xunit;

namespace Bowling
{
    public class BowlingGameTests
    {
        private Scorer scorer;

        public BowlingGameTests()
        {
            scorer = new Scorer();
        }

        private void RollManyBallsWithSameNumberOfPins(int numberOfBalls, int pins)
        {
            for (var i = 0; i < numberOfBalls; i++)
                scorer.Roll(pins);
        }

        [Fact]
        public void CalculateScore_AllBallsAreGutterBalls_0()
        {
            RollManyBallsWithSameNumberOfPins(20, 0);
            var score = scorer.CalculateScore();
            score.Should().Be(0);
        }

        [Fact]
        public void CalculateScore_AllBallsKnockDownOnePin_20()
        {
            RollManyBallsWithSameNumberOfPins(20, 1);
            var score = scorer.CalculateScore();
            score.Should().Be(20);
        }

        [Fact]
        public void CalculateScore_FirstFrameIsStrikeRestOnes_30()
        {
            scorer.Roll(10);
            RollManyBallsWithSameNumberOfPins(18, 1);
            var score = scorer.CalculateScore();
            score.Should().Be(30);
        }

        [Fact]
        public void CalculateScore_AllFramesAreStrikes_300()
        {
            RollManyBallsWithSameNumberOfPins(12, 10);
            var score = scorer.CalculateScore();
            score.Should().Be(300);
        }

        [Fact]
        public void CalculateScore_FirstFrameIsSpareRestOnes_29()
        {
            RollManyBallsWithSameNumberOfPins(2, 5);
            RollManyBallsWithSameNumberOfPins(18, 1);
            var score = scorer.CalculateScore();
            score.Should().Be(29);
        }

        [Fact]
        public void CalculateScore_AllFramesAreSpares_150()
        {
            RollManyBallsWithSameNumberOfPins(21, 5);
            var score = scorer.CalculateScore();
            score.Should().Be(150);
        }
     }
}
