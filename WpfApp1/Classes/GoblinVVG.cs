using System;

namespace ISIP423_Marinin.Classes
{
    class GoblinVVG : Goblin
    {
        public GoblinVVG(double attackMult = 1.5, double hpMult = 2, double armorMult = 1.2, int chanceMult = 5) : base()
        {
            name = "GoblinVVG";
            hp = Convert.ToInt32(Math.Round(hpMult * hp));
            armor = Convert.ToInt32(Math.Round(armorMult * armor));
            damage = Convert.ToInt32(Math.Round(attackMult * damage));
        }
    }
}