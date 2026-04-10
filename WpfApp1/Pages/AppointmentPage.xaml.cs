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
    /// Логика взаимодействия для AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        Services service;
        public AppointmentPage(Services srv)
        {
            service = srv;
            this.DataContext = srv;
            InitializeComponent();
        }

        

        private void MasterButton_Click(object sender, RoutedEventArgs e)
        {
            Users master = Core.Context.Users.FirstOrDefault(u => u.UserID == service.MasterID);
            if(master != null)  NavigationService.Navigate(new MasterPage(master));
        }
    }
}
