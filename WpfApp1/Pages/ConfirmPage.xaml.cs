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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class ConfirmPage : Page
    {
        public ConfirmPage()
        {
            InitializeComponent();
           
            double cost = 0;

            var cart = NavigationData.CurrentData as List<Product>;
            
            foreach(var topp in cart)
            {
                infoText.Text += "\n-" + topp.Name + " (" + topp.Price + " rub)";
                cost += topp.Price;
            }
            if (cart.Count == 0) { infoText.Text = "None"; }

            priceText.Text += cost;
        }

        private void NextBut_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "" || AdressTextBox.Text == "" || EmailTextBox.Text == "") MessageBox.Show($"A field is empty.");
            else
            {
                var cart = NavigationData.CurrentData as List<Product>;
                Order new_order = new Order
                {
                    ClientName = NameTextBox.Text,
                    Adress = AdressTextBox.Text,
                    Email = EmailTextBox.Text
                };
                int ID = Core.Context.Order.ToList().Count() + 1;
                Core.Context.Order.Add(new_order);

                Core.Context.SaveChanges();

                foreach(var prod in cart)
                {
                    ProductsInOrder new_prIor = new ProductsInOrder
                    {
                        ProductsID = prod.ID,
                        OrderID = ID,
                        ID = Core.Context.ProductsInOrder.ToList().Count() + 1
                    };
                    Core.Context.SaveChanges();
                }

                MessageBox.Show($"Success! Yo thanks, {NameTextBox.Text}");
            }
        }
    }
}
