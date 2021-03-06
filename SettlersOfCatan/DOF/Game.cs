﻿using System.Collections.Generic;
using System.Linq;

namespace SettlersOfCatan.DOF
{
    public class Game
    {
        private readonly Player[] _players;
        private List<Move> _moves = new List<Move>();

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
            _moves.Add(new Draw
            (
                player: player,
                resources: resources
            ));
        }

        public void Trade(Player playerA, Resources resourcesA, Player playerB, Resources resourcesB)
        {
            playerA.Hand.RequireAtLeast(resourcesA);
            playerB.Hand.RequireAtLeast(resourcesB);

            _moves.Add(new Trade
            (
                playerA: playerA,
                resourcesA: resourcesA,
                playerB: playerB,
                resourcesB: resourcesB
            ));
        }

        public IEnumerable<Move> Moves => _moves;

        internal Resources DrawsFor(Player player)
        {
            return _moves
                .OfType<Draw>()
                .Where(d => d.Player == player)
                .Select(d => d.Resources)
                .Sum();
        }

        internal Resources TradesTo(Player player)
        {
            var tradesA = _moves
                .OfType<Trade>()
                .Where(t => t.PlayerA == player)
                .Select(t => t.ResourcesB);
            var tradesB = _moves
                .OfType<Trade>()
                .Where(t => t.PlayerB == player)
                .Select(t => t.ResourcesA);
            return tradesA.Union(tradesB)
                .Sum();
        }

        public Resources TradesFrom(Player player)
        {
            var tradesA = _moves
                .OfType<Trade>()
                .Where(t => t.PlayerA == player)
                .Select(t => t.ResourcesA);
            var tradesB = _moves
                .OfType<Trade>()
                .Where(t => t.PlayerB == player)
                .Select(t => t.ResourcesB);
            return tradesA.Union(tradesB)
                .Sum();
        }
    }
}
