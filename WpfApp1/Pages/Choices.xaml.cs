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
    /// Логика взаимодействия для Choices.xaml
    /// </summary>
    public partial class Choices : Page
    {
        public Choices()
        {
            InitializeComponent();
            var _data = NavigationData.CurrentData as Car;
            TotalPrice.Text = Convert.ToString(_data.TotalPrice);
            ModelText.Text += _data.Model;
            EngineText.Text += _data.Engine;
            ColorText.Text += _data.Color;
            foreach(var i in _data.More)
            {
                MoreText.Text += "\n" + "- " + i;
            }
        }
    }
}
