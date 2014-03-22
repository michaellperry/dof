using System;

namespace Bowling.Algorithmic
{
    public class Frame
    {
        private readonly Game _game;
        private readonly int _index;

        private int _firstRoll;
        private int _secondRoll;
        private int _score;

        public Frame(Game game, int index)
        {
            _game = game;
            _index = index;
        }

        public int FirstRoll
        {
            get { return _firstRoll; }
            set
            {
                _firstRoll = value;
                _score += value;
                _game.ScoreBonusFirstRoll(value, _index);
            }
        }

        public int SecondRoll
        {
            get { return _secondRoll; }
            set
            {
                _secondRoll = value;
                _score += value;
                _game.ScoreBonusSecondRoll(value, _index);
            }
        }

        public int Score
        {
            get { return _score; }
        }

        internal void Bonus(int roll)
        {
            if (_firstRoll + _secondRoll == 10)
            {
                _score += roll;
            }
        }

        public void BonusStrike(int roll)
        {
            if (_firstRoll == 10)
            {
                _score += roll;
            }
        }
    }
}
