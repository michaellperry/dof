using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndDragons.Precalculated
{
    public class ElvenSword : Sword
    {
        public ElvenSword(int attackBonus)
            : base(attackBonus)
        {
        }

        public override int RacialAttackBonus(Race race)
        {
            if (race == Race.Orc)
                return AttackBonus + 1;
            else
                return AttackBonus;
        }
    }
}
