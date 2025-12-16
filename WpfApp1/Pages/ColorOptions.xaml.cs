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
    /// Логика взаимодействия для ColorOptions.xaml
    /// </summary>

    public partial class ColorOptions : Page
    {
        public ColorOptions()
        {
            InitializeComponent();

            var cra = NavigationData.CurrentData as Car;
            cra.Color = new Option
            {
                name = "Default",
                Price = 0
            };
            cra.More = new List<Option>();
            NavigationData.CurrentData = cra;

            RecountTotal();

            List<Option> colors = new List<Option>()
            {
                new Option
                {
                    name = "Red",
                    Price = 15000
                },
                new Option
                {
                    name = "Gold",
                    Price = 25000
                },
                new Option
                {
                    name = "Green",
                    Price = 15000
                },
                new Option
                {
                    name = "Deep Blue",
                    Price = 20000
                },
                new Option
                {
                    name = "Purple",
                    Price = 20000
                },
                new Option
                {
                    name = "Gray",
                    Price = 15000
                },
                new Option
                {
                    name = "Black",
                    Price = 15000
                },
                new Option
                {
                    name = "White",
                    Price = 15000
                },
                new Option
                {
                    name = "Steel Blue",
                    Price = 15000
                }
            };

            ColorComboBox.ItemsSource = colors;
            ColorComboBox.DisplayMemberPath = "name";
            ColorComboBox.SelectedIndex = 0;
        }

        int moreSum = 0;
        List<Option> moreNames = new List<Option>();

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var car = NavigationData.CurrentData as Car;
            car.Color = (Option)ColorComboBox.SelectedItem;
            car.More = moreNames;
            //car.TotalPrice += ((Option)ColorComboBox.SelectedItem).Price + moreSum;


            NavigationData.CurrentData = car;
            NavigationService.Navigate(new Choices());
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ColorCost.Text = "Стоимость: " + ((Option)ColorComboBox.SelectedItem).Price;
            changeTotal();
        }

        private void more1_Checked(object sender, RoutedEventArgs e)
        {
            moreNames.Add(
                new Option
                {
                    name = "Extra driving wheel",
                    Price = 25000
                }
                );
            changeTotal();
        }

        private void more2_Checked(object sender, RoutedEventArgs e)
        {
            moreNames.Add(
                new Option
                {
                    name = "Extra seat",
                    Price = 15000
                }
                );
            changeTotal();
        }

        private void more3_Checked(object sender, RoutedEventArgs e)
        {
            moreNames.Add(
                new Option
                {
                    name = "super mega boost brrrrrrr",
                    Price = 50000
                }
                );
            changeTotal();
        }

        private void more4_Checked(object sender, RoutedEventArgs e)
        {
            moreNames.Add(
                new Option
                {
                    name = "Car moRe mischievous",
                    Price = 45000
                }
                );
            changeTotal();
        }

        void changeTotal()
        {
            var cra = NavigationData.CurrentData as Car;
            int Summ = 0;
            foreach(var opt in moreNames)
            {
                Summ += opt.Price;
            }
            TotalCost.Text = "Общая Стоимость: " + (cra.TotalPrice + Summ + ((Option)ColorComboBox.SelectedItem).Price);
        }

        public void RecountTotal()
        {
            var cra = NavigationData.CurrentData as Car;
            cra.TotalPrice = 0;
            cra.TotalPrice += cra.Model.Price;
            cra.TotalPrice += cra.Engine.Price;
            cra.TotalPrice += cra.Color.Price;
            foreach(var i in cra.More)
            {
                cra.TotalPrice += i.Price;
            }
            NavigationData.CurrentData = cra;
        }

        private void more1_Unchecked(object sender, RoutedEventArgs e)
        {
            moreNames.Remove(moreNames.First(x => x.name == "Extra driving wheel"));
            changeTotal();
        }

        private void more2_Unchecked(object sender, RoutedEventArgs e)
        {
            moreNames.Remove(moreNames.First(x => x.name == "Extra seat"));
            changeTotal();
        }

        private void more3_Unchecked(object sender, RoutedEventArgs e)
        {
            moreNames.Remove(moreNames.First(x => x.name == "super mega boost brrrrrrr"));
            changeTotal();
        }

        private void more4_Unchecked(object sender, RoutedEventArgs e)
        {
            moreNames.Remove(moreNames.First(x => x.name == "Car moRe mischievous"));
            changeTotal();
        }
    }
}
