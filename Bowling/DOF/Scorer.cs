
namespace Bowling.DOF
{
    public class Scorer
    {
        private Game game = new Game();

        private GameProgress _currentGameProgress = new GameProgress { Frame = 0, Roll = 0 };

        public void Roll(int pins)
        {
            _currentGameProgress = game.Roll(pins, _currentGameProgress);
        }

        public int CalculateScore()
        {
            return game.Score;
        }
    }
}
