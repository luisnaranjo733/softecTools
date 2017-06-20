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
using System.Windows.Shapes;

namespace SoftecData.Pages
{
    /// <summary>
    /// Interaction logic for PasswordDialogWindow.xaml
    /// </summary>
    public partial class PasswordDialogWindow : Window
    {
        public PasswordDialogWindow(string question, string defaultAnswer="")
        {
            InitializeComponent();
            lblQuestion.Content = question;
            txtAnswer.Password = defaultAnswer;

        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtAnswer.SelectAll();
            txtAnswer.Focus();
        }

        public string Password
        {
            get { return txtAnswer.Password; }
        }
    }
}
