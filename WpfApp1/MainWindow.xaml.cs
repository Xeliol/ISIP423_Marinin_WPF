using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NavigationData.CurrentData = new CurData
            {
                ID = -1,
                Login = "Anon"
            };

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Page currentPage = MainFrame.Content as Page;
            if (MainFrame.NavigationService.CanGoBack) MainFrame.NavigationService.GoBack();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Page currentPage = MainFrame.Content as Page;
            if (MainFrame.NavigationService.CanGoBack) MainFrame.NavigationService.Navigate(new Pages.StartPage());
        }
    }

    public static class NavigationData
    {
        public static object CurrentData
        {
            get; set;
        }
    }
}
