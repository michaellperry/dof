using System.Collections.Generic;
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

        public IEnumerable<Frame> Frames => _frames;

        public int FirstExtra
        {
            get => _firstExtra;
            set
            {
                _firstExtra = value;
                ScoreBonusForFirstRoll(value, 10);
            }
        }

        public int SecondExtra
        {
            get => _secondExtra;
            set
            {
                _secondExtra = value;
                ScoreBonusForSecondRoll(value, 10);
            }
        }

        public int Score => _frames.Sum(f => f.Score);

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
