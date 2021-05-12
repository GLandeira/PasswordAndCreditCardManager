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
            UnsharePasswordModal.onSharePassword += LoadSharedPasswordsDataGrid;
        }

        private void PasswordsController_Load(object sender, EventArgs e)
        {

            LoadDataGridPasswords();
            grdvwPasswordsTable.ClearSelection();
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
            if(_lastPasswordSelected.Category == User.SHARED_WITH_ME_CATEGORY)
            {
                BtnModifyPassword.Enabled = false;
                BtnDeletePassword.Enabled = false;
            }
            else
            {
                BtnModifyPassword.Enabled = true;
                BtnDeletePassword.Enabled = true;
            }
        }

        private void LoadDataGridPasswords()
        {
            grdvwPasswordsTable.DataSource = null;
            BindingSource bs = new BindingSource();
            bs.DataSource = _currentUser.UserPasswords.Passwords;
            grdvwPasswordsTable.DataSource = bs;

        }

        private void LoadSharedPasswordsDataGrid()
        {
            grdvwPasswordsTable.DataSource = null;
            BindingSource bs = new BindingSource();
            bs.DataSource = _currentUser.UserPasswords.GetPasswordsImSharing();
            grdvwPasswordsTable.DataSource = bs;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            UnsharePasswordModal.onSharePassword -= LoadSharedPasswordsDataGrid;
            AddOrModifyPasswordModal.onModifyOrAddPassword -= LoadDataGridPasswords;
            base.OnHandleDestroyed(e);
        }

        private void BtnDeletePassword_Click(object sender, EventArgs e)
        {
            DialogResult dialogResultDeletePassword = MessageBox.Show("Are you sure you want to delete this password?", "Confirmation",
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResultDeletePassword == DialogResult.Yes)
            {
                _currentUser.UserPasswords.RemovePassword(_lastPasswordSelected);
                LoadDataGridPasswords();
            }
        }

        private void grdvwPasswordsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Form passwordMoreInfoModal = new PasswordMoreInfoModal(_lastPasswordSelected);
            passwordMoreInfoModal.ShowDialog();
        }

        private void BtnSharePassword_Click(object sender, EventArgs e)
        {
            Form sharePasswordModal = new SharePasswordModal(_userManager, _lastPasswordSelected);
            sharePasswordModal.ShowDialog();
        }

        private void btnShowUnshowSharedPasswords_Click(object sender, EventArgs e)
        {
            if (!btnUnshare.Visible)
            {
                LoadSharedPasswordsDataGrid();
                btnShowUnshowSharedPasswords.Text = "Show all passwords";
                btnUnshare.Visible =  true;
            }
            else
            {
                LoadDataGridPasswords();
                btnShowUnshowSharedPasswords.Text = "Show shared passwords";
                btnUnshare.Visible = false;
            }
            

        }

        private void btnUnshare_Click(object sender, EventArgs e)
        {
            Form unsharePasswordModal = new UnsharePasswordModal(_userManager,_lastPasswordSelected);
            unsharePasswordModal.ShowDialog();
        }
    }
}
