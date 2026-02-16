using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            List<basepart_> parts = Core.Context.basepart_.ToList();

            ProductListBox.ItemsSource = parts;

            List<String> manufacts = Core.Context.manufacturer_.Select(p => p.name).ToList();
            manufacts.Insert(0, "[None]");

            List<String> types = Core.Context.parttype_.Select(p => p.name).ToList();
            types.Insert(0, "[None]");

            SortBox.ItemsSource = manufacts;

            PartTypeBox.ItemsSource = types;
        }

        List<basepart_> AddedParts = new List<basepart_>();

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Filters();
            List<basepart_> src = new List<basepart_>();
            foreach (var item in ProductListBox.Items) src.Add(item as basepart_);
            ProductListBox.ItemsSource = src.Where(p => p.name.ToLower().Contains(SearchBar.Text.ToLower())).ToList();
        }

        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check_Filters();
        }

        private void PartTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check_Filters();
        }

        private void Check_Filters()
        {
            if (SortBox.SelectedItem != "[None]" && PartTypeBox.SelectedItem != "[None]")
            {
                ProductListBox.ItemsSource = Core.Context.basepart_.Where(p => p.parttype_.name == PartTypeBox.SelectedItem).Where(p => p.manufacturer_.name == SortBox.SelectedItem).ToList();
            }
            else if (SortBox.SelectedItem != "[None]" && PartTypeBox.SelectedItem == "[None]")
            {
                ProductListBox.ItemsSource = Core.Context.basepart_.Where(p => p.manufacturer_.name == SortBox.SelectedItem).ToList();
            }
            else if (SortBox.SelectedItem == "[None]" && PartTypeBox.SelectedItem != "[None]")
            {
                ProductListBox.ItemsSource = Core.Context.basepart_.Where(p => p.parttype_.name == PartTypeBox.SelectedItem).ToList();
            }
            else if (SortBox.SelectedItem == "[None]" && PartTypeBox.SelectedItem == "[None]")
            {
                ProductListBox.ItemsSource = Core.Context.basepart_.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            ListBoxItem listBoxItem = (ListBoxItem)ProductListBox.ContainerFromElement(clickedButton);

            if (listBoxItem != null)
            {
                object dataItem = listBoxItem.Content;

                var prod = dataItem as basepart_;

                AddedListBox.Items.Add(prod);
            }  
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            ListBoxItem listBoxItem = (ListBoxItem)AddedListBox.ContainerFromElement(clickedButton);

            if (listBoxItem != null)
            {
                object dataItem = listBoxItem.Content;

                var prod = dataItem as basepart_;

                AddedListBox.Items.Remove(prod);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddedListBox.Items.Count > 0)
            {
                List<basepart_> src = new List<basepart_>();
                foreach (var item in AddedListBox.Items) src.Add(item as basepart_);
                NavigationService.Navigate(new SavePage(src));
            }
            else MessageBox.Show("The assembly is empty.");
        }
    }
}
