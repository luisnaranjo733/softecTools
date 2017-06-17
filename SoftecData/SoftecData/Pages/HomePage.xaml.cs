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
            MainWindow mainWindow = ((MainWindow)Application.Current.MainWindow);
            lvUsers.ItemsSource = mainWindow._repository.Data.Take(2);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            MessageBox.Show(path, path);
        }

        private void addDataItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDataPage());


        }
    }
}
