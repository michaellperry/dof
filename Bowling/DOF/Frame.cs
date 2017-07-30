using System;
using UpdateControls.Fields;

namespace Bowling.DOF
{
    public class Frame
    {
        private readonly Game _game;
        private readonly int _index;

        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }

        public Frame(Game game, int index)
        {
            _game = game;
            _index = index;
        }

        public int Score =>
            IsStrike
                ? 10 + _game.NextTwo(_index) :
            IsSpare
                ? 10 + _game.NextOne(_index) :
            FirstRoll + SecondRoll;

        public int OneRoll => FirstRoll;

        public int TwoRolls =>
            IsStrike
                ? 10 + _game.NextOne(_index)
                : FirstRoll + SecondRoll;

        private bool IsStrike => FirstRoll == 10;
        private bool IsSpare => FirstRoll + SecondRoll == 10;
    }
}
