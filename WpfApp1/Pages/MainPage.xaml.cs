using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    public partial class MainPage : Page
    {
        List<Product> cart;
        public MainPage()
        {
            InitializeComponent();
            cart = NavigationData.CurrentData as List<Product>;

            List<Product> Products = new List<Product>()
            {
                new Product
                {
                    Price = 1000,
                    Name = "Wine",
                    ImgPath = "/Images/Wine.jpg"
                },
                new Product
                {
                    Price = 120,
                    Name = "Kvas",
                    ImgPath = "/Images/Kvas.jpg"
                },
                new Product
                {
                    Price = 360,
                    Name = "Cheeseburger",
                    ImgPath = "/Images/Burger.jpg"
                },
            };

            UserListBox.ItemsSource = Products;
        }

        private void NextBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationData.CurrentData = cart;

            NavigationService.Navigate(new CartPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            ListBoxItem listBoxItem = (ListBoxItem)UserListBox.ContainerFromElement(clickedButton);

            if (listBoxItem != null)
            {
                object dataItem = listBoxItem.Content;

                cart.Add(dataItem as Product);
            }
        }

    }
}
