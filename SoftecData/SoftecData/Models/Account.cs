using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftecData.Models
{
    public class Account : INotifyPropertyChanged
    {

        private string _username;
        private ObservableCollection<PasswordEntry> _passwords
            = new ObservableCollection<PasswordEntry>();

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        public ObservableCollection<PasswordEntry> Passwords
        {
            get { return _passwords; }
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
