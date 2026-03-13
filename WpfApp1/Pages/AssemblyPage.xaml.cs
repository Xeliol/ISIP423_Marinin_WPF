using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public partial class AssemblyPage : Page
    {
        public AssemblyPage()
        {
            InitializeComponent();

            List<assembly_> assemblies = Core.Context.assembly_.ToList();

            AssemblyListBox.ItemsSource = assemblies;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            ListBoxItem listBoxItem = (ListBoxItem)AssemblyListBox.ContainerFromElement(clickedButton);

            if (listBoxItem != null)
            {
                object dataItem = listBoxItem.Content;

                var prod = dataItem as assembly_;

                List<partassembly_> AssemblyParts = Core.Context.partassembly_.Where(pa => pa.assemblyid == prod.id).ToList();

                List<basepart_> SavedParts = new List<basepart_>();

                foreach ( partassembly_ partassembly in AssemblyParts )
                {
                    SavedParts.Add(Core.Context.basepart_.Where(b => b.id == partassembly.partid).First());
                }

                NavigationData.CurrentData = SavedParts;

                MessageBox.Show("Assembly loaded.");

                NavigationService.Navigate(new MainPage());
            }
        }
    }
}
