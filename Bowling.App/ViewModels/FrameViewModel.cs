using Bowling.DOF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.App.ViewModels
{
    public class FrameViewModel
    {
        private readonly Game _game;
        private readonly Frame _frame;
        
        public FrameViewModel(Game game, Frame frame)
        {
            _game = game;
            _frame = frame;            
        }

        public int FirstRoll
        {
            get { return _frame.FirstRoll; }
            set { _frame.FirstRoll = value; }
        }

        public int SecondRoll
        {
            get
            {
                if (IsLastFrame && _frame.FirstRoll == 10)
                    return _game.FirstExtra;
                else
                    return _frame.SecondRoll;
            }
            set
            {
                if (IsLastFrame && _frame.FirstRoll == 10)
                    _game.FirstExtra = value;
                else
                    _frame.SecondRoll = value;
            }
        }

        public int ThirdRoll
        {
            get
            {
                if (IsLastFrame)
                {
                    if (_frame.FirstRoll == 10)
                        return _game.SecondExtra;
                    else
                        return _game.FirstExtra;
                }
                else
                    return 0;
            }
            set
            {
                if (IsLastFrame)
                {
                    if (_frame.FirstRoll == 10)
                        _game.SecondExtra = value;
                    else
                        _game.FirstExtra = value;
                }
            }
        }

        public bool IsLastFrame
        {
            get { return _game.Frames.Last() == _frame; }
        }

        public int CumulativeScore
        {
            get
            {
                int priorScore = _game.Frames
                    .TakeWhile(f => f != _frame)
                    .Sum(f => f.Score);
                return priorScore + _frame.Score;
            }
        }
    }
}
