using System;
using FluentAssertions;
using SettlersOfCatan.Mutable;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace SettlersOfCatan
{
    public class CardTradingTests
    {
        private Game _game = new Game(4);

        [Fact]
        public void HandInitiallyEmpty()
        {
            Player player = _game.GetPlayer(0);

            player.Hand.Wood.Should().Be(0);
            player.Hand.Brick.Should().Be(0);
            player.Hand.Wool.Should().Be(0);
            player.Hand.Ore.Should().Be(0);
            player.Hand.Wheat.Should().Be(0);
        }

        [Fact]
        public void Trade()
        {
            Player one = _game.GetPlayer(0);
            Player two = _game.GetPlayer(1);

            _game.Draw(one, new Resources
            {
                Wood = 2,
                Brick = 1
            });
            _game.Draw(two, new Resources
            {
                Wool = 1,
                Wheat = 1
            });

            _game.Trade(
                one, new Resources { Wood = 1 },
                two, new Resources { Wheat = 1 });

            one.Hand.Wood.Should().Be(1);
            two.Hand.Wood.Should().Be(1);
            one.Hand.Wheat.Should().Be(1);
            two.Hand.Wheat.Should().Be(0);
        }

        [Fact]
        public void YouCantTradeWhatYouDontHave()
        {
            Player one = _game.GetPlayer(0);
            Player two = _game.GetPlayer(1);

            _game.Draw(one, new Resources
            {
                Wood = 1
            });
            _game.Draw(two, new Resources
            {
                Wheat = 2
            });

            Action trade = () => _game.Trade(
                one, new Resources { Wood = 2 },
                two, new Resources { Wheat = 2 });

            trade.ShouldThrow<ArgumentException>(
                "The player does not have enough Wood.");
        }

        //[Fact]
        //public void CanSeeAHistoryOfMoves()
        //{
        //    Player one = _game.GetPlayer(0);
        //    Player two = _game.GetPlayer(1);
        //
        //    _game.Draw(one, new Resources
        //    {
        //        Wood = 2,
        //        Brick = 1
        //    });
        //    _game.Draw(two, new Resources
        //    {
        //        Wool = 1,
        //        Wheat = 1
        //    });
        //
        //    _game.Trade(
        //        one, new Resources { Wood = 1 },
        //        two, new Resources { Wheat = 1 });
        //
        //    Move[] moves = _game.Moves.ToArray();
        //    moves.Length.Should().Be(3);
        //    moves[0].Should().BeOfType<Draw>();
        //    moves[1].Should().BeOfType<Draw>();
        //    moves[2].Should().BeOfType<Trade>();
        //}
    }
}
