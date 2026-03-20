using System;

namespace ISIP423_Marinin.Classes
{
    class Archimage : Mage
    {
        public Archimage(double attackMult = 1.6, double hpMult = 1.8, double armorMult = 1.1, int chanceMult = 5) : base()
        {
            name = "Archimage C++";
            hp = Convert.ToInt32(Math.Round(hpMult * hp));
            armor = Convert.ToInt32(Math.Round(armorMult * armor));
            damage = Convert.ToInt32(Math.Round(attackMult * damage));
        }
    }
}