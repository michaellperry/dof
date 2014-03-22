using Bowling.DOF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateControls.XAML;

namespace Bowling.App.ViewModels
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        private Game _game = new Game();

        public ViewModelLocator()
        {
            if (DesignMode)
            {
                for (int index = 0; index < 10; index++)
                {
                    _game.Frames.ElementAt(index).FirstRoll = index;
                    _game.Frames.ElementAt(index).SecondRoll = 9 - index;
                }
            }
        }

        public object Game
        {
            get
            {
                return ViewModel(() => new GameViewModel(_game));
            }
        }
    }
}
