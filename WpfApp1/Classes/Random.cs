using System;

namespace ISIP423_Marinin.Classes
{
    class RandomGame
    {
        private static Random random = new Random();

        public static int NextNum(int min, int max)
        {
            return random.Next(min, max);
        }

        public static int Chance(int chance)
        {
            return random.Next(0, chance);
        }
    }
}