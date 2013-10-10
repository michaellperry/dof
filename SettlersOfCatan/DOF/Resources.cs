using System;

namespace SettlersOfCatan.DOF
{
    public class Resources
    {
        public int Wood { get; set; }
        public int Brick { get; set; }
        public int Wool { get; set; }
        public int Ore { get; set; }
        public int Wheat { get; set; }

        public void RequireAtLeast(Resources other)
        {
            if (Wood < other.Wood)
                throw RequiredResourceException("Wood");
            if (Brick < other.Brick)
                throw RequiredResourceException("Brick");
            if (Wool < other.Wool)
                throw RequiredResourceException("Wool");
            if (Ore < other.Ore)
                throw RequiredResourceException("Ore");
            if (Wheat < other.Wheat)
                throw RequiredResourceException("Wheat");
        }

        private static ArgumentException RequiredResourceException(string resource)
        {
            return new ArgumentException(String.Format(
                "The player doesn't have enough {0}.", resource));
        }

        public Resources Plus(Resources r2)
        {
            return new Resources
            {
                Wood = this.Wood + r2.Wood,
                Brick = this.Brick + r2.Brick,
                Wool = this.Wool + r2.Wool,
                Ore = this.Ore + r2.Ore,
                Wheat = this.Wheat + r2.Wheat
            };
        }

        public Resources Minus(Resources r2)
        {
            return new Resources
            {
                Wood = this.Wood - r2.Wood,
                Brick = this.Brick - r2.Brick,
                Wool = this.Wool - r2.Wool,
                Ore = this.Ore - r2.Ore,
                Wheat = this.Wheat - r2.Wheat
            };
        }

        public static Resources operator +(Resources a, Resources b)
        {
            return a.Plus(b);
        }

        public static Resources operator -(Resources a, Resources b)
        {
            return a.Minus(b);
        }
    }
}