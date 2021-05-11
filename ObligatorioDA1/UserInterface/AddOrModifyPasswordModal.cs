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
    public partial class AddOrModifyPasswordModal : Form
    {
        public delegate void ModifiedPasswordEvent();
        public static event ModifiedPasswordEvent onModifyOrAddPassword;
        private User _currentUser;
        private Password _passwordToModify;
        private bool _modify;
        public AddOrModifyPasswordModal(User loggedUser, Password passwordToModify)
        {
            InitializeComponent();
            PasswordGeneratorModal.onPasswordGeneration += UpdatePasswordTextBox;
            _currentUser = loggedUser;
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
                    _currentUser.UserPasswords.ModifyPassword(newPassword, _passwordToModify);
                }
                else
                {
                    _currentUser.UserPasswords.AddPassword(newPassword);
                }
                List<Password> passwordsList = _currentUser.UserPasswords.Passwords;
                onModifyOrAddPassword?.Invoke();
                Close();
            }
            catch (PasswordExceptions exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddOrModifyPasswordModal_Load(object sender, EventArgs e)
        {
            List<Category> bs = _currentUser.Categories;
            bs.Remove(User.SHARED_WITH_ME_CATEGORY);
            cmbBxCategory.DataSource = bs;
            
            
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
    }
}
