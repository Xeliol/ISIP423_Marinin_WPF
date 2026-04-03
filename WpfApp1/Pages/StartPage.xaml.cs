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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();

            List<Users> masters = Core.Context.Users.Where(u => u.TypeID == 2).ToList();

            MasterListBox.ItemsSource = masters;

            List<string> SortItems = Core.Context.ServiceTypes.Select(t => t.Name).ToList();

            SortBox.ItemsSource = SortItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            ListBoxItem listBoxItem = (ListBoxItem)MasterListBox.ContainerFromElement(clickedButton);

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
                //FIXXXXX
                List<Users> newsource = Core.Context.Users.Where(u => u.TypeID == 2 && Core.Context.Services.Where(s => s.ServiceTypes.Name == SortBox.SelectedItem).Select(s => s.MasterID).Contains(u.UserID)).ToList();
                MasterListBox.ItemsSource = newsource;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MasterListBox.ItemsSource = Core.Context.Movies.ToList().Where(p => p.Name.ToLower().Contains(SearchBox.Text.ToLower()));
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }
    }
}
