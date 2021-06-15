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

        private User _currentUser;
        private Category _selectedCategory;

        public CategoryController()
        {
            InitializeComponent();

            _currentUser = UserManager.Instance.LoggedUser;
            SubscribeToEvents();
        }

        private void CategoryController_Load(object sender, EventArgs e)
        {
            LoadDataGridViewWithListOfCategories(_currentUser.UserCategories.Categories);
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            Form newCategoryModal = new AddCategoryModal();
            newCategoryModal.StartPosition = FormStartPosition.CenterScreen;
            newCategoryModal.ShowDialog();
        }

        private void btnModifyCategory_Click(object sender, EventArgs e)
        {
            Form newCategoryModal = new ModifyCategoryModal(_selectedCategory);
            newCategoryModal.StartPosition = FormStartPosition.CenterScreen;
            newCategoryModal.ShowDialog();
        }

        private void grdvwCategoryTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Category selectedRowCategory = (Category)grdvwCategoryTable.Rows[e.RowIndex].DataBoundItem;

            _selectedCategory = selectedRowCategory;
        }

        private void LoadDataGridViewWithListOfCategories(List<Category> categoryList)
        {
            List<Category> removedSharedCategory = FilterSharedWithUs(categoryList);

            DisableModifyButtonIfNoElements(removedSharedCategory);

            BindingSource bs = new BindingSource();
            bs.DataSource = removedSharedCategory;
            grdvwCategoryTable.AutoGenerateColumns = false;
            grdvwCategoryTable.DataSource = bs;
        }

        private void DisableModifyButtonIfNoElements(List<Category> categoryList)
        {
            if (categoryList.Count == 0)
            {
                btnModifyCategory.Enabled = false;
            }
            else
            {
                btnModifyCategory.Enabled = true;
            }
        }

        private List<Category> FilterSharedWithUs(List<Category> categories)
        {
            List<Category> filteredList = new List<Category>();

            foreach(Category category in categories)
            {
                if (!category.Equals(UserCategory.SHARED_WITH_ME_CATEGORY))
                {
                    filteredList.Add(category);
                }
            }

            return filteredList;
        }

        private void SubscribeToEvents()
        {
            AddCategoryModal.onAddedCategory += OnCategoryListChanged;
            ModifyCategoryModal.onModifyCategory += OnCategoryListChanged;
        }

        private void UnsubscribeToEvents()
        {
            AddCategoryModal.onAddedCategory -= OnCategoryListChanged;
            ModifyCategoryModal.onModifyCategory -= OnCategoryListChanged;
        }

        private void OnCategoryListChanged()
        {
            LoadDataGridViewWithListOfCategories(_currentUser.UserCategories.Categories);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            UnsubscribeToEvents();
        }
    }
}
