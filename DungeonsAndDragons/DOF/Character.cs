
namespace DungeonsAndDragons.DOF
{
    public class Character
    {
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public IWeapon CurrentWeapon { get; set; }

        public int StrengthModifier
        {
            get { return Strength / 2 - 5; }
        }

        public int DexterityModifier
        {
            get { return Dexterity / 2 - 5; }
        }

        public int BaseMeleeAttack
        {
            get { return Level / 2 + StrengthModifier; }
        }

        public int BaseRangedAttack
        {
            get { return Level / 2 + DexterityModifier; }
        }

        public int GetCurrentAttack(Creature creature)
        {
            if (CurrentWeapon.IsMelee)
                return BaseMeleeAttack + CurrentWeapon.RacialAttackBonus(creature.Race);
            else
                return BaseRangedAttack + CurrentWeapon.RacialAttackBonus(creature.Race);
        }

        public void Equip(IWeapon weapon)
        {
            CurrentWeapon = weapon;
        }

        public bool Attack(Creature creature, int roll)
        {
            return GetCurrentAttack(creature) + roll >= creature.ArmorClass;
        }
    }
}
