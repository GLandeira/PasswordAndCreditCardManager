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
    public partial class PasswordsController : UserControl
    {
        private UserManager _userManager;
        private User _currentUser;
        private Password _lastPasswordSelected;
        public PasswordsController(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
            _currentUser = _userManager.LoggedUser;
            AddOrModifyPasswordModal.onModifyOrAddPassword += LoadDataGridPasswords;
        }

        private void PasswordsController_Load(object sender, EventArgs e)
        {

            LoadDataGridPasswords();
        }

        private void BtnNewPassword_Click(object sender, EventArgs e)
        {
            Form addOrModifyPasswordModal = new AddOrModifyPasswordModal(_currentUser, null);
            addOrModifyPasswordModal.ShowDialog();
        }

        private void BtnModifyPassword_Click(object sender, EventArgs e)
        {
            Form addOrModifyPasswordModal = new AddOrModifyPasswordModal(_currentUser, _lastPasswordSelected);
            addOrModifyPasswordModal.ShowDialog();
        }

        private void grdvwPasswordsTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Password selectedPassword = (Password) grdvwPasswordsTable.Rows[e.RowIndex].DataBoundItem;
            _lastPasswordSelected = selectedPassword;
        }

        private void LoadDataGridPasswords()
        {
            grdvwPasswordsTable.DataSource = null;
            List<Password> passwordsList = _currentUser.UserPasswords.Passwords;
            grdvwPasswordsTable.DataSource = passwordsList;

        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            AddOrModifyPasswordModal.onModifyOrAddPassword -= LoadDataGridPasswords;
            base.OnHandleDestroyed(e);
        }
    }
}
