using DungeonsAndDragons.Algorithmic;
using FluentAssertions;
using Xunit;

namespace DungeonsAndDragons
{
    public class GameTests
    {
        private Character _character;
        private Creature _creature;

        public GameTests()
        {
            _character = new Character();
            _creature = new Creature() { ArmorClass = 14 };

            _character.Level = 1;
            _character.Dexterity = 10;
            _character.Strength = 12;
            _character.Equip(new Sword(1));
        }

        [Fact]
        public void MeleeAttack_Miss()
        {
            int roll = 12;
            bool hit = _character.Attack(_creature, roll);

            hit.Should().Be(false);
        }

        [Fact]
        public void MeleeAttack_Hit()
        {
            int roll = 13;
            bool hit = _character.Attack(_creature, roll);

            hit.Should().Be(true);
        }
    }
}
