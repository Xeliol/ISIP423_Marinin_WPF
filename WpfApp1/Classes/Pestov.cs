using System;

namespace ISIP423_Marinin.Classes
{
    class Pestov : Mage
    {
        public Pestov(double attackMult = 1.8, double hpMult = 1.3, double armorMult = 0.6, int chanceMult = 4) : base()
        {
            img = "..\\Images\\glitterypopcorn-wizard.gif";
            name = "Pestov C--";
            hp = Convert.ToInt32(Math.Round(hpMult * hp));
            armor = Convert.ToInt32(Math.Round(armorMult * armor));
            damage = Convert.ToInt32(Math.Round(attackMult * damage));
        }
    }
}