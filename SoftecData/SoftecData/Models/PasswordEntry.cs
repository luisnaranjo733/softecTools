using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftecData.Models
{
    public class PasswordEntry : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int AccountId { get; set; }

        private string _initials;
        private DateTime _timestamp;
        private string _password;
        private Account _account;
        
        public void setAccount(Account account)
        {
            this._account = account;
        }

        public string Initials
        {
            get { return _initials; }
            set
            {
                _initials = value;
                OnPropertyChanged("Initials");
            }
        }

        public DateTime Timestamp
        {
            get { return _timestamp; }
            set
            {
                _timestamp = value;
                OnPropertyChanged("Timestamp");
            }
        }

        public string Password
        {
            get {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string DisplayPassword
        {
            get
            {
                if (_account.ShowPassword)
                {
                    return _password;
                }
                else
                {
                    return getProtectedPassword();
                }
            }
        }

        private string getProtectedPassword()
        {
            string hiddenPassword = "";
            for (int i = 0; i < _password.Length; i++)
            {
                hiddenPassword += "*";
            }
            return hiddenPassword;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
