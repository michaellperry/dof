
namespace SettlersOfCatan.DOF
{
    public class Player
    {
        private readonly Game _game;

        public Player(Game game)
        {
            _game = game;
        }

        public Resources Hand
        {
            get
            {
                return
                    _game.DrawsFor(this) +
                    _game.TradesTo(this) -
                    _game.TradesFrom(this);
            }
        }
    }
}
