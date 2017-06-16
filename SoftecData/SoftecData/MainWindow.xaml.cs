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

namespace SoftecData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataRepository _repository;

        public MainWindow()
        {
            InitializeComponent();

            _repository = new DataRepository();
            _repository.FetchData();

            lvUsers.ItemsSource = _repository.Data;

        }

        private void fetchProtectedData_Click(object sender, RoutedEventArgs e)
        {
            lvUsers.ItemsSource = _repository.Data.Take(2);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            MessageBox.Show(path, path);
        }

        private void addDataItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }
    }
}
