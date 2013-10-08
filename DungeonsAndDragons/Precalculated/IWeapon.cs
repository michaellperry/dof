
namespace DungeonsAndDragons.Precalculated
{
    public interface IWeapon
    {
        bool IsMelee { get; }
        int AttackBonus { get; }
        int RacialAttackBonus(Race race);
    }
}
