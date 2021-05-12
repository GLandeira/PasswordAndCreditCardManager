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

namespace UserInterface
{
    public partial class UnsharePasswordModal : Form
    {
        private UserManager _currentUserManager;
        private Password _unsharedPassword;
        private User _currentUser;
        public delegate void UnsharedPasswordEvent(List<Password> passwordList);
        public static event UnsharedPasswordEvent onSharePassword;
        public UnsharePasswordModal(UserManager userManager, Password unsharedPassword)
        {
            List<User> _usersSharedList = new List<User>();
            _currentUserManager = userManager;
            _currentUser = _currentUserManager.LoggedUser;
            _unsharedPassword = unsharedPassword;
            
            InitializeComponent();
            foreach (string username in unsharedPassword.UsersSharedWith)
            {
                _usersSharedList.Add(userManager.GetUser(username));
            }
            cmbBxUsers.DataSource = _usersSharedList;
        }

        private void btnUnshare_Click(object sender, EventArgs e)
        {
            User userPasswordUnsharedWith = (User) cmbBxUsers.SelectedItem;
            _currentUser.UserPasswords.StopSharingPassword(userPasswordUnsharedWith, _unsharedPassword);
            List<Password> sharedWithList = _currentUser.UserPasswords.GetPasswordsImSharing();
            onSharePassword?.Invoke(sharedWithList);
            this.Close();
        }


    }
}
