
namespace SettlersOfCatan.DOF
{
    public class Trade : Move
    {
        public Player PlayerA { get; set; }
        public Resources ResourcesA { get; set; }
        public Player PlayerB { get; set; }
        public Resources ResourcesB { get; set; }
    }
}
