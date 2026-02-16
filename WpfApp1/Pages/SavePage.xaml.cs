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
    /// Логика взаимодействия для SavePage.xaml
    /// </summary>
    public partial class SavePage : Page
    {
        public SavePage(List<basepart_> parts)
        {
            InitializeComponent();

            prts = parts;
        }

        List<basepart_> prts = new List<basepart_>();

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorName.Text != "" && AssemblyName.Text != "")
            {
                assembly_ assem = new assembly_
                {
                    name = AssemblyName.Text,
                    author = AuthorName.Text
                };
                Core.Context.assembly_.Add(assem);
                Core.Context.SaveChanges();
                int id = Core.Context.assembly_.Count();

                foreach (basepart_ part in prts) 
                {
                    partassembly_ partas = new partassembly_
                    {
                        partid = part.id,
                        assemblyid = id
                    };
                    Core.Context.partassembly_.Add(partas);
                    Core.Context.SaveChanges();
                }
            }
            else MessageBox.Show("One of the inputs is empty!");
        }
    }
}
