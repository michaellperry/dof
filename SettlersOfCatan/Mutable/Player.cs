
namespace SettlersOfCatan.Mutable
{
    public class Player
    {
        public Resources Hand { get; private set; }

        public Player()
        {
            Hand = new Resources();
        }

        public void Trade(Player other, Resources give, Resources take)
        {
            Hand.RequireAtLeast(give);
            other.Hand.RequireAtLeast(take);

            Hand.Subtract(give);
            other.Hand.Add(give);
            Hand.Add(take);
            other.Hand.Subtract(take);
        }
    }
}
