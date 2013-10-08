
namespace DungeonsAndDragons.Algorithmic
{
    public interface IWeapon
    {
        bool IsMelee { get; }
        int AttackBonus { get; }
        int RacialAttackBonus(Race race);
    }
}
