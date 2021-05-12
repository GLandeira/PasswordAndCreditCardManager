using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Domain.Exceptions;

namespace UserInterface
{
    public partial class SharePasswordModal : Form
    {
        UserManager _currentUserManager;
        Password _sharedPassword;
        public SharePasswordModal(UserManager userManager, Password password)
        {
            InitializeComponent();
            _currentUserManager = userManager;
            _sharedPassword = password;
            List<User> bs = _currentUserManager.Users;
            cmbBxUsers.DataSource = bs;

        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            try
            {
                User _currentUser = _currentUserManager.LoggedUser;
                User _userSharedWith = (User)cmbBxUsers.SelectedItem;
                _currentUser.UserPasswords.SharePassword(_userSharedWith, _sharedPassword);
                this.Close();
            }catch(PasswordExceptions exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
