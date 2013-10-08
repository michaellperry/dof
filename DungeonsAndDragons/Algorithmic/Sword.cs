
namespace DungeonsAndDragons.Algorithmic
{
    public class Sword : IWeapon
    {
        private readonly int _attackBonus;

        public Sword(int attackBonus)
        {
            _attackBonus = attackBonus;
        }

        public bool IsMelee
        {
            get { return true; }
        }

        public int AttackBonus
        {
            get { return _attackBonus; }
        }

        public int RacialAttackBonus(Race race)
        {
            return 0;
        }
    }
}
