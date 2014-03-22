using Bowling.DOF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.App.ViewModels
{
    public class GameViewModel
    {
        private readonly Game _game;

        public GameViewModel(Game game)
        {
            _game = game;
        }

        public IEnumerable<FrameViewModel> Frames
        {
            get
            {
                return
                    from frame in _game.Frames
                    select new FrameViewModel(_game, frame);
            }
        }

        public int FirstExtra
        {
            get { return _game.FirstExtra; }
            set { _game.FirstExtra = value; }
        }

        public int SecondExtra
        {
            get { return _game.SecondExtra; }
            set { _game.SecondExtra = value; }
        }
    }
}
