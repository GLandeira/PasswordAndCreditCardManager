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
    public partial class AddCategoryModal : Form
    {
        public delegate void AddedCategoryEvent();
        public static event AddedCategoryEvent onAddedCategory;

        private User _currentUser;

        public AddCategoryModal()
        {
            InitializeComponent();
            _currentUser = UserManager.Instance.LoggedUser;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string categoryName = txtbxCategoryName.Text;
            try
            {
                Category newCategory = new Category(categoryName);
                Verifier.VerifyCategory(newCategory);
                _currentUser.UserCategories.AddCategory(newCategory);
                onAddedCategory?.Invoke();
                Close();
            }
            catch(UserException categoryException)
            {
                MessageBox.Show(categoryException.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
