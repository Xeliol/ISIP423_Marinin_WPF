using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var log_user = Core.Context.Users.ToList().Where(p => p.Login == LoginBox.Text);
            if (log_user.Count() != 0)
            {
                log_user = Core.Context.Users.ToList().Where(p => p.Login == LoginBox.Text).Where(p => p.Password == PassBox.Text);
                if (log_user.Count() != 0)
                {
                    var cur = NavigationData.CurrentData as CurData;

                    cur.Login = log_user.First().Login;
                    cur.Password = log_user.First().Password;
                    cur.ID = log_user.First().UserID;

                    MessageBox.Show("Logged in!");
                    NavigationService.Navigate(new MainPage());
                }
                else
                {

                }
            } else
            {
                MessageBox.Show("No such user.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignupPage());
        }
    }
}
