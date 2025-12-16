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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var car = new Car();
            car.Model = new Option
            {
                name = "Default",
                Price = 0
            };
            car.Engine = new Option
            {
                name = "Default",
                Price = 0
            };
            car.Color = new Option
            {
                name = "Default",
                Price = 0
            };
            car.More = new List<Option>();
            NavigationData.CurrentData = car;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(MainFrame.NavigationService.CanGoBack) MainFrame.NavigationService.GoBack();
        }
    }

    public class Option
    {
        public int Price { get; set; }
        public string name { get; set; }
    }

    public class Car
    {
        public Option Model;
        public Option Color;
        public Option Engine;
        public List<Option> More;

        public float Percent;
        public int Months;
        public int TotalPrice;

        public string Name;
        public string Phone;
        public string Email;
    }

    public static class NavigationData
    {
        public static object CurrentData
        {
            get; set;
        }
    }
}
