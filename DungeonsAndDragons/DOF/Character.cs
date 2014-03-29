
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

        public int GetCurrentAttack(Race race)
        {
            if (CurrentWeapon.IsMelee)
                return BaseMeleeAttack + CurrentWeapon.RacialAttackBonus(race);
            else
                return BaseRangedAttack + CurrentWeapon.RacialAttackBonus(race);
        }

        public void Equip(IWeapon weapon)
        {
            CurrentWeapon = weapon;
        }

        public bool Attack(Creature creature, int roll)
        {
            return GetCurrentAttack(creature.Race) + roll >= creature.ArmorClass;
        }
    }
}
