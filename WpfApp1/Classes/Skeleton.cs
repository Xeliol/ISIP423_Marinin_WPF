using System;

namespace ISIP423_Marinin.Classes
{
    class Skeleton : Enemy
    {
        public Skeleton() : base(EnemyType.Skeleton, "Skeleton")
        {
            img = "..\\Images\\skeleton-banging-shield.gif";
            hp = Convert.ToInt32(40);
            armor = Convert.ToInt32(15);
            damage = Convert.ToInt32(15);
        }
    }
}