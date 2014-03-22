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

        public Frame Frame(int index)
        {
            return _frames[index];
        }

        public int FirstExtra
        {
            get { return _firstExtra; }
            set { _firstExtra = value; }
        }

        public int SecondExtra
        {
            get { return _secondExtra; }
            set { _secondExtra = value; }
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
