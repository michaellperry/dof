using System;
using UpdateControls.Fields;

namespace Bowling.DOF
{
    public class Frame
    {
        private readonly Game _game;
        private readonly int _index;

        private int _firstRoll;
        private int _secondRoll;

        public Frame(Game game, int index)
        {
            _game = game;
            _index = index;
        }

        public int FirstRoll
        {
            get { return _firstRoll; }
            set { _firstRoll = value; }
        }

        public int SecondRoll
        {
            get { return _secondRoll; }
            set { _secondRoll = value; }
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
