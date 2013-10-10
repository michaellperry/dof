using System.Collections.Generic;
using System.Linq;

namespace SettlersOfCatan.DOF
{
    public class Game
    {
        private readonly Player[] _players;
        private List<Draw> _draws = new List<Draw>();
        private List<Trade> _trades = new List<Trade>();

        public Game(int playerCount)
        {
            _players = Enumerable
                .Range(0, playerCount)
                .Select(i => new Player(this))
                .ToArray();
        }

        public Player GetPlayer(int index)
        {
            return _players[index];
        }

        public void Draw(Player player, Resources resources)
        {
            _draws.Add(new Draw
            {
                Player = player,
                Resources = resources
            });
        }

        public void Trade(Player playerA, Resources resourcesA, Player playerB, Resources resourcesB)
        {
            playerA.Hand.RequireAtLeast(resourcesA);
            playerB.Hand.RequireAtLeast(resourcesB);

            _trades.Add(new Trade
            {
                PlayerA = playerA,
                ResourcesA = resourcesA,
                PlayerB = playerB,
                ResourcesB = resourcesB
            });
        }

        internal Resources DrawsFor(Player player)
        {
            return _draws
                .Where(d => d.Player == player)
                .Select(d => d.Resources)
                .Sum();
        }

        internal Resources TradesTo(Player player)
        {
            var tradesA = _trades
                .Where(t => t.PlayerA == player)
                .Select(t => t.ResourcesB);
            var tradesB = _trades
                .Where(t => t.PlayerB == player)
                .Select(t => t.ResourcesA);
            return tradesA.Union(tradesB)
                .Sum();
        }

        public Resources TradesFrom(Player player)
        {
            var tradesA = _trades
                .Where(t => t.PlayerA == player)
                .Select(t => t.ResourcesA);
            var tradesB = _trades
                .Where(t => t.PlayerB == player)
                .Select(t => t.ResourcesB);
            return tradesA.Union(tradesB)
                .Sum();
        }
    }
}
