using SoftecData.Models;
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
            var db = new SQLiteConnection(StorageFilePath);
            db.CreateTable<Account>();
            db.CreateTable<PasswordEntry>();
        }


        public void Add(Account account)
        {

        }

        public void Add(PasswordEntry passwordEntry)
        {

        }


        
    }
}
