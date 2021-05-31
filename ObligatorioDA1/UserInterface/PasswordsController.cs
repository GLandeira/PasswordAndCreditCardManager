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
        private const string NO_CATEGORIES = "Add a Category to add a Password.";

        private UserManager _userManager;
        private User _currentUser;
        private Password _lastPasswordSelected;

        public PasswordsController(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
            _currentUser = _userManager.LoggedUser;
            EnableButtonsIfNoPasswords(false);
            AddOrModifyPasswordModal.onModifyOrAddPassword += LoadDataGridPasswords;
            UnsharePasswordModal.onSharePassword += LoadDataGridPasswords;
        }

        private void PasswordsController_Load(object sender, EventArgs e)
        {
            DisableAddButtonIfNoCategoriesAdded(_currentUser.Categories);

            List<Password> passwordList = _currentUser.UserPasswords.Passwords;
            LoadDataGridPasswords(passwordList);
        }

        private void grdvwPasswordsTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Password selectedPassword = (Password) grdvwPasswordsTable.Rows[e.RowIndex].DataBoundItem;
            _lastPasswordSelected = selectedPassword;
            if(_lastPasswordSelected.Category == User.SHARED_WITH_ME_CATEGORY)
            {
                EnableButtonsIfNoPasswords(false);
            }
            else
            {
                EnableButtonsIfNoPasswords(true);
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            UnsharePasswordModal.onSharePassword -= LoadDataGridPasswords;
            AddOrModifyPasswordModal.onModifyOrAddPassword -= LoadDataGridPasswords;
            base.OnHandleDestroyed(e);
        }

        private void grdvwPasswordsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(_lastPasswordSelected != null)
            {
                Form passwordMoreInfoModal = new PasswordMoreInfoModal(_lastPasswordSelected);
                passwordMoreInfoModal.ShowDialog();
            }
        }

        private void btnShowUnshowSharedPasswords_Click(object sender, EventArgs e)
        {
            DisableAddButtonIfNoCategoriesAdded(_currentUser.Categories);
            _lastPasswordSelected = null;

            if (!btnUnshare.Visible)
            {
                List<Password> sharedPasswordsList = _currentUser.UserPasswords.GetPasswordsImSharing();
                LoadDataGridPasswords(sharedPasswordsList);

                SetSharePasswordsEnvironment(true, "Show all passwords");
            }
            else
            {
                List<Password> passwordsList = _currentUser.UserPasswords.Passwords;
                LoadDataGridPasswords(passwordsList);

                SetSharePasswordsEnvironment(false, "Show shared passwords");
            }
        }

        private void btnUnshare_Click(object sender, EventArgs e)
        {
            Form unsharePasswordModal = new UnsharePasswordModal(_userManager,_lastPasswordSelected);
            unsharePasswordModal.ShowDialog();
        }

        private void btnNewPassword_Click(object sender, EventArgs e)
        {
            Form addOrModifyPasswordModal = new AddOrModifyPasswordModal(_currentUser, null);
            addOrModifyPasswordModal.ShowDialog();
        }

        private void btnSharePassword_Click(object sender, EventArgs e)
        {
            Form sharePasswordModal = new SharePasswordModal(_userManager, _lastPasswordSelected);
            sharePasswordModal.ShowDialog();
        }

        private void btnDeletePassword_Click(object sender, EventArgs e)
        {
            DialogResult dialogResultDeletePassword = MessageBox.Show("Are you sure you want to delete this password?", "Confirmation",
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResultDeletePassword == DialogResult.Yes)
            {
                _currentUser.UserPasswords.RemovePassword(_lastPasswordSelected);
                LoadDataGridPasswords(_currentUser.UserPasswords.Passwords);
            }
        }

        private void btnModifyPassword_Click(object sender, EventArgs e)
        {
            Form addOrModifyPasswordModal = new AddOrModifyPasswordModal(_currentUser, _lastPasswordSelected);
            addOrModifyPasswordModal.ShowDialog();
        }

        private void LoadDataGridPasswords(List<Password> passwordList)
        {
            grdvwPasswordsTable.DataSource = null;
            BindingSource bs = new BindingSource();
            List<Password> sortedPasswordList = passwordList.OrderBy(p => p.Category.Name.ToUpper()).ToList();
            bs.DataSource = sortedPasswordList;

            if (sortedPasswordList.Count == 0)
            {
                EnableButtonsIfNoPasswords(false);
            }
            else
            {
                
                EnableButtonsIfNoPasswords(true);
            }

            grdvwPasswordsTable.DataSource = bs;
        }

        private void DisableAddButtonIfNoCategoriesAdded(List<Category> categories)
        {
            int categoryCountWithoutSharedWithme = categories.Count - 1;
            if (categoryCountWithoutSharedWithme <= 0)
            {
                btnNewPassword.Enabled = false;

                MessageBox.Show(NO_CATEGORIES, "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EnableButtonsIfNoPasswords(bool enabled)
        {
            btnModifyPassword.Enabled = enabled;
            btnDeletePassword.Enabled = enabled;
            btnSharePassword.Enabled = enabled;
            btnUnshare.Enabled = enabled;
        }

        private void SetSharePasswordsEnvironment(bool visibility, string text)
        {
            btnUnshare.Visible = visibility;
            btnSharePassword.Visible = !visibility;
            btnNewPassword.Enabled = !visibility;
            btnShowUnshowSharedPasswords.Text = text;
        }
    }
}
