using System;

namespace ISIP423_Marinin.Classes
{
    class Mage : Enemy
    {
        public Mage() : base(EnemyType.Mage, "Mage")
        {
            img = "..\\Images\\wizard-dance.gif";
            hp = Convert.ToInt32(50);
            armor = Convert.ToInt32(5);
            damage = Convert.ToInt32(20);
        }

        public override bool Attack(ref Player p, bool defending)
        {
            Random rand = new Random();
            int chance = RandomGame.Chance(chanceMult);
            int dodge = RandomGame.Chance(10);
            if (chance == 1)
            {
                return true;
            }
            if (!defending) p.TakeDamage(damage);
            else if (dodge > 3 && defending)
            {
                if (enemyType == EnemyType.Skeleton) p.TakeDamage(damage);
                else
                {
                    double hurt = Math.Max(0, damage - p.armor * (Convert.ToDouble(RandomGame.NextNum(7, 11)) / 10));
                    p.TakeDamage(hurt);
                }
            }
            return false;
        }
    }
}