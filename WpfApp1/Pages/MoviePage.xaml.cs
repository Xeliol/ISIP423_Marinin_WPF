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
    /// Логика взаимодействия для MoviePage.xaml
    /// </summary>
    public partial class MoviePage : Page
    {
        public MoviePage()
        {
            InitializeComponent();

            var curdata = NavigationData.CurrentData as CurData;
            Movies mov = Core.Context.Movies.ToList()[curdata.MovieID];

            this.DataContext = mov;

            SessionListBox.ItemsSource = Core.Context.Session.Where(p => p.MovieID == mov.MovieID).ToList();

        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            if ((NavigationData.CurrentData as CurData).ID == -1) NavigationService.Navigate(new LoginPage());
            else NavigationService.Navigate(new AccountPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var curdata = NavigationData.CurrentData as CurData;
            if (curdata.ID == -1)
            {
                MessageBox.Show("You need to be logged in to buy a ticket.");
                NavigationService.Navigate(new LoginPage());
            } else
            {
                Button clickedButton = sender as Button;

                ListBoxItem listBoxItem = (ListBoxItem)SessionListBox.ContainerFromElement(clickedButton);

                if (listBoxItem != null)
                {
                    object dataItem = listBoxItem.Content;

                    var sess = dataItem as Session;

                    NavigationService.Navigate(new SessionPage(sess));
                }
            }
        }
    }
}
