using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndDragons.DOF
{
    public class ElvenSword : Sword
    {
        public ElvenSword(int attackBonus)
            : base(attackBonus)
        {
        }

        public int RacialAttackBonus(Race race)
        {
            if (race == Race.Orc)
                return 1;
            else
                return 0;
        }
    }
}
