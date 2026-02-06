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
    /// Логика взаимодействия для SignupPage.xaml
    /// </summary>
    public partial class SignupPage : Page
    {
        public SignupPage()
        {
            InitializeComponent();

            foreach(var user in Core.Context.Users.ToList())
            {
                people.Add(user.Login);
            }
        }

        List<String> people = new List<String>();

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            if(PassBox1.Text != "" && PassBox2.Text != "" && LoginBox.Text != "")
            {
                if(people.Contains(LoginBox.Text)) MessageBox.Show("Username is already in use.");
                else
                {
                    //create user
                }
            }
            else
            {
                MessageBox.Show("Please fill every field.");
            }
        }
    }
}
