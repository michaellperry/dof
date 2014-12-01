using System;

namespace Bowling.Algorithmic
{
    public class Frame
    {
        private readonly Game _game;
        private readonly int _index;

        private int _firstRoll;
        private int _secondRoll;

        public int Score { get; private set; }

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
                Score += value;
                _game.ScoreBonusForFirstRoll(value, _index);
            }
        }

        public int SecondRoll
        {
            get { return _secondRoll; }
            set
            {
                _secondRoll = value;
                Score += value;
                _game.ScoreBonusForSecondRoll(value, _index);
            }
        }

        internal void BonusIfClosed(int roll)
        {
            if (_firstRoll + _secondRoll == 10)
            {
                Score += roll;
            }
        }

        public void BonusIfStrike(int roll)
        {
            if (_firstRoll == 10)
            {
                Score += roll;
            }
        }
    }
}
