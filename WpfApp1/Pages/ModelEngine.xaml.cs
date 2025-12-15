using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для ModelEngine.xaml
    /// </summary>
    public partial class ModelEngine : Page
    {
        public ModelEngine()
        {
            InitializeComponent();
            List<Engine> engines = new List<Engine>()
            {
                new Engine
                {
                    Price = 187000,
                    name = "Good"
                },
                new Engine
                {
                    name = "Mid",
                    Price = 113000
                },
                new Engine
                {
                    name = "Bad",
                    Price = 90000
                }
            };
            List<Model> models = new List<Model>()
            {
                new Model
                {
                    Price = 2000000,
                    name = "Kia Rio"
                },
                new Model
                {
                    name = "Toyota Kamara",
                    Price = 2300000
                },
                new Model
                {
                    name = "Honda Civic",
                    Price = 1800000
                }
            };

            ModelComboBox.ItemsSource = models;
            ModelComboBox.DisplayMemberPath = "name";
            ModelComboBox.SelectedIndex = 0;

            EngineComboBox.ItemsSource = engines;
            EngineComboBox.DisplayMemberPath = "name";
            EngineComboBox.SelectedIndex = 0;
        }

        class Engine
        {
            public int Price { get; set; }
            public string name { get; set; }
        }

        class Model
        {
            public int Price { get; set; }
            public string name { get; set; }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var car = NavigationData.CurrentData as Car;
            car.Model = ModelComboBox.Text;
            car.Engine = EngineComboBox.Text;
            car.TotalPrice = ((Model)ModelComboBox.SelectedItem).Price + ((Engine)EngineComboBox.SelectedItem).Price;

            NavigationData.CurrentData = car;

            NavigationService.Navigate(new ColorOptions());
        }

        private void ModelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModelCost.Text = "Стоимость: " + ((Model)ModelComboBox.SelectedItem).Price;
            if(EngineComboBox.SelectedIndex != -1) TotalCost.Text = "Общая Стоимость: " + (((Model)ModelComboBox.SelectedItem).Price + ((Engine)EngineComboBox.SelectedItem).Price);
        }

        private void EngineComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EngineCost.Text = "Стоимость: " + ((Engine)EngineComboBox.SelectedItem).Price;
            TotalCost.Text = "Общая Стоимость: " + (((Model)ModelComboBox.SelectedItem).Price + ((Engine)EngineComboBox.SelectedItem).Price);
        }
    }
}
