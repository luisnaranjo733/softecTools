using SoftecData.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftecData.Services
{
    public class StorageService : iCRUD
    {
        public string StorageFilePath { get; set; } 

        public StorageService()
        {
            string[] drives = Environment.GetLogicalDrives();
            StorageFilePath = null;
            foreach (string dr in drives)
            {
                if (dr != @"C:\")
                {
                    continue;
                }
                DriveInfo di = new DriveInfo(dr);
                if (!di.IsReady)
                {
                }
                DirectoryInfo driveRootDir = di.RootDirectory;
                DirectoryInfo dataStorageDir = driveRootDir.CreateSubdirectory(@"software\softec utilities");
                StorageFilePath = Path.Combine(dataStorageDir.FullName, "database");
            }
        }

        public void Initialize()
        {
            using (SQLiteConnection db = new SQLiteConnection(StorageFilePath))
            {
                db.CreateTable<Account>();
                db.CreateTable<PasswordEntry>();
            }

        }

        public ObservableCollection<Account> GetAccounts()
        {
            ObservableCollection<Account> accounts = new ObservableCollection<Account>();
            using (SQLiteConnection db = new SQLiteConnection(StorageFilePath))
            {
                var accountQuery = db.Table<Account>().OrderBy(a => a.Username);
                foreach (Account account in accountQuery)
                {
                    var passwordQuery = db.Table<PasswordEntry>().Where(p => p.AccountId == account.Id);
                    ObservableCollection<PasswordEntry> passwords = new ObservableCollection<PasswordEntry>();
                    foreach(PasswordEntry passwordEntry in passwordQuery)
                    {
                        passwords.Add(passwordEntry);
                    }
                    account.SetPasswords(passwords);
                    
                    accounts.Add(account);
                }
            }
            return accounts;
        }

        public ObservableCollection<PasswordEntry> GetPasswords(Account account)
        {
            throw new NotImplementedException();
        }


        public void Add(Account account)
        {
            using (SQLiteConnection db = new SQLiteConnection(StorageFilePath))
            {
                db.Insert(account);
            }
        }

        public void Add(PasswordEntry passwordEntry)
        {
            using (SQLiteConnection db = new SQLiteConnection(StorageFilePath))
            {
                db.Insert(passwordEntry);
            }
        }

        public void Delete(Account account)
        {
            using (SQLiteConnection db = new SQLiteConnection(StorageFilePath))
            {
                db.Delete(account);
                // TODO: Find and delete all password entries that depend on this account that is being deleted
                // Currently these are just being left behind. The loading logic loops over accounts
                // so they shouldn't get rendered after their parent account is deleted
            }
        }

        public void Delete(PasswordEntry passwordEntry)
        {
            using (SQLiteConnection db = new SQLiteConnection(StorageFilePath))
            {
                db.Delete(passwordEntry);
            }
        }

    }
}
