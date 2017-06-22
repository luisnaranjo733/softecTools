using SoftecData.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftecData.Services
{
    public interface iCRUD
    {
        void Add(Account account);
        void Add(PasswordEntry password);
        void Delete(Account account);
        void Delete(PasswordEntry password);
        ObservableCollection<Account> GetAccounts();
        ObservableCollection<PasswordEntry> GetPasswords();
    }
}
