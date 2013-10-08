using System.Linq;

namespace Bowling.DOF
{
    public class Game
    {
        private readonly Frame[] _frames;
        private int _firstExtra;
        private int _secondExtra;

        private int _currentFrame;

        public Game()
        {
            _frames = Enumerable
                .Range(0, 10)
                .Select(i => new Frame(this, i))
                .ToArray();
            _firstExtra = 0;
            _secondExtra = 0;

            _currentFrame = 0;
        }

        public void Roll(int pins)
        {
            if (_currentFrame < 10)
            {
                _frames[_currentFrame].Roll(pins);
                if (_frames[_currentFrame].IsClosed)
                    _currentFrame++;
            }
            else if (_currentFrame == 10)
            {
                _firstExtra = pins;
                _currentFrame++;
            }
            else if (_currentFrame == 11)
            {
                _secondExtra = pins;
                _currentFrame++;
            }
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
