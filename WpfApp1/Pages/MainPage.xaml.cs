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

            //AddedListBox.ItemsSource = types;
            List<basepart_> savedParts = NavigationData.CurrentData as List<basepart_>;
            for(int i = 0; i < savedParts.Count(); i++)
            {
                AddedListBox.Items.Add(savedParts[i]);
            }
        }

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

                var currentParts = AddedListBox.Items.Cast<basepart_>().ToList();

                bool flag = true;

                //socket check
                if (prod.parttypeid == 1 || prod.parttypeid == 4 || prod.parttypeid == 7)
                {
                    foreach (var i in currentParts)
                    {
                        if (i.parttypeid == 1 || i.parttypeid == 4 || i.parttypeid == 7)
                        {
                            switch (prod.parttypeid)
                            {
                                case 1:
                                    if (i.parttypeid == 7)
                                    {
                                        flag = Core.Context.socketprocessorcooler_.Where(m => m.processorcoolerid == i.id).Select(m => m.socketid).Contains(Core.Context.cpu_.Where(m => m.id == prod.id).First().socketid);
                                        if (flag == false) MessageBox.Show("Socket of Cooler and CPU incompatible");
                                    }
                                    else if (i.parttypeid == 4)
                                    {
                                        flag = Core.Context.cpu_.Where(m => m.id == prod.id).First().socketid == Core.Context.motherboard_.Where(m => m.id == i.id).First().socketid;
                                        if (flag == false) MessageBox.Show("Memory type of CPU and Motherboard incompatible");
                                    }
                                    break;
                                case 4:
                                    if (i.parttypeid == 7)
                                    {
                                        flag = Core.Context.socketprocessorcooler_.Where(m => m.processorcoolerid == i.id).Select(m => m.socketid).Contains(Core.Context.motherboard_.Where(m => m.id == prod.id).First().socketid);
                                        if (flag == false) MessageBox.Show("Socket of Cooler and Motherboard incompatible");
                                    }
                                    else if (i.parttypeid == 1)
                                    {
                                        flag = Core.Context.cpu_.Where(m => m.id == i.id).First().socketid == Core.Context.motherboard_.Where(m => m.id == prod.id).First().socketid;
                                        if (flag == false) MessageBox.Show("Memory type of CPU and Motherboard incompatible");
                                    }
                                    break;
                                case 7:
                                    if (i.parttypeid == 4)
                                    {
                                        flag = Core.Context.socketprocessorcooler_.Where(m => m.processorcoolerid == prod.id).Select(m => m.socketid).Contains(Core.Context.cpu_.Where(m => m.id == i.id).First().socketid);
                                        if (flag == false) MessageBox.Show("Socket of Cooler and CPU incompatible");
                                    }
                                    else if (i.parttypeid == 1)
                                    {
                                        flag = Core.Context.socketprocessorcooler_.Where(m => m.processorcoolerid == prod.id).Select(m => m.socketid).Contains(Core.Context.motherboard_.Where(m => m.id == i.id).First().socketid);
                                        if (flag == false) MessageBox.Show("Socket of Cooler and Motherboard incompatible");
                                    }
                                    break;
                            }
                        }
                    }
                }

                //memory type check
                if (prod.parttypeid == 3 || prod.parttypeid == 4)
                {
                    switch (prod.parttypeid)
                    {
                        case 3:
                            foreach (var i in currentParts)
                            {
                                if (i.parttypeid == 4)
                                {
                                    flag = Core.Context.motherboard_.Where(m => m.id == i.id).First().memorytypeid == Core.Context.ram_.Where(m => m.id == prod.id).First().memorytypeid;
                                    if (flag == false) MessageBox.Show("Memory type of RAM and Motherboard incompatible");
                                }
                            }
                            break;
                        case 4:
                            foreach (var i in currentParts)
                            {
                                if (i.parttypeid == 3)
                                {
                                    flag = Core.Context.motherboard_.Where(m => m.id == prod.id).First().memorytypeid == Core.Context.ram_.Where(m => m.id == i.id).First().memorytypeid;
                                    if (flag == false) MessageBox.Show("Memory type of RAM and Motherboard incompatible");
                                }
                            }
                            break;
                    }

                }

                //gpu and powersupply check
                if (prod.parttypeid == 2 || prod.parttypeid == 6)
                {
                    switch (prod.parttypeid)
                    {
                        case 2:
                            foreach (var i in currentParts)
                            {
                                if (i.parttypeid == 6)
                                {
                                    flag = Core.Context.powersupply_.Where(m => m.id == i.id).First().power >= Core.Context.gpu_.Where(m => m.id == prod.id).First().recommendpower;
                                    if (flag == false) MessageBox.Show("Power supply doesn't have enough power for GPU");
                                }
                            }
                            break;
                        case 6:
                            foreach (var i in currentParts)
                            {
                                if (i.parttypeid == 2)
                                {
                                    flag = Core.Context.powersupply_.Where(m => m.id == prod.id).First().power >= Core.Context.gpu_.Where(m => m.id == i.id).First().recommendpower;
                                    if (flag == false) MessageBox.Show("Power supply doesn't have enough power for GPU");
                                }
                            }
                            break;
                    }
                }

                if (flag) AddedListBox.Items.Add(prod);
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
                NavigationData.CurrentData = AddedListBox.Items.Cast<basepart_>().ToList();
                NavigationService.Navigate(new SavePage(src));
            }
            else MessageBox.Show("The assembly is empty.");
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationData.CurrentData = AddedListBox.Items.Cast<basepart_>().ToList();
            NavigationService.Navigate(new AssemblyPage());
        }
    }
}
