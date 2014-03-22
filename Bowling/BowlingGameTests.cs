using Bowling.DOF;
using FluentAssertions;
using Xunit;

namespace Bowling
{
    public class BowlingGameTests
    {
        private Game game = new Game();

        private void RollOneFrame(int firstRoll, int secondRoll, int startingIndex = 0)
        {
            game.Frame(startingIndex).FirstRoll = firstRoll;
            game.Frame(startingIndex).SecondRoll = secondRoll;
        }

        private void RollManyFrames(int firstRoll, int secondRoll, int startingIndex = 0)
        {
            for (var frameIndex = startingIndex; frameIndex < 10; frameIndex++)
            {
                Frame frame = game.Frame(frameIndex);
                frame.FirstRoll = firstRoll;
                frame.SecondRoll = secondRoll;
            }
        }

        [Fact]
        public void CalculateScore_AllBallsAreGutterBalls_0()
        {
            RollManyFrames(0, 0);
            
            game.Score.Should().Be(0);
        }

        [Fact]
        public void CalculateScore_AllBallsKnockDownOnePin_20()
        {
            RollManyFrames(1, 1);
            
            game.Score.Should().Be(20);
        }

        [Fact]
        public void CalculateScore_FirstFrameIsStrikeRestOnes_30()
        {
            RollOneFrame(10, 0);
            RollManyFrames(1, 1, 1);
            
            game.Score.Should().Be(30);
        }

        [Fact]
        public void CalculateScore_AllFramesAreStrikes_300()
        {
            RollManyFrames(10, 0);
            game.FirstExtra = 10;
            game.SecondExtra = 10;
            
            game.Score.Should().Be(300);
        }

        [Fact]
        public void CalculateScore_FirstFrameIsSpareRestOnes_29()
        {
            RollOneFrame(5, 5);
            RollManyFrames(1, 1, 1);
            
            game.Score.Should().Be(29);
        }

        [Fact]
        public void CalculateScore_AllFramesAreSpares_150()
        {
            RollManyFrames(5, 5);
            game.FirstExtra = 5;
            
            game.Score.Should().Be(150);
        }
    }
}
