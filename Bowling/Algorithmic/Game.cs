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
                ScoreBonusForFirstRoll(value, 10);
            }
        }

        public int SecondExtra
        {
            get { return _secondExtra; }
            set
            {
                _secondExtra = value;
                ScoreBonusForSecondRoll(value, 10);
            }
        }

        public int Score
        {
            get { return _frames.Sum(f => f.Score); }
        }

        internal void ScoreBonusForFirstRoll(int value, int index)
        {
            if (index > 0)
            {
                _frames[index - 1].BonusIfClosed(value);
                if (index > 1 && _frames[index - 1].FirstRoll == 10)
                {
                    _frames[index - 2].BonusIfStrike(value);
                }
            }
        }

        internal void ScoreBonusForSecondRoll(int value, int index)
        {
            if (index > 0)
            {
                _frames[index - 1].BonusIfStrike(value);
            }
        }
    }
}
