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
    /// Логика взаимодействия для Credit.xaml
    /// </summary>
    public partial class Credit : Page
    {
        public Credit()
        {
            InitializeComponent();
        }

        private void Percent_TextChanged(object sender, TextChangedEventArgs e)
        {
            float result;
            bool isNumber = float.TryParse(Percent.Text, out result);
            if (isNumber)
            {
                var cra = NavigationData.CurrentData as Car;
                cra.Percent = result;
            }
        }

        private void months_TextChanged(object sender, TextChangedEventArgs e)
        {
            int result;
            bool isNumber = int.TryParse(months.Text, out result);
            if (isNumber)
            {
                var cra = NavigationData.CurrentData as Car;
                cra.Months = result;
            }
        }
    }
}
