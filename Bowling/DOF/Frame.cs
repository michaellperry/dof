using System;

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

            _firstRoll = 0;
            _secondRoll = 0;
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

        public bool IsStrike
        {
            get { return _firstRoll == 10; }
        }

        public int Score
        {
            get
            {
                if (_firstRoll == 10)
                    return 10 + _game.NextTwo(_index);

                if (_firstRoll + _secondRoll == 10)
                    return 10 + _game.NextOne(_index);

                return _firstRoll + _secondRoll;
            }
        }

        public int OneRoll
        {
            get { return _firstRoll; }
        }

        public int TwoRolls
        {
            get
            {
                if (_firstRoll == 10)
                    return 10 + _game.NextOne(_index);

                return _firstRoll + _secondRoll;
            }
        }
    }
}
