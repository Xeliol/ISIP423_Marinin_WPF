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
            NavigationData.CurrentData = car;
        }
    }

    public class Car
    {
        public string Model;
        public string Color;
        public string Engine;
        public List<string> More;

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
