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
using Domain.PasswordRecommender;

namespace UserInterface
{
    public partial class AddOrModifyPasswordModal : Form
    {
        public delegate void ModifiedPasswordEvent(List<Password> passwordList);
        public static event ModifiedPasswordEvent onModifyOrAddPassword;

        public delegate void ModifiedSinglePasswordEvent(Password theModifiedPassword);
        public static event ModifiedSinglePasswordEvent onModifySinglePassword;

        private User _currentUser;
        private Password _passwordToModify;
        private bool _modify;
        public AddOrModifyPasswordModal(Password passwordToModify)
        {
            InitializeComponent();
            PasswordGeneratorModal.onPasswordGeneration += UpdatePasswordTextBox;
            _currentUser = UserManager.Instance.LoggedUser;
            _passwordToModify = passwordToModify;
            _modify = (!(passwordToModify == null)); 

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = (Category) cmbBxCategory.SelectedItem;
            string site = txtBxSite.Text;
            string userName = txtBxUsername.Text;
            string passwordString = txtBxPassword.Text;
            string notes = txtBxNotes.Text;
            Password newPassword = new Password {
                Category = category,
                Site = site,
                PasswordString = passwordString,
                Username = userName,
                Notes = notes
            };

            try
            {
                if (_modify)
                {
                    newPassword.PasswordID = _passwordToModify.PasswordID;
                    _currentUser.UserPasswords.ModifyPassword(newPassword, _passwordToModify);
                }
                else
                {
                    _currentUser.UserPasswords.AddPassword(newPassword);
                }
                List<Password> passwordsList = _currentUser.UserPasswords.Passwords;
                onModifyOrAddPassword?.Invoke(passwordsList);
                onModifySinglePassword?.Invoke(newPassword);
                Close();
            }
            catch (PasswordExceptions exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddOrModifyPasswordModal_Load(object sender, EventArgs e)
        {
            if (!_modify)
            {
                this.Text = "Add a new Password";
            }
            else
            {
                this.Text = "Modify selected Password";
            }
            List<Category> bs = new List<Category>(_currentUser.UserCategories.Categories);
            bs.Remove(UserCategory.SHARED_WITH_ME_CATEGORY);
            cmbBxCategory.DataSource = bs;
            if (bs.Count == 0)
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }
            
            
            if (!(_passwordToModify == null))
            {
                cmbBxCategory.SelectedItem = _passwordToModify.Category;
                txtBxSite.Text = _passwordToModify.Site;
                txtBxUsername.Text = _passwordToModify.Username;
                txtBxPassword.Text = _passwordToModify.PasswordString;
                txtBxNotes.Text = _passwordToModify.Notes;
            }
            
        }

        private void UpdatePasswordTextBox(string passwordGenerated)
        {
            txtBxPassword.Text = passwordGenerated;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            PasswordGeneratorModal.onPasswordGeneration -= UpdatePasswordTextBox;
            base.OnHandleDestroyed(e);
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            Form passwordGeneratorModal = new PasswordGeneratorModal();
            passwordGeneratorModal.ShowDialog();
        }

        private void txtBxPassword_TextChanged(object sender, EventArgs e)
        {
            string passwordString = txtBxPassword.Text;
            SecurityCondition conditions = PasswordRecommender.isASafePassword(passwordString, _currentUser);
            if (conditions._isNotBreached)
            {
                lblIsBreached.Text = "This password hasn't been breached before";
            }
            else
            {
                lblIsBreached.Text = "This password has appeared in a data breach before";
            }

            if (conditions._isNotInUse)
            {
                lblAlreadyExists.Text = "This password hasn't been used before";
            }
            else
            {
                lblAlreadyExists.Text = "This password is already being used";
            }

            if (conditions._isNotLowSecurityLevel)
            {
                lblLowSecLevel.Text = "The password has a high security level";
            }
            else
            {
                
                lblLowSecLevel.Text = "This password security level is too low";
            }

        }
    }
}
