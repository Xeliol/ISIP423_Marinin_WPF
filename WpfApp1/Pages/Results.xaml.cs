using System;
using System.IO;
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
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : Page
    {
        public Results()
        {
            InitializeComponent();
            Next.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cra = NavigationData.CurrentData as Car;
            cra.Name = name.Text;
            cra.Phone = Phone.Text;
            cra.Email = Email.Text;
            NavigationData.CurrentData = cra;

            string writeText = "";
            var _data = NavigationData.CurrentData as Car;
            writeText = "Всего: " + Convert.ToString(_data.TotalPrice) + " Руб\n";
            writeText += _data.Model.name + " " + _data.Model.Price + " Руб\n";
            writeText += _data.Engine.name + " " + _data.Engine.Price + " Руб\n";
            writeText += _data.Color.name + " " + _data.Color.Price + " Руб\n";
            
            foreach (var i in _data.More)
            {
                writeText += "- " + i.name + " " + i.Price + " Руб\n";
            }

            writeText += _data.Name + "\n";
            writeText += _data.Email + "\n";
            writeText += _data.Phone + "\n";
            File.WriteAllText("save.txt", writeText);

            Application.Current.Shutdown();
        }

        public void CheckTextBoxes()
        {
            int PhoneNum;
            bool PhoneGood = IsDigitsOnly(Phone.Text);
            bool NameGood = true;
            bool MailGood = true;

            if (PhoneGood) PhoneGood = (Phone.Text.Length > 8) && (Phone.Text.Length > 0);

            if (name.Text.Length > 5) NameGood = true;

            if (Email.Text.Length > 5 && Email.Text.Contains("@")) MailGood = true;

            if (PhoneGood && NameGood &&  MailGood) { Next.IsEnabled = true; }
            else { Next.IsEnabled = false; }
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBoxes();
        }

        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBoxes();
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBoxes();
        }
    }
}
