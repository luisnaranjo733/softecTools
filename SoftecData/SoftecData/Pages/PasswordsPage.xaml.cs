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
            //this.Resources["AccountRepository"] = new AccountRepository();
        }
        public PasswordsPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var accounts =_storageService.GetPasswords();
            //_storageService.Add(new PasswordEntry { Password = "1234" , Timestamp=DateTime.Now, Initials="LN"});
        }
    }
}
