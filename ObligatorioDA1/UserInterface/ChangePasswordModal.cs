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
    public partial class ChangePasswordModal : Form
    {

        private User _currentUser;

        private const string PASSWORD_MODIFY_SUCCESS = "Password modified successfully.";
        private const string PASSWORD_MODIFY_FAILURE = "Password and confirmation do not match.";

        public ChangePasswordModal()
        {
            InitializeComponent();
            _currentUser = UserManager.Instance.LoggedUser;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string password = txtbxNewPassword.Text;
            string passwordConfirm = txtbxConfirmNewPassword.Text;

            if (password == passwordConfirm)
            {
                TryToModifyPassword(password);
            }
            else
            {
                MessageBox.Show(PASSWORD_MODIFY_FAILURE, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TryToModifyPassword(string password)
        {
            User newUser = new User(_currentUser.UserID, _currentUser.Name, password);

            try
            {
                UserManager.Instance.ModifyPassword(newUser);
                MessageBox.Show(PASSWORD_MODIFY_SUCCESS, "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (UserException ue)
            {
                MessageBox.Show(ue.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
