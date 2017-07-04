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
    public class StorageService
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
                TableQuery<Account> accountQuery = db.Table<Account>()
                    .OrderByDescending(a => a.Id);

                foreach (Account account in accountQuery)
                {
                    TableQuery<PasswordEntry> passwordQuery = db.Table<PasswordEntry>()
                        .Where(p => p.AccountId == account.Id)
                        .OrderByDescending(p => p.Timestamp);
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

                // Find and delete all password entries that depend on this account that is being deleted
                // e.g.: Cascade delete
                TableQuery<PasswordEntry> passwordQuery = db.Table<PasswordEntry>()
                    .Where(p => p.AccountId == account.Id);
                foreach(PasswordEntry passwordEntry in passwordQuery)
                {
                    Delete(passwordEntry);
                }

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
