using SoftecData.Pages;
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
        private StorageService storageService;
        private AccountRepository accountRepository;

        public MainWindow()
        {
            InitializeComponent();
            storageService = new StorageService();
            accountRepository = new AccountRepository();
            try
            {
                storageService.Initialize();
                accountRepository.Initialize(storageService);
                //accountRepository.SeedDummyData();

                _mainFrame.Navigate(new PasswordsPage(storageService, accountRepository));
                //_mainFrame.Navigate(new LoginPage(storageService, accountRepository));
            } catch
            {
                MessageBox.Show("Missing sqlite DLL");
            }
            
        }

    }

}
