
namespace DungeonsAndDragons.Precalculated
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

        public virtual int RacialAttackBonus(Race race)
        {
            return _attackBonus;
        }
    }
}
