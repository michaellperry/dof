
namespace DungeonsAndDragons.Precalculated
{
    public class Character
    {
        private int _strength;
        private int _dexterity;

        public int Level { get; set; }

        public int Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                int strengthModifier = _strength / 2 - 5;
                BaseMeleeAttack = Level / 2 + strengthModifier;
            }
        }

        public int Dexterity
        {
            get { return _dexterity; }
            set
            {
                _dexterity = value;
                int dexModifier = _dexterity / 2 - 5;
                BaseRangedAttack = Level / 2 + dexModifier;
            }
        }

        public int BaseMeleeAttack { get; private set; }
        public int BaseRangedAttack { get; private set; }
        public int CurrentAttack { get; private set; }

        public void Equip(IWeapon weapon)
        {
            if (weapon.IsMelee)
                CurrentAttack = BaseMeleeAttack + weapon.AttackBonus;
            else
                CurrentAttack = BaseRangedAttack + weapon.AttackBonus;
        }

        public bool Attack(Creature creature, int roll)
        {
            return CurrentAttack + roll >= creature.ArmorClass;
        }
    }
}
