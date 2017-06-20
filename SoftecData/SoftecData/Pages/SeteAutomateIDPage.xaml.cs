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
    /// Interaction logic for SeteAutomateIDPage.xaml
    /// </summary>
    public partial class SeteAutomateIDPage : Page
    {
        public SeteAutomateIDPage()
        {
            InitializeComponent();
        }

        private void seteAutomateID_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.eAutomateID = eAutomateIDBox.Text.ToUpper();
            Properties.Settings.Default.Save();

            MainWindow mainWindow = ((MainWindow)Application.Current.MainWindow);
            mainWindow._repository.FetchData();

            NavigationService.Navigate(new HomePage());
        }
    }
}
