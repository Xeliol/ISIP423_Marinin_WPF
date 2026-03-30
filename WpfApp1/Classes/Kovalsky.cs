using System;

namespace ISIP423_Marinin.Classes
{
    class Kovalski : Skeleton
    {
        public Kovalski(double attackMult = 1.3, double hpMult = 2.5, double armorMult = 1.4, int chanceMult = 10) : base()
        {
            img = "..\\Images\\skeleton-pls-skeleton.gif";
            name = "Kovalski";
            hp = Convert.ToInt32(Math.Round(hpMult * hp));
            armor = Convert.ToInt32(Math.Round(armorMult * armor));
            damage = Convert.ToInt32(Math.Round(attackMult * damage));
        }
    }
}