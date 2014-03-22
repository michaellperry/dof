using System.Linq;

namespace Bowling.Algorithmic
{
    public class Game
    {
        private readonly Frame[] _frames;
        private int _firstExtra;
        private int _secondExtra;

        public Game()
        {
            _frames = Enumerable
                .Range(0, 10)
                .Select(i => new Frame(this, i))
                .ToArray();
        }

        public Frame Frame(int index)
        {
            return _frames[index];
        }

        public int FirstExtra
        {
            get { return _firstExtra; }
            set
            {
                _firstExtra = value;
                ScoreBonusFirstRoll(value, 10);
            }
        }

        public int SecondExtra
        {
            get { return _secondExtra; }
            set
            {
                _secondExtra = value;
                ScoreBonusSecondRoll(value, 10);
            }
        }

        public int Score
        {
            get { return _frames.Sum(f => f.Score); }
        }

        internal void ScoreBonusFirstRoll(int value, int index)
        {
            if (index > 0)
            {
                _frames[index - 1].Bonus(value);
                if (index > 1 && _frames[index - 1].FirstRoll == 10)
                {
                    _frames[index - 2].BonusStrike(value);
                }
            }
        }

        internal void ScoreBonusSecondRoll(int value, int index)
        {
            if (index > 0)
            {
                _frames[index - 1].BonusStrike(value);
            }
        }
    }
}
