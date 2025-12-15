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
            List<Colors> colors = new List<Colors>()
            {
                new Colors
                {
                    name = "Red",
                    Price = 15000
                },
                new Colors
                {
                    name = "Gold",
                    Price = 25000
                },
                new Colors
                {
                    name = "Green",
                    Price = 15000
                },
                new Colors
                {
                    name = "Deep Blue",
                    Price = 20000
                },
                new Colors
                {
                    name = "Purple",
                    Price = 20000
                },
                new Colors
                {
                    name = "Gray",
                    Price = 15000
                },
                new Colors
                {
                    name = "Black",
                    Price = 15000
                },
                new Colors
                {
                    name = "White",
                    Price = 15000
                },
                new Colors
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
        List<string> moreNames = new List<string>();

        class  Colors
        {
            public int Price { get; set; }
            public string name { get; set; }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var car = NavigationData.CurrentData as Car;
            car.Color = ColorComboBox.Text;
            car.More = moreNames;

            NavigationData.CurrentData = car;
            NavigationService.Navigate(new Choices());
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ColorCost.Text = "Стоимость: " + ((Colors)ColorComboBox.SelectedItem).Price;
            changeTotal();
        }

        private void more1_Checked(object sender, RoutedEventArgs e)
        {

            moreSum += 25000;
            moreNames.Add((string)more1.Content);
            changeTotal();
        }

        private void more2_Checked(object sender, RoutedEventArgs e)
        {
            moreSum += 15000;
            moreNames.Add((string)more2.Content);
            changeTotal();
        }

        private void more3_Checked(object sender, RoutedEventArgs e)
        {
            moreSum += 50000;
            moreNames.Add((string)more3.Content);
            changeTotal();
        }

        private void more4_Checked(object sender, RoutedEventArgs e)
        {
            moreSum += 45000;
            moreNames.Add((string)more4.Content);
            changeTotal();
        }

        void changeTotal()
        {
            var cra = NavigationData.CurrentData as Car;
            TotalCost.Text = "Общая Стоимость: " + (cra.TotalPrice + moreSum + ((Colors)ColorComboBox.SelectedItem).Price);
        }

        private void more1_Unchecked(object sender, RoutedEventArgs e)
        {
            moreSum -= 25000;
            moreNames.Remove((string)more1.Content);
            changeTotal();
        }

        private void more2_Unchecked(object sender, RoutedEventArgs e)
        {
            moreSum -= 15000;
            moreNames.Remove((string)more2.Content);
            changeTotal();
        }

        private void more3_Unchecked(object sender, RoutedEventArgs e)
        {
            moreSum -= 50000;
            moreNames.Remove((string)more3.Content);
            changeTotal();
        }

        private void more4_Unchecked(object sender, RoutedEventArgs e)
        {
            moreSum -= 45000;
            moreNames.Remove((string)more4.Content);
            changeTotal();
        }
    }
}
