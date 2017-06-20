using SoftecData.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftecData.Services
{
    public class AccountRepository
    {
        private ObservableCollection<Account> _accounts;

        public AccountRepository()
        {
            _accounts = new ObservableCollection<Account>();


            // Insert customer and corresponding order information into 
            Account a = new Account() { Username = "softouchadmin" };
            a.Passwords.Add(new PasswordEntry() { Password = "1234", Timestamp = new DateTime(2009, 11, 10), Initials = "JL" });
            a.Passwords.Add(new PasswordEntry() { Password = "5432", Timestamp = new DateTime(2009, 6, 10), Initials = "MO" });
            a.Passwords.Add(new PasswordEntry() { Password = "asd2", Timestamp = new DateTime(2009, 3, 10), Initials = "JL" });
            _accounts.Add(a);

            a = new Account() { Username = "softouchpos" };
            a.Passwords.Add(new PasswordEntry() { Password = "restaurant", Timestamp = new DateTime(2017, 4, 20), Initials = "VH" });
            a.Passwords.Add(new PasswordEntry() { Password = "restbar", Timestamp = new DateTime(2017, 1, 15), Initials = "LN" });
            a.Passwords.Add(new PasswordEntry() { Password = "bokf123", Timestamp = new DateTime(2016, 12, 30), Initials = "VH" });
            _accounts.Add(a);

        }
        
        public ObservableCollection<Account> Accounts
        {
            get { return _accounts; }
        }
    }
}
