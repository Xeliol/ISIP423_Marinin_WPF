using System;

namespace ISIP423_Marinin.Classes
{
    class Slime : Enemy
    {
        public Slime() : base(EnemyType.Slime, "Slime")
        {
            img = "..\\Images\\monster-bob.gif";
            hp = Convert.ToInt32(30);
            armor = Convert.ToInt32(10);
            damage = Convert.ToInt32(10);
        }

        public override void TakeDamage(int damage)
        {
            hp -= damage - 2;
            if (hp < 0) hp = 0;
        }

        public override void TakeDamage(double damage)
        {
            hp -= Convert.ToInt32(Math.Round(damage)) - 2;
            if (hp < 0) hp = 0;
        }
    }
}