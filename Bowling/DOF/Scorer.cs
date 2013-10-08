using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.DOF
{
    public class Scorer
    {
        private Game game = new Game();

        public void Roll(int pins)
        {
            game.Roll(pins);
        }

        public int CalculateScore()
        {
            return game.Score;
        }
    }
}
