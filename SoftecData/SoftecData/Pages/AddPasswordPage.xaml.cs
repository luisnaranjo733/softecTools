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
    /// Interaction logic for AddPasswordPage.xaml
    /// </summary>
    public partial class AddPasswordPage : Page
    {
        private StorageService _storageService;
        private AccountRepository _accountRepository;
        private Account _currentAccount;

        public AddPasswordPage(StorageService storageService, AccountRepository accountRepository, Account currentAccount)
        {
            _storageService = storageService;
            _accountRepository = accountRepository;
            this._currentAccount = currentAccount;
            InitializeComponent();
        }

        public AddPasswordPage()
        {
            InitializeComponent();
        }

        private void addPasswordEntry()
        {
            PasswordEntry passwordEntry = new PasswordEntry()
            {
                Password = passwordTextbox.Text,
                Initials = initialsTextbox.Text,
                Timestamp = DateTime.Now,
                AccountId = _currentAccount.Id
            };
            passwordEntry.setAccount(_currentAccount);
            _storageService.Add(passwordEntry);
            _accountRepository.Add(passwordEntry);
            NavigationService.Navigate(new PasswordsPage(_storageService, _accountRepository));
        }

        private void doneButton_Click(object sender, RoutedEventArgs e)
        {
            String password = passwordTextbox.Text;
            String initials = initialsTextbox.Text;
            Boolean passwordEmpty = password == "";
            Boolean initialsEmpty = initials == "";

            if (_currentAccount == null)
            {
                MessageBox.Show("Make sure to select an account before adding a password", "Oops", MessageBoxButton.OK);
                return;
            } else if (passwordEmpty && initialsEmpty)
            {
                MessageBox.Show("Password and initials field can't be empty", "Oops", MessageBoxButton.OK);
                return;
            } else if (passwordEmpty)
            {
                MessageBox.Show("Password field can't be empty", "Oops", MessageBoxButton.OK);
                return;
            } else if (initialsEmpty)
            {
                MessageBox.Show("Initials field can't be empty", "Oops", MessageBoxButton.OK);
                return;
            }
            addPasswordEntry();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            passwordTextbox.Focus();
        }
    }
}
