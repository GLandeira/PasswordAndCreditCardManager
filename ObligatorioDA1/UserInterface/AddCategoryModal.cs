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
        private User _currentUser;

        public AddCategoryModal(User loggedUser)
        {
            InitializeComponent();
            _currentUser = loggedUser;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string categoryName = txtbxCategoryName.Text;
            try
            {
                Category newCategory = new Category(categoryName);
                _currentUser.AddCategory(newCategory);
            }
            catch(NameCategoryException categoryException)
            {
                MessageBox.Show(categoryException.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
