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
        private UserManager _userManager;
        private User _currentUser;

        private const string PASSWORD_MODIFY_SUCCESS = "Password modified successfully.";

        public ChangePasswordModal(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
            _currentUser = _userManager.LoggedUser;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string password = txtbxNewPassword.Text;
            string passwordConfirm = txtbxConfirmNewPassword.Text;

            if (password == passwordConfirm)
            {
                User newUser = new User(_currentUser.Name, password);

                try
                {
                    _userManager.ModifyPassword(newUser);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
