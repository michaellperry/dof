using System.Collections.Generic;
using System.Linq;
using UpdateControls.Fields;

namespace Bowling.DOF
{
    public class Game
    {
        private readonly Frame[] _frames;

        public Game()
        {
            _frames = Enumerable
                .Range(0, 10)
                .Select(i => new Frame(this, i))
                .ToArray();
        }

        public IEnumerable<Frame> Frames => _frames;

        public int FirstExtra { get; set; }
        public int SecondExtra { get; set; }

        public int Score => _frames.Sum(f => f.Score);

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
