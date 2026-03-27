using System;
using System.Windows.Data;

namespace ISIP423_Marinin.Classes
{
    class Enemy
    {
        public string img = "..\\Images\\dead-skeleton.gif";
        public string name { get; set; }
        public int hp { get; set; }
        public int damage { get; set; }
        public int armor { get; set; }
        public EnemyType enemyType { get; set; }
        public int chanceMult;
        public Enemy(EnemyType et, string n, double attackMult = 1, double hpMult = 1, double armorMult = 1, int chanceMult = 10)
        {
            enemyType = et; 
            name = n;
        }
        public virtual bool Attack(ref Player p, bool defending)
        {
            Random rand = new Random();
            int chance = RandomGame.Chance(chanceMult);
            int dodge = RandomGame.Chance(10);
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
        public virtual void TakeDamage(double damage)
        {
            hp -= Convert.ToInt32(Math.Round(damage));
            if (hp < 0) hp = 0;
        }

        public virtual void TakeDamage(int damage)
        {
            hp -= damage;
            if (hp < 0) hp = 0;
        }
    }

    enum EnemyType
    {
        Goblin,
        Mage,
        Skeleton,
        Slime
    }
}