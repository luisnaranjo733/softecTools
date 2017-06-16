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
            string key = keyBox.Text;
            string value = valueBox.Text;
            bool passwordProtected = protectedBox.IsChecked ?? false;

            NavigationService.Navigate(new HomePage());
        }
    }
}
