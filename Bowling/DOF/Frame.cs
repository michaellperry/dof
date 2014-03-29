using System;
using UpdateControls.Fields;

namespace Bowling.DOF
{
    public class Frame
    {
        private readonly Game _game;
        private readonly int _index;

        private Independent<int> _firstRoll = new Independent<int>();
        private Independent<int> _secondRoll = new Independent<int>();

        public Frame(Game game, int index)
        {
            _game = game;
            _index = index;
        }

        public int FirstRoll
        {
            get { return _firstRoll; }
            set { _firstRoll.Value = value; }
        }

        public int SecondRoll
        {
            get { return _secondRoll; }
            set { _secondRoll.Value = value; }
        }

        public int Score
        {
            get
            {
                if (FirstRoll == 10)
                    return 10 + _game.NextTwo(_index);

                if (FirstRoll + SecondRoll == 10)
                    return 10 + _game.NextOne(_index);

                return FirstRoll + SecondRoll;
            }
        }

        public int OneRoll
        {
            get { return FirstRoll; }
        }

        public int TwoRolls
        {
            get
            {
                if (FirstRoll == 10)
                    return 10 + _game.NextOne(_index);

                return FirstRoll + SecondRoll;
            }
        }
    }
}
