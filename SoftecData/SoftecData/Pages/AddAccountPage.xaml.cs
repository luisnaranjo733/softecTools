﻿using SoftecData.Models;
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
            Account account = new Account() { Username = usernameTextbox.Text };
            _storageService.Add(account);
            _accountRepository.Add(account);
            NavigationService.Navigate(new PasswordsPage(_storageService, _accountRepository));
        }
    }
}