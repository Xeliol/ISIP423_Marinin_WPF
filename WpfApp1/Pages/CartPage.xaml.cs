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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();
            var cart = NavigationData.CurrentData as List<Product>;

            foreach (var topp in cart)
            {
                infoText.Text += "\n-" + topp.Name + " (" + topp.Price + " rub)";
            }
            if (cart.Count == 0) { infoText.Text = "None"; }
        }

        private void NextBut_Click(object sender, RoutedEventArgs e)
        {
            if (infoText.Text != "None") NavigationService.Navigate(new ConfirmPage());
            else MessageBox.Show("Nothing in cart to order!");
        }
    }
}
