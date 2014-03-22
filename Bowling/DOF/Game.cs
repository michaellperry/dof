using System.Collections.Generic;
using System.Linq;
using UpdateControls.Fields;

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
        }

        public IEnumerable<Frame> Frames
        {
            get { return _frames; }
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

            return FirstExtra;
        }

        internal int NextTwo(int index)
        {
            if (index < 9)
                return _frames[index + 1].TwoRolls;

            return FirstExtra + SecondExtra;
        }
    }
}
