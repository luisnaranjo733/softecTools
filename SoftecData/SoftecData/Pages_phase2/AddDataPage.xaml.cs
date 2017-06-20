using SoftecData.Models;
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
    /// Interaction logic for AddDataPage.xaml
    /// </summary>
    public partial class AddDataPage : Page
    {
        public AddDataPage()
        {
            InitializeComponent();
        }

        private void addNewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            DataItem newItem = new DataItem
            {
                Key = keyBox.Text,
                Value = valueBox.Text,
                Protected = protectedBox.IsChecked ?? false
            };

            MainWindow mainWindow = ((MainWindow)Application.Current.MainWindow);
            mainWindow._repository.AddItem(newItem);

            NavigationService.Navigate(new HomePage());
        }
    }
}
