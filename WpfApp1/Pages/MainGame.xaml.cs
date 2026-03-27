using ISIP423_Marinin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainGame.xaml
    /// </summary>
    public partial class MainGame : Page
    {
        public MainGame()
        {
            InitializeComponent();
            ContinueGame();
        }

        Player player = new Player();
        int events;
        bool fighting = false;
        bool frozen = false;
        Enemy enemy = new Enemy(EnemyType.Goblin, "tmp");
        int fight_count = 0;
        ItemType item_t = ItemType.Weapon;
        string item_name = " ";
        int item_int = 0;
        int action = 0;

        private void ContinueGame()
        {
            ArmourText.Text = "Armor: " + player.armor_name + " (" + player.armor + ")";
            WeaponText.Text = "Weapon: " + player.weapon_name + " (" + player.weapon + ")"; 
            HealthBar.Value = player.hp;

            if (player.hp != 0)
            {
                if (!fighting) //CHECK FIGHT
                {
                    events = RandomGame.NextNum(0, 2);
                    if (events == 0)
                    {
                        LogsText.Text += ("\nYou found a chest!");
                        int item = RandomGame.NextNum(1, 4);

                        if (item == 1) // POTION
                        {
                            LogsText.Text += ("\nInside you found a Healing Potion!");
                            player.Heal();
                            LogsText.Text += ("\nYou are now at Full Health");
                            LogsText.Text += ("\nPress OK to continue");
                            OKbutton.Visibility = Visibility.Visible;
                        }

                        if (item == 2) // WEAPON LOOTING
                        {
                            item_t = ItemType.Weapon;
                            LogsText.Text += ("\nInside you found a Weapon!");
                            int weapon_type = RandomGame.NextNum(1, 4);

                            if (weapon_type == 1)
                            {
                                item_name = "Iron Sword";
                                item_int = 30;
                            }
                            if (weapon_type == 2)
                            {
                                item_name = "Golden Bow";
                                item_int = 35;
                            }
                            if (weapon_type == 3)
                            {
                                item_name = "A Literal Gun";
                                item_int = 50;
                            }
                            LogsText.Text += ($"\nYour current weapon: {player.weapon_name}\n Damage:{player.weapon}");
                            LogsText.Text += ($"\nNew weapon: {item_name}\n Damage:{item_int}");
                            LogsText.Text += ($"\nDo you take it?");
                            ItemChoice.Visibility = Visibility.Visible;
                        }

                        if (item == 3) //ARMOR LOOTING
                        {
                            item_t = ItemType.Armor;
                            LogsText.Text += ("\nInside you found Armor!");
                            int armor_type = RandomGame.NextNum(1, 4);

                            if (armor_type == 1)
                            {
                                item_name = "Iron Armor";
                                item_int = 35;
                            }
                            if (armor_type == 2)
                            {
                                item_name = "Leather Armor";
                                item_int = 20;
                            }
                            if (armor_type == 3)
                            {
                                item_name = "S.W.A.T. uniform";
                                item_int = 50;
                            }
                            LogsText.Text += ($"\nYour current armor: {player.armor_name}\n Level:{player.armor}");
                            LogsText.Text += ($"\nNew armor: {item_name}\n Level:{item_int}");
                            LogsText.Text += ($"\nDo you take it?");
                            ItemChoice.Visibility = Visibility.Visible;
                        }
                        fight_count++;
                    }
                    else // SPAWN ENEMY
                    {
                        LogsText.Text += ("\nYou encountered a foe!");
                        int type = RandomGame.NextNum(1, 5);

                        if (fight_count < 10) // REGULAR ENEMY
                        {
                            if (type == 1) enemy = new Goblin();
                            if (type == 2) enemy = new Skeleton();
                            if (type == 3) enemy = new Mage();
                            if (type == 4) enemy = new Slime();
                            LogsText.Text += ($"\nIt's a {enemy.name}!");
                            fighting = true;
                        }
                        else // BOSS
                        {
                            fight_count = 0;
                            type = RandomGame.NextNum(1, 5);
                            LogsText.Text += ("\n---IT'S A BOSS!---");
                            if (type == 1)
                            {
                                enemy = new GoblinVVG();
                            }
                            if (type == 2)
                            {
                                enemy = new Kovalski();
                            }
                            if (type == 3)
                            {
                                enemy = new Archimage();
                            }
                            if (type == 4)
                            {
                                enemy = new Pestov();
                            }
                            fighting = true;
                        }
                        LogsText.Text += ("\nPress OK to continue");
                        EnemyListBox.ItemsSource = new List<Enemy> { enemy, enemy };
                        OKbutton.Visibility = Visibility.Visible;
                        EnemyListBox.Visibility = Visibility.Visible;
                    }
                }
                else if (enemy.hp != 0) //CHECK FIGHT & HP
                {
                    LogsText.Text += ($"\nYour HP: {player.hp}\nYour Armor: {player.armor}\nYour Damage: {player.weapon}");
                    LogsText.Text += ($"\n{enemy.name}'s HP: {enemy.hp}\n{enemy.name}'s Armor: {enemy.armor}\n{enemy.name}'s Damage: {enemy.damage}\n");
                    if (!frozen)
                    {
                        LogsText.Text += ("\nWhat do you do?");
                        AttackChoice.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        LogsText.Text += ("\nYou are frozen and unable to Act");
                        frozen = enemy.Attack(ref player, false);
                    }
                }
                else //CHECK FIGHT & HP - WIN
                {
                    LogsText.Text += ("\n===============\nEnemy Defeated!\n===============");
                    fighting = false;
                    fight_count += 1;
                    LogsText.Text += ("\nPress OK to continue");
                    OKbutton.Visibility = Visibility.Visible;
                    EnemyListBox.Visibility = Visibility.Hidden;
                }
            }
            else {
                NavigationService.Navigate(new GameOver());
            }
            ScrollView.ScrollToBottom();
        }

        private void AttackLogic()
        {
            if (action == 1)
            {
                frozen = enemy.Attack(ref player, true);
            }
            else if (action == 2)
            {
                enemy.TakeDamage(Math.Max(0, player.weapon - enemy.armor * ((Convert.ToDouble(RandomGame.NextNum(7, 11)) / 10))));
                if (enemy.hp != 0) frozen = enemy.Attack(ref player, false);
            }
            ContinueGame();
        }

        private void OKclick(object sender, RoutedEventArgs e)
        {
            OKbutton.Visibility = Visibility.Hidden;
            ContinueGame();
        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            ItemChoice.Visibility = Visibility.Hidden;
            ContinueGame();
        }

        private void TakeButton_Click(object sender, RoutedEventArgs e)
        {
            if(item_t == ItemType.Weapon)
            {
                player.weapon_name = item_name;
                player.weapon = item_int;
            }
            else if (item_t == ItemType.Armor)
            {
                player.armor_name = item_name;
                player.armor = item_int;
            }
            ItemChoice.Visibility = Visibility.Hidden;
            ContinueGame();
        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            action = 2;
            AttackChoice.Visibility = Visibility.Hidden;
            AttackLogic();
        }

        private void DefendButton_Click(object sender, RoutedEventArgs e)
        {
            action = 1;
            AttackChoice.Visibility = Visibility.Hidden;
            AttackLogic();
        }
    }
}
