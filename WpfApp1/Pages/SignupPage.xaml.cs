using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Net.Mime.MediaTypeNames;

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
        List<String> nums = new List<String> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};

        private bool isPassWrong(String pass)
        {
            bool flag = true;
            if (PassBox1.Text.Length < 8 ) flag = false;
            else
            {
                flag = pass.Any(char.IsDigit);
                flag = !pass.All(char.IsDigit);
            }
            return !flag;
        }

        public static bool IsValidEmailRegex(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            // A simple, common pattern (not fully RFC compliant)
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            try
            {
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            if(PassBox1.Text != "" && PassBox2.Text != "" && LoginBox.Text != "" && PhoneBox.Text != "")
            {
                if(people.Contains(LoginBox.Text)) MessageBox.Show("Username is already in use.");
                else
                {
                    if(PassBox1.Text != PassBox2.Text) MessageBox.Show("Passwords do not match.");
                    else
                    {
                        if (isPassWrong(PassBox1.Text)) MessageBox.Show("Password does not follow the rules.");
                        else
                        {
                            Users new_user = new Users
                            {
                                UserID = Core.Context.Users.ToList().Count() + 1,
                                Login = LoginBox.Text,
                                Password = PassBox1.Text,
                                Phone = PhoneBox.Text
                            };
                            if (IsValidEmailRegex(EmailBox.Text))
                            {
                                new_user.Email = EmailBox.Text;
                            }
                            Core.Context.Users.Add(new_user);
                            Core.Context.SaveChanges();

                            var cur = NavigationData.CurrentData as CurData;

                            cur.Login = new_user.Login;
                            cur.Password = new_user.Password;
                            cur.ID = new_user.UserID;

                            MessageBox.Show("Account created!");
                            NavigationService.Navigate(new MainPage());
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill every field without '*'.");
            }
        }
    }
}
