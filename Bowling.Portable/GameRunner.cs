using Bowling.DOF;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Bowling
{
    public static class GameRunner
    {
        public static int Bowl(int[] rolls)
        {
            if (rolls == null)
                return 0;
            if (rolls.Any(r => r < 0))
                return 0;
            if (rolls.Any(r => r > 10))
                return 0;

            var game = new Game();

            int index = 0;
            foreach (var frame in game.Frames)
            {
                if (index == rolls.Length)
                    break;
                int roll1 = rolls[index++];
                frame.FirstRoll = roll1;

                if (roll1 == 10)
                    continue;

                if (index == rolls.Length)
                    break;
                int roll2 = rolls[index++];
                if (roll2 > 10 - roll1)
                    roll2 = 10 - roll1;
                frame.SecondRoll = roll2;
            }

            if (index < rolls.Length)
                game.FirstExtra = rolls[index++];

            if (index < rolls.Length)
                game.SecondExtra = rolls[index++];

            Contract.Assert(game.Score < 300);

            return game.Score;
        }
    }
}
