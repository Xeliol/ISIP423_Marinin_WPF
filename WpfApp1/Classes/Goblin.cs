using System;

namespace ISIP423_Marinin.Classes
{
    class Goblin : Enemy
    {
        public Goblin() : base(EnemyType.Goblin, "Goblin")
        {
            img = "..\\Images\\goblin-dont-fear-goblin-reaper.gif";
            hp = Convert.ToInt32(30);
            armor = Convert.ToInt32(10);
            damage = Convert.ToInt32(10);
        }

        public override bool Attack(ref Player p, bool defending)
        {
            Random rand = new Random();
            int chance = RandomGame.Chance(chanceMult);
            int dodge = RandomGame.Chance(10);

            double crit = 1;
            if (chance == 1)
            {
                crit = 1.7;
            }
            if (!defending) p.TakeDamage(damage * crit);
            else if (dodge > 3 && defending)
            {
                if (enemyType == EnemyType.Skeleton) p.TakeDamage(damage);
                else
                {
                    double hurt = Math.Max(0, (damage - p.armor * (Convert.ToDouble(RandomGame.NextNum(7, 11)) / 10)) * crit);
                    p.TakeDamage(hurt);
                }
            }
            return false;
        }
    }
}