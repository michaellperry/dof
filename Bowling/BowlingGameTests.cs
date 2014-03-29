using Bowling.Algorithmic;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace Bowling
{
    public class BowlingGameTests
    {
        private Game game = new Game();

        private void RollOneFrame(int firstRoll, int secondRoll, int frameIndex = 0)
        {
            Frame frame = game.Frames.ElementAt(frameIndex);
            frame.FirstRoll = firstRoll;
            frame.SecondRoll = secondRoll;
        }

        private void RollManyFrames(int firstRoll, int secondRoll, int startingIndex = 0)
        {
            for (var frameIndex = startingIndex; frameIndex < 10; frameIndex++)
            {
                RollOneFrame(firstRoll, secondRoll, frameIndex);
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

        //[Fact]
        //public void EditFrame_AllBallsKnockDownOnePin_OneMorePin_21()
        //{
        //    RollManyFrames(1, 1);
        //    game.Frames.ElementAt(2).FirstRoll = 2;
        //
        //    game.Score.Should().Be(21);
        //}

        //[Fact]
        //public void EditFrame_MakeFirstFrameASpareRestOnes_29()
        //{
        //    RollManyFrames(1, 1);
        //    game.Frames.ElementAt(0).FirstRoll = 5;
        //    game.Frames.ElementAt(0).SecondRoll = 5;
        //
        //    game.Score.Should().Be(29);
        //}
    }
}
