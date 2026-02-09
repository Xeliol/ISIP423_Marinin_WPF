using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        public TicketPage(Session sess, List<String> seats)
        {
            InitializeComponent();

            this.DataContext = sess;

            SeatsListBox.ItemsSource = seats;

            int ticket_price = 480;

            int price = 0;

            if (Core.Context.Theaters.Where(p => p.TheaterID == sess.TheaterID).First().Rating == "VIP") ticket_price = 680;
            
            foreach(var tic in seats)
            {
                price += ticket_price;
            }

            PriceText.Text += price.ToString() + "Rub.";

            sts = seats;
            sessi = sess;
        }

        List<String> sts = new List<String>();
        Session sessi = new Session();

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var curdata = NavigationData.CurrentData as CurData;

            foreach (var tic in sts)
            {
                Tickets new_ticket = new Tickets
                {
                    TicketID = Core.Context.Tickets.ToList().Count() + 1,
                    UserID = curdata.ID,
                    SessionID = sessi.SessionID,
                    Seat = tic
                };
                Core.Context.Tickets.Add(new_ticket);
                Core.Context.SaveChanges();
            }
            MessageBox.Show("Purchase completed!");
            NavigationService.Navigate(new AccountPage());
        }
    }
}
