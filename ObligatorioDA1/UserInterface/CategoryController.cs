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
    public partial class CategoryController : UserControl
    {
        private UserManager _userManager;
        private User _currentUser;

        public CategoryController(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
            _currentUser = _userManager.LoggedUser;
            AddCategoryModal.onAddedCategory += OnAddedCategory;
        }

        private void CategoryController_Load(object sender, EventArgs e)
        {
            LoadDataGridViewWithListOfCategories(_currentUser.Categories);
        }

        private void grdvwCategoryTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadDataGridViewWithListOfCategories(List<Category> categoryList)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = categoryList;
            grdvwCategoryTable.AutoGenerateColumns = false;
            grdvwCategoryTable.DataSource = bs;
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            Form newCategoryModal = new AddCategoryModal(_currentUser);
            newCategoryModal.StartPosition = FormStartPosition.CenterScreen;
            newCategoryModal.ShowDialog();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            AddCategoryModal.onAddedCategory -= OnAddedCategory;
        }

        private void OnAddedCategory()
        {
            LoadDataGridViewWithListOfCategories(_currentUser.Categories);
        }
    }
}
