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
using Domain.PasswordSecurityFlagger;

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
            ButtonsEnabler(false);
            AddOrModifyPasswordModal.onModifyOrAddPassword += LoadDataGridPasswords;
            UnsharePasswordModal.onSharePassword += LoadDataGridPasswords;
        }

        private void PasswordsController_Load(object sender, EventArgs e)
        {
            List<Password> passwordList = _currentUser.UserPasswords.Passwords;
            LoadDataGridPasswords(passwordList);

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
                ButtonsEnabler(false);
            }
            else
            {
                ButtonsEnabler(true);
            }
        }

        private void ButtonsEnabler(bool enabled)
        {
            BtnModifyPassword.Enabled = enabled;
            BtnDeletePassword.Enabled = enabled;
            BtnSharePassword.Enabled = enabled;
        }

        private void LoadDataGridPasswords(List<Password> passwordList)
        {
            grdvwPasswordsTable.DataSource = null;
            BindingSource bs = new BindingSource();
            List<Password> sortedPasswordList = passwordList.OrderBy(p => p.Category.Name.ToUpper()).ToList();
            bs.DataSource = sortedPasswordList;
            if (sortedPasswordList.Count == 0)
            {
               ButtonsEnabler(false);
            }
            else
            {
               ButtonsEnabler(true);
            }
            grdvwPasswordsTable.DataSource = bs;


        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            UnsharePasswordModal.onSharePassword -= LoadDataGridPasswords;
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
                LoadDataGridPasswords(_currentUser.UserPasswords.Passwords);
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
                List<Password> sharedPasswordsList = _currentUser.UserPasswords.GetPasswordsImSharing();
                LoadDataGridPasswords(sharedPasswordsList);
                btnShowUnshowSharedPasswords.Text = "Show all passwords";
                btnUnshare.Visible =  true;

            }
            else
            {
                List<Password> passwordsList = _currentUser.UserPasswords.Passwords;
                LoadDataGridPasswords(passwordsList);
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
