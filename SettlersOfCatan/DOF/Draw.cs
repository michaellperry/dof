using System;

namespace SettlersOfCatan.DOF
{
    public class Draw : Move
    {
        public Player Player { get; }
        public Resources Resources { get; }

        public Draw(Player player, Resources resources)
        {
            Player = player;
            Resources = resources;
        }
    }
}
