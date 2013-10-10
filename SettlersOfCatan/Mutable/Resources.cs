using System;

namespace SettlersOfCatan.Mutable
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

        public void Add(Resources other)
        {
            Wood += other.Wood;
            Brick += other.Brick;
            Wool += other.Wool;
            Ore += other.Ore;
            Wheat += other.Wheat;
        }

        public void Subtract(Resources other)
        {
            Wood -= other.Wood;
            Brick -= other.Brick;
            Wool -= other.Wool;
            Ore -= other.Ore;
            Wheat -= other.Wheat;
        }

        private static ArgumentException RequiredResourceException(string resource)
        {
            return new ArgumentException(String.Format(
                "The player doesn't have enough {0}.", resource));
        }
    }
}
