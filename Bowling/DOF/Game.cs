using System.Linq;

namespace Bowling.DOF
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
            _firstExtra = 0;
            _secondExtra = 0;
        }

        public GameProgress Roll(int pins, GameProgress current)
        {
            if (current.Frame < 10)
            {
                current.Roll = _frames[current.Frame].Roll(pins, current.Roll);
                if (!_frames[current.Frame].IsStrike || current.Roll == 2)
                    return current;
            }
            else if (current.Frame == 10)
            {
                _firstExtra = pins;
            }
            else if (current.Frame == 11)
            {
                _secondExtra = pins;
            }
            return new GameProgress { Frame = current.Frame + 1, Roll = 0 };
        }

        public int Score
        {
            get { return _frames.Sum(f => f.Score); }
        }

        internal int NextOne(int index)
        {
            if (index < 9)
                return _frames[index + 1].OneRoll;

            return _firstExtra;
        }

        internal int NextTwo(int index)
        {
            if (index < 9)
                return _frames[index + 1].TwoRolls;

            return _firstExtra + _secondExtra;
        }
    }
}
