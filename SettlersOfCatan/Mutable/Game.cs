using System.Linq;

namespace SettlersOfCatan.Mutable
{
    public class Game
    {
        private readonly Player[] _players;

        public Game(int playerCount)
        {
            _players = Enumerable
                .Range(0, playerCount)
                .Select(i => new Player())
                .ToArray();
        }

        public Player GetPlayer(int index)
        {
            return _players[index];
        }

        public void Draw(Player player, Resources resources)
        {
            player.Hand.Add(resources);
        }
        
        public void Trade(Player one, Resources give, Player two, Resources take)
        {
            one.Trade(two, give, take);
        }
    }
}
