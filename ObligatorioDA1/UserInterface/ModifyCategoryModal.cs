﻿using System;
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
    public partial class ModifyCategoryModal : Form
    {
        public delegate void ModifiedCategoryEvent();
        public static event ModifiedCategoryEvent onModifyCategory;

        private User _currentUser;
        private Category _categoryToModify;

        public ModifyCategoryModal(User loggedUser, Category categoryToModify)
        {
            InitializeComponent();
            _currentUser = loggedUser;
            _categoryToModify = categoryToModify;
            txtbxNewCategoryName.Text = categoryToModify.Name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string categoryName = txtbxNewCategoryName.Text;
            try
            {
                Category newCategory = new Category(categoryName);
                _currentUser.ModifyCategory(_categoryToModify, newCategory);
                onModifyCategory?.Invoke();
                Close();
            }
            catch (UserException categoryException)
            {
                MessageBox.Show(categoryException.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}