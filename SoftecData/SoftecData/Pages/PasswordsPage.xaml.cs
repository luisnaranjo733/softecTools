using SoftecData.Models;
using SoftecData.Services;
using SQLite;
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
    /// Interaction logic for PasswordsPage.xaml
    /// </summary>
    public partial class PasswordsPage : Page
    {
        private StorageService _storageService;
        private AccountRepository _accountRepository;

        public PasswordsPage(StorageService storageService, AccountRepository accountRepository)
        {
            _storageService = storageService;
            _accountRepository = accountRepository;
            this.DataContext = _accountRepository;
            InitializeComponent();
            AddHandler(Keyboard.KeyDownEvent, (KeyEventHandler)HandleKeyDownEvent);
        }
        public PasswordsPage()
        {
            InitializeComponent();
        }

        private void HandleKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                var currentPasswordEntry = (PasswordEntry) listViewPasswords.SelectedItem;
                if (currentPasswordEntry != null)
                {
                    Clipboard.SetText(currentPasswordEntry.Password);
                }
            } else if (e.Key == Key.S && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Account currentAccount = (Account) listViewAccounts.SelectedItem;

                currentAccount.ShowPassword = !currentAccount.ShowPassword;
                foreach(PasswordEntry passwordEntry in currentAccount.Passwords) {
                    passwordEntry.OnPropertyChanged("DisplayPassword");
                }

                this._storageService.Update(currentAccount);
            }
        }

        private void addAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAccountPage(_storageService, _accountRepository));
        }

        private void addPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentAccount = (Account) listViewAccounts.SelectedItem;

            if (currentAccount == null)
            {
                MessageBox.Show("Make sure to select an account before adding a password", "Oops", MessageBoxButton.OK);
                return;
            }

            NavigationService.Navigate(new AddPasswordPage(_storageService, _accountRepository, currentAccount));
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentAccount = (Account)listViewAccounts.SelectedItem;
            var currentPasswordEntry = (PasswordEntry)listViewPasswords.SelectedItem;

            if (currentAccount == null && currentPasswordEntry == null)
            {
                MessageBox.Show("No item selected", "Confirmation", MessageBoxButton.OK);
            } else
            {
                var result = MessageBox.Show("Are you sure you want to delete this?", "Confirmation", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    if (currentAccount != null && currentPasswordEntry == null)
                    {
                        _storageService.Delete(currentAccount);
                        _accountRepository.Delete(currentAccount);
                    }
                    else if (currentAccount != null && currentPasswordEntry != null)
                    {
                        _storageService.Delete(currentPasswordEntry);
                        _accountRepository.Delete(currentPasswordEntry);
                    }
                }
            }
        }
    }
}
