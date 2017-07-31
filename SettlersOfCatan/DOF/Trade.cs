
namespace SettlersOfCatan.DOF
{
    public class Trade : Move
    {
        public Player PlayerA { get; }
        public Resources ResourcesA { get; }
        public Player PlayerB { get; }
        public Resources ResourcesB { get; }

        public Trade(Player playerA, Resources resourcesA, Player playerB, Resources resourcesB)
        {
            PlayerA = playerA;
            ResourcesA = resourcesA;
            PlayerB = playerB;
            ResourcesB = resourcesB;
        }
    }
}
