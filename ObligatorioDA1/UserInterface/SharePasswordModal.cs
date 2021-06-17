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
using Domain.PasswordEncryptor;

namespace UserInterface
{
    public partial class SharePasswordModal : Form
    {
        private EncryptorIndirection _encryption;
        private User _currentUser;
        private Password _sharedPassword;
        public SharePasswordModal(Password password)
        {
            InitializeComponent();
            _encryption = new EncryptorIndirection(new EffortlessEncryptionWrapper());

            _sharedPassword = password;
            _currentUser = UserManager.Instance.LoggedUser;
            List<User> bs = new List<User>(UserManager.Instance.Users);
            bs.Remove(_currentUser);
            cmbBxUsers.DataSource = bs;
            if (bs.Count == 0)
            {
                btnShare.Enabled = false;
            }
            else
            {
                btnShare.Enabled = true;
            }

        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            try
            {
                User _userSharedWith = (User)cmbBxUsers.SelectedItem;
                _userSharedWith = UserManager.Instance.GetUser(_userSharedWith.Name);
                //_encryption.PasswordEncryption(_sharedPassword);
                _currentUser.UserPasswords.SharePassword(_userSharedWith, _sharedPassword);

                this.Close();
            }catch(PasswordExceptions exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
