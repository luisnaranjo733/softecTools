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

        private void doneButton_Click(object sender, RoutedEventArgs e)
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

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            passwordTextbox.Focus();
        }
    }
}
