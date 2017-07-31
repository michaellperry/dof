using System;

namespace SettlersOfCatan.DOF
{
    public class Resources
    {
        public int Wood { get; }
        public int Brick { get; }
        public int Wool { get; }
        public int Ore { get; }
        public int Wheat { get; }

        public Resources(int wood = 0, int brick = 0, int wool = 0, int ore = 0, int wheat = 0)
        {
            Wood = wood;
            Brick = brick;
            Wool = wool;
            Ore = ore;
            Wheat = wheat;
        }

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
            (
                wood: this.Wood + r2.Wood,
                brick: this.Brick + r2.Brick,
                wool: this.Wool + r2.Wool,
                ore: this.Ore + r2.Ore,
                wheat: this.Wheat + r2.Wheat
            );
        }

        public Resources Minus(Resources r2)
        {
            return new Resources
            (
                wood: this.Wood - r2.Wood,
                brick: this.Brick - r2.Brick,
                wool: this.Wool - r2.Wool,
                ore: this.Ore - r2.Ore,
                wheat: this.Wheat - r2.Wheat
            );
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