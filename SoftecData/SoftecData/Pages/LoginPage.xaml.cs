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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private StorageService _storageService;
        private AccountRepository _accountRepository;

        public LoginPage(StorageService storageService, AccountRepository accountRepository)
        {
            _storageService = storageService;
            _accountRepository = accountRepository;
            InitializeComponent();
        }

        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Algorithm:
        /// AM
        ///     Month + 2
        ///     Day + 5
        /// PM
        ///     Month + 5
        ///     Day + 2
        ///     
        /// Example:
        /// 06/21 AM = 0826 
        /// 06/21 PM = 1123
        /// 
        /// 06/23 PM = 1125
        /// </summary>
        /// <returns></returns>
        public static string ComputePassword(DateTime currentDate)
        {
           

            int monthModifier;
            int dayModifier;

            bool isAM = currentDate.ToString("tt") == "AM";
            if (isAM)
            {
                monthModifier = 2;
                dayModifier = 5;
            } else
            {
                monthModifier = 5;
                dayModifier = 2;
            }

            int leftPartInt = currentDate.Month + monthModifier;
            int rightPartInt = currentDate.Day + dayModifier;

            string leftPartString = leftPartInt.ToString().PadLeft(2, '0');
            string rightPartString = rightPartInt.ToString().PadLeft(2, '0');

            return leftPartString + rightPartString;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string providedPassword = passwordBox.Password;
            DateTime currentDate = DateTime.Now;
            if (providedPassword == ComputePassword(currentDate))
            {
                NavigationService.Navigate(new PasswordsPage(_storageService, _accountRepository));
            } else
            {
                MessageBox.Show("Wrong password, try again");
                passwordBox.Clear();
            }
            
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            passwordBox.Focus();
        }
    }
}
