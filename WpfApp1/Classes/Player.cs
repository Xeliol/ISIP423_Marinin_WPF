using System;

namespace ISIP423_Marinin.Classes
{
    class Player
    {
        public int hp { get; private set; }
        public int armor { get; set; }
        public string armor_name { get; set; }
        public int weapon { get; set; }
        public string weapon_name { get; set; }

        public Player(int h = 100, int a = 10, string a_n = "Clothes", int w = 20, string w_n = "Fists")
        {
            hp = h;
            armor = a;
            armor_name = a_n;
            weapon = w;
            weapon_name = w_n;
        }

        public void TakeDamage(double damage)
        {
            hp -= Convert.ToInt32(Math.Round(damage));
            if (hp < 0) hp = 0;
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
            if (hp < 0) hp = 0;
        }

        public void Heal()
        {
            hp = 100;
        }
    }
}