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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            List<Movies> movies = Core.Context.Movies.ToList();

            UserListBox.ItemsSource = movies;

            List<string> SortItems = new List<string>()
            {
                "Genre", "Age Rating", "Name", "Rating"
            };

            SortBox.ItemsSource = SortItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            ListBoxItem listBoxItem = (ListBoxItem)UserListBox.ContainerFromElement(clickedButton);

            if (listBoxItem != null)
            {
                object dataItem = listBoxItem.Content;

                var mov = dataItem as Movies;

                var curdata = NavigationData.CurrentData as CurData;

                curdata.MovieID =  mov.MovieID - 1;

                NavigationService.Navigate(new MoviePage());
            }
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            if((NavigationData.CurrentData as CurData).ID == -1) NavigationService.Navigate(new LoginPage());
            //else NavigationService.Navigate(new AccountPage());
        }

        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortBox.SelectedItem != null)
            {
                switch (SortBox.SelectedItem.ToString())
                {
                    case "Genre":
                        UserListBox.ItemsSource = Core.Context.Movies.ToList().OrderBy(p => p.Genre);
                        break;
                    case "Age Rating":
                        UserListBox.ItemsSource = Core.Context.Movies.ToList().OrderBy(p => p.AgeRating);
                        break;
                    case "Name":
                        UserListBox.ItemsSource = Core.Context.Movies.ToList().OrderBy(p => p.Name);
                        break;
                    case "Rating":
                        UserListBox.ItemsSource = Core.Context.Movies.ToList().OrderBy(p => p.Rating);
                        break;
                }
            }
        }
    }
}
