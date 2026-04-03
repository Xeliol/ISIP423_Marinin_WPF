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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();

            List<Products> products = Core.Context.Products.ToList();

            ProductListBox.ItemsSource = products;

            List<string> SortItems = new List<string>()
            {
                "Genre", "Age Rating", "Name", "Rating"
            };

            SortBox.ItemsSource = SortItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            ListBoxItem listBoxItem = (ListBoxItem)ProductListBox.ContainerFromElement(clickedButton);

            if (listBoxItem != null)
            {
                object dataItem = listBoxItem.Content;

                NavigationService.Navigate(new AppointmentPage());
            }
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            if ((NavigationData.CurrentData as CurData).ID == -1) NavigationService.Navigate(new LoginPage());
            else NavigationService.Navigate(new AccountPage());
        }

        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortBox.SelectedItem != null)
            {
                switch (SortBox.SelectedItem.ToString())
                {
                    case "Genre":
                        //MasterListBox.ItemsSource = Core.Context.Movies.ToList().OrderBy(p => p.Genre);
                        break;
                    case "Age Rating":
                        //MasterListBox.ItemsSource = Core.Context.Movies.ToList().OrderBy(p => p.AgeRating);
                        break;
                    case "Name":
                        //MasterListBox.ItemsSource = Core.Context.Movies.ToList().OrderBy(p => p.Name);
                        break;
                    case "Rating":
                        //MasterListBox.ItemsSource = Core.Context.Movies.ToList().OrderBy(p => p.Rating);
                        break;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MasterListBox.ItemsSource = Core.Context.Movies.ToList().Where(p => p.Name.ToLower().Contains(SearchBox.Text.ToLower()));
        }
    }
}
