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
    /// Логика взаимодействия для SessionPage.xaml
    /// </summary>
    public partial class SessionPage : Page
    {
        public SessionPage(Session sess)
        {
            InitializeComponent();

            List<String> seats = new List<String>();

            int seat_amount = Core.Context.Theaters.Where(p => p.TheaterID == sess.TheaterID).First().Seats;

            for (int i = 0; i < seat_amount; i++)
            {
                seats.Add($"Row {i/10 + 1} Seat {i%10 + 1}");
            }

            SeatListBox.ItemsSource = seats;
            sessi = sess;
        }

        Session sessi = new Session();

        List<String> chosen_seats = new List<String>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton.Background == Brushes.Cyan)
            {
                clickedButton.Background = Brushes.Gray;

                ListBoxItem listBoxItem = (ListBoxItem)SeatListBox.ContainerFromElement(clickedButton);

                if (listBoxItem != null)
                {
                    object dataItem = listBoxItem.Content;

                    var seat = dataItem as String;

                    chosen_seats.Remove(seat);
                    sender = clickedButton;
                }
            }
            else if (clickedButton.Background == Brushes.Red)
            {
                MessageBox.Show("Seat is already taken.");
            }
            else
            {
                clickedButton.Background = Brushes.Cyan;

                ListBoxItem listBoxItem = (ListBoxItem)SeatListBox.ContainerFromElement(clickedButton);

                if (listBoxItem != null)
                {
                    object dataItem = listBoxItem.Content;

                    var seat = dataItem as String;

                    if (Core.Context.Tickets.Where(p => p.SessionID == sessi.SessionID).Where(p => p.Seat == seat).Count() == 0)
                    {

                        chosen_seats.Add(seat);
                        sender = clickedButton;
                    }
                    else
                    {
                        clickedButton.Background = Brushes.Red;
                        sender = clickedButton;

                        MessageBox.Show("Seat is already taken.");
                    }
                }
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (chosen_seats.Count > 0)
            {
                NavigationService.Navigate(new TicketPage(sessi, chosen_seats));
            }else
            {
                MessageBox.Show("Choose your seat(s).");
            }
        }
    }
}
