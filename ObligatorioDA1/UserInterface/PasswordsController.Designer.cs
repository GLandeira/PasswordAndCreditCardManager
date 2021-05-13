
namespace UserInterface
{
    partial class PasswordsController
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
            this.label1 = new System.Windows.Forms.Label();
            this.grdvwPasswordsTable = new System.Windows.Forms.DataGridView();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModificationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.securityLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PasswordString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnNewPassword = new System.Windows.Forms.Button();
            this.btnDeletePassword = new System.Windows.Forms.Button();
            this.btnModifyPassword = new System.Windows.Forms.Button();
            this.btnSharePassword = new System.Windows.Forms.Button();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnShowUnshowSharedPasswords = new System.Windows.Forms.Button();
            this.btnUnshare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdvwPasswordsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your passwords";
            // 
            // grdvwPasswordsTable
            // 
            this.grdvwPasswordsTable.AllowUserToAddRows = false;
            this.grdvwPasswordsTable.AllowUserToDeleteRows = false;
            this.grdvwPasswordsTable.AutoGenerateColumns = false;
            this.grdvwPasswordsTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdvwPasswordsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdvwPasswordsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryDataGridViewTextBoxColumn,
            this.siteDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn,
            this.lastModificationDataGridViewTextBoxColumn,
            this.securityLevelDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn,
            this.PasswordString});
            this.grdvwPasswordsTable.DataSource = this.passwordBindingSource;
            this.grdvwPasswordsTable.Location = new System.Drawing.Point(112, 108);
            this.grdvwPasswordsTable.Name = "grdvwPasswordsTable";
            this.grdvwPasswordsTable.ReadOnly = true;
            this.grdvwPasswordsTable.RowTemplate.ReadOnly = true;
            this.grdvwPasswordsTable.Size = new System.Drawing.Size(645, 427);
            this.grdvwPasswordsTable.TabIndex = 1;
            this.grdvwPasswordsTable.VirtualMode = true;
            this.grdvwPasswordsTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdvwPasswordsTable_CellDoubleClick);
            this.grdvwPasswordsTable.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdvwPasswordsTable_CellEnter);
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // siteDataGridViewTextBoxColumn
            // 
            this.siteDataGridViewTextBoxColumn.DataPropertyName = "Site";
            this.siteDataGridViewTextBoxColumn.HeaderText = "Site";
            this.siteDataGridViewTextBoxColumn.Name = "siteDataGridViewTextBoxColumn";
            this.siteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastModificationDataGridViewTextBoxColumn
            // 
            this.lastModificationDataGridViewTextBoxColumn.DataPropertyName = "LastModification";
            this.lastModificationDataGridViewTextBoxColumn.HeaderText = "LastModification";
            this.lastModificationDataGridViewTextBoxColumn.Name = "lastModificationDataGridViewTextBoxColumn";
            this.lastModificationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // securityLevelDataGridViewTextBoxColumn
            // 
            this.securityLevelDataGridViewTextBoxColumn.DataPropertyName = "SecurityLevel";
            this.securityLevelDataGridViewTextBoxColumn.HeaderText = "SecurityLevel";
            this.securityLevelDataGridViewTextBoxColumn.Name = "securityLevelDataGridViewTextBoxColumn";
            this.securityLevelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PasswordString
            // 
            this.PasswordString.DataPropertyName = "PasswordString";
            dataGridViewCellStyle1.NullValue = null;
            this.PasswordString.DefaultCellStyle = dataGridViewCellStyle1;
            this.PasswordString.HeaderText = "PasswordString";
            this.PasswordString.Name = "PasswordString";
            this.PasswordString.ReadOnly = true;
            this.PasswordString.Visible = false;
            // 
            // passwordBindingSource
            // 
            this.passwordBindingSource.DataSource = typeof(Domain.Password);
            // 
            // btnNewPassword
            // 
            this.btnNewPassword.Location = new System.Drawing.Point(67, 582);
            this.btnNewPassword.Name = "btnNewPassword";
            this.btnNewPassword.Size = new System.Drawing.Size(158, 46);
            this.btnNewPassword.TabIndex = 2;
            this.btnNewPassword.Text = "New";
            this.btnNewPassword.UseVisualStyleBackColor = true;
            this.btnNewPassword.Click += new System.EventHandler(this.btnNewPassword_Click);
            // 
            // btnDeletePassword
            // 
            this.btnDeletePassword.Location = new System.Drawing.Point(259, 582);
            this.btnDeletePassword.Name = "btnDeletePassword";
            this.btnDeletePassword.Size = new System.Drawing.Size(158, 46);
            this.btnDeletePassword.TabIndex = 3;
            this.btnDeletePassword.Text = "Delete";
            this.btnDeletePassword.UseVisualStyleBackColor = true;
            this.btnDeletePassword.Click += new System.EventHandler(this.btnDeletePassword_Click);
            // 
            // btnModifyPassword
            // 
            this.btnModifyPassword.Location = new System.Drawing.Point(455, 582);
            this.btnModifyPassword.Name = "btnModifyPassword";
            this.btnModifyPassword.Size = new System.Drawing.Size(158, 46);
            this.btnModifyPassword.TabIndex = 4;
            this.btnModifyPassword.Text = "Modify";
            this.btnModifyPassword.UseVisualStyleBackColor = true;
            this.btnModifyPassword.Click += new System.EventHandler(this.btnModifyPassword_Click);
            // 
            // btnSharePassword
            // 
            this.btnSharePassword.Location = new System.Drawing.Point(649, 582);
            this.btnSharePassword.Name = "btnSharePassword";
            this.btnSharePassword.Size = new System.Drawing.Size(158, 46);
            this.btnSharePassword.TabIndex = 5;
            this.btnSharePassword.Text = "Share";
            this.btnSharePassword.UseVisualStyleBackColor = true;
            this.btnSharePassword.Click += new System.EventHandler(this.btnSharePassword_Click);
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(Domain.Category);
            // 
            // btnShowUnshowSharedPasswords
            // 
            this.btnShowUnshowSharedPasswords.Location = new System.Drawing.Point(599, 541);
            this.btnShowUnshowSharedPasswords.Name = "btnShowUnshowSharedPasswords";
            this.btnShowUnshowSharedPasswords.Size = new System.Drawing.Size(158, 22);
            this.btnShowUnshowSharedPasswords.TabIndex = 6;
            this.btnShowUnshowSharedPasswords.Text = "Show my shared passwords";
            this.btnShowUnshowSharedPasswords.UseVisualStyleBackColor = true;
            this.btnShowUnshowSharedPasswords.Click += new System.EventHandler(this.btnShowUnshowSharedPasswords_Click);
            // 
            // btnUnshare
            // 
            this.btnUnshare.Location = new System.Drawing.Point(763, 543);
            this.btnUnshare.Name = "btnUnshare";
            this.btnUnshare.Size = new System.Drawing.Size(92, 19);
            this.btnUnshare.TabIndex = 7;
            this.btnUnshare.Text = "unshare";
            this.btnUnshare.UseVisualStyleBackColor = true;
            this.btnUnshare.Visible = false;
            this.btnUnshare.Click += new System.EventHandler(this.btnUnshare_Click);
            // 
            // PasswordsController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUnshare);
            this.Controls.Add(this.btnShowUnshowSharedPasswords);
            this.Controls.Add(this.btnSharePassword);
            this.Controls.Add(this.btnModifyPassword);
            this.Controls.Add(this.btnDeletePassword);
            this.Controls.Add(this.btnNewPassword);
            this.Controls.Add(this.grdvwPasswordsTable);
            this.Controls.Add(this.label1);
            this.Name = "PasswordsController";
            this.Size = new System.Drawing.Size(904, 656);
            this.Load += new System.EventHandler(this.PasswordsController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdvwPasswordsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource passwordBindingSource;
        private System.Windows.Forms.Button btnNewPassword;
        private System.Windows.Forms.Button btnDeletePassword;
        private System.Windows.Forms.Button btnModifyPassword;
        private System.Windows.Forms.Button btnSharePassword;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.DataGridView grdvwPasswordsTable;
        private System.Windows.Forms.Button btnShowUnshowSharedPasswords;
        private System.Windows.Forms.Button btnUnshare;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModificationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn securityLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PasswordString;
    }
}
