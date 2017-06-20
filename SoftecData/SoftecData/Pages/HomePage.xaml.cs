using SoftecData.Models;
using SoftecData.Services;
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

namespace SoftecData.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {

        public HomePage()
        {
            InitializeComponent();

            MainWindow mainWindow = ((MainWindow)Application.Current.MainWindow);
            lvUsers.ItemsSource = mainWindow._repository.Data;
        }

        private void fetchProtectedData_Click(object sender, RoutedEventArgs e)
        {
            PasswordDialogWindow inputDialog = new PasswordDialogWindow("Please enter the password");
            if (inputDialog.ShowDialog() == true)
            {
                string password = inputDialog.Answer;
            }

            //DataItem newItem = new DataItem
            //{
            //    Key = "a",
            //    Value = "b",
            //    Protected = true
            //};

            //MainWindow mainWindow = ((MainWindow)Application.Current.MainWindow);
            //mainWindow._repository.AddItem(newItem);

            //NavigationService.Navigate(new HomePage());
        }

        private void addDataItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDataPage());
        }

        private void deleteDataItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void seteAutomateID_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SeteAutomateIDPage());
        }
    }
}
