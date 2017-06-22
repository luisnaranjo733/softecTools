﻿using SoftecData.Models;
using SQLite;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            using (SQLiteConnection db = new SQLiteConnection(StorageFilePath))
            {
                var query = db.Table<Account>().OrderBy(a => a.Username);
                foreach (Account account in query)
                {
                    accounts.Add(account);
                }
            }
            return accounts;
        }

        public IEnumerable<PasswordEntry> GetPasswords()
        {
            List<PasswordEntry> passwords = new List<PasswordEntry>();
            using (SQLiteConnection db = new SQLiteConnection(StorageFilePath))
            {
                var query = db.Table<PasswordEntry>().OrderBy(p => p.Timestamp);
                foreach (PasswordEntry password in query)
                {
                    passwords.Add(password);
                }
            }
            return passwords;
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
