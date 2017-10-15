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
    /// Interaction logic for AddAccountPage.xaml
    /// </summary>
    public partial class AddAccountPage : Page
    {
        private StorageService _storageService;
        private AccountRepository _accountRepository;

        public AddAccountPage(StorageService storageService, AccountRepository accountRepository)
        {
            _storageService = storageService;
            _accountRepository = accountRepository;
            InitializeComponent();
        }

        public AddAccountPage()
        {
            InitializeComponent();
        }

        private void doneButton_Click(object sender, RoutedEventArgs e)
        {
            if (usernameTextbox.Text == "")
            {
                MessageBox.Show("Username cannot be empty", "Oops", MessageBoxButton.OK);
                return;
            }


            Account account = Account.with(usernameTextbox.Text);

            _storageService.Add(account);
            _accountRepository.Add(account);
            NavigationService.Navigate(new PasswordsPage(_storageService, _accountRepository));
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            usernameTextbox.Focus();
        }

        private void showPasswordCheckbox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
