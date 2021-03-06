
namespace UserInterface
{
    partial class CategoryController
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCategoryTitle = new System.Windows.Forms.Label();
            this.grdvwCategoryTable = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnNewCategory = new System.Windows.Forms.Button();
            this.btnModifyCategory = new System.Windows.Forms.Button();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdvwCategoryTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCategoryTitle
            // 
            this.lblCategoryTitle.AutoSize = true;
            this.lblCategoryTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryTitle.Location = new System.Drawing.Point(41, 46);
            this.lblCategoryTitle.Name = "lblCategoryTitle";
            this.lblCategoryTitle.Size = new System.Drawing.Size(267, 39);
            this.lblCategoryTitle.TabIndex = 3;
            this.lblCategoryTitle.Text = "Your Categories";
            // 
            // grdvwCategoryTable
            // 
            this.grdvwCategoryTable.AllowUserToAddRows = false;
            this.grdvwCategoryTable.AllowUserToDeleteRows = false;
            this.grdvwCategoryTable.AutoGenerateColumns = false;
            this.grdvwCategoryTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdvwCategoryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdvwCategoryTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.grdvwCategoryTable.DataSource = this.categoryBindingSource;
            this.grdvwCategoryTable.Location = new System.Drawing.Point(50, 125);
            this.grdvwCategoryTable.Name = "grdvwCategoryTable";
            this.grdvwCategoryTable.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdvwCategoryTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdvwCategoryTable.Size = new System.Drawing.Size(800, 435);
            this.grdvwCategoryTable.TabIndex = 0;
            this.grdvwCategoryTable.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdvwCategoryTable_CellEnter);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 757;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(Domain.Category);
            // 
            // btnNewCategory
            // 
            this.btnNewCategory.Location = new System.Drawing.Point(142, 590);
            this.btnNewCategory.Name = "btnNewCategory";
            this.btnNewCategory.Size = new System.Drawing.Size(166, 40);
            this.btnNewCategory.TabIndex = 4;
            this.btnNewCategory.Text = "New";
            this.btnNewCategory.UseVisualStyleBackColor = true;
            this.btnNewCategory.Click += new System.EventHandler(this.btnNewCategory_Click);
            // 
            // btnModifyCategory
            // 
            this.btnModifyCategory.Location = new System.Drawing.Point(587, 590);
            this.btnModifyCategory.Name = "btnModifyCategory";
            this.btnModifyCategory.Size = new System.Drawing.Size(166, 40);
            this.btnModifyCategory.TabIndex = 6;
            this.btnModifyCategory.Text = "Modify";
            this.btnModifyCategory.UseVisualStyleBackColor = true;
            this.btnModifyCategory.Click += new System.EventHandler(this.btnModifyCategory_Click);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(Domain.User);
            // 
            // CategoryController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnModifyCategory);
            this.Controls.Add(this.btnNewCategory);
            this.Controls.Add(this.grdvwCategoryTable);
            this.Controls.Add(this.lblCategoryTitle);
            this.Name = "CategoryController";
            this.Size = new System.Drawing.Size(904, 656);
            this.Load += new System.EventHandler(this.CategoryController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdvwCategoryTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCategoryTitle;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.DataGridView grdvwCategoryTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnNewCategory;
        private System.Windows.Forms.Button btnModifyCategory;
    }
}
