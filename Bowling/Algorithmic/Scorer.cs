using System.Collections.Generic;

namespace Bowling.Algorithmic
{
    public class Scorer
    {
        private readonly IList<int> rolls = new List<int>();
        private int currentRoll;
        private int score;

        public int CalculateScore()
        {
            score = 0;
            currentRoll = 0;

            ScoreAllRolls();

            return score;
        }

        private void ScoreAllRolls()
        {
            for (var frame = 0; frame < 10; frame++)
            {
                if (rolls[currentRoll] == 10)
                    ScoreStrike();
                else if (SumUpRollsFromCurrent(2) == 10)
                    ScoreSpare();
                else
                    ScoreNormal();
            }
        }

        private void ScoreNormal()
        {
            score += SumUpRollsFromCurrent(2);
            currentRoll += 2;
        }

        private void ScoreSpare()
        {
            score += SumUpRollsFromCurrent(3);
            currentRoll += 2;
        }

        private void ScoreStrike()
        {
            score += SumUpRollsFromCurrent(3);
            currentRoll++;
        }

        private int SumUpRollsFromCurrent(int numberOfRolls)
        {
            var sum = 0;
            for (var i = 0; i < numberOfRolls; i++)
                sum += rolls[currentRoll + i];
            return sum;
        }

        public void Roll(int pins)
        {
            rolls.Add(pins);
        }
    }
}
