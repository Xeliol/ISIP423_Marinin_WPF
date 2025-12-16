using System;
using System.IO;
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
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : Page
    {
        public Results()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cra = NavigationData.CurrentData as Car;
            cra.Name = name.Text;
            cra.Phone = Phone.Text;
            cra.Email = Email.Text;
            NavigationData.CurrentData = cra;

            string writeText = "";
            var _data = NavigationData.CurrentData as Car;
            writeText = Convert.ToString(_data.TotalPrice) + "\n";
            writeText += _data.Model.name + " " + _data.Model.Price + " Руб\n";
            writeText += _data.Engine.name + " " + _data.Engine.Price + " Руб\n";
            writeText += _data.Color.name + " " + _data.Color.Price + " Руб\n";
            foreach (var i in _data.More)
            {
                writeText += "\n" + "- " + i.name + " " + i.Price + " Руб\n";
            }
            File.WriteAllText("save.txt", writeText);
        }
    }
}
