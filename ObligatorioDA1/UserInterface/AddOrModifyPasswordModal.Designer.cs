
namespace UserInterface
{
    partial class AddOrModifyPasswordModal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblSite = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtBxSite = new System.Windows.Forms.TextBox();
            this.txtBxUsername = new System.Windows.Forms.TextBox();
            this.txtBxPassword = new System.Windows.Forms.TextBox();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtBxNotes = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbBxCategory = new System.Windows.Forms.ComboBox();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(75, 41);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(99, 25);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category";
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSite.Location = new System.Drawing.Point(75, 87);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(49, 25);
            this.lblSite.TabIndex = 1;
            this.lblSite.Text = "Site";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(75, 135);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(110, 25);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(75, 179);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(106, 25);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // txtBxSite
            // 
            this.txtBxSite.Location = new System.Drawing.Point(204, 92);
            this.txtBxSite.Name = "txtBxSite";
            this.txtBxSite.Size = new System.Drawing.Size(228, 20);
            this.txtBxSite.TabIndex = 5;
            // 
            // txtBxUsername
            // 
            this.txtBxUsername.Location = new System.Drawing.Point(204, 140);
            this.txtBxUsername.Name = "txtBxUsername";
            this.txtBxUsername.Size = new System.Drawing.Size(228, 20);
            this.txtBxUsername.TabIndex = 6;
            // 
            // txtBxPassword
            // 
            this.txtBxPassword.Location = new System.Drawing.Point(204, 184);
            this.txtBxPassword.Name = "txtBxPassword";
            this.txtBxPassword.Size = new System.Drawing.Size(228, 20);
            this.txtBxPassword.TabIndex = 7;
            // 
            // btnGeneratePassword
            // 
            this.btnGeneratePassword.Location = new System.Drawing.Point(452, 185);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(122, 19);
            this.btnGeneratePassword.TabIndex = 8;
            this.btnGeneratePassword.Text = "Generate";
            this.btnGeneratePassword.UseVisualStyleBackColor = true;
            this.btnGeneratePassword.Click += new System.EventHandler(this.btnGeneratePassword_Click);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(163, 245);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(68, 25);
            this.lblNotes.TabIndex = 9;
            this.lblNotes.Text = "Notes";
            // 
            // txtBxNotes
            // 
            this.txtBxNotes.Location = new System.Drawing.Point(168, 273);
            this.txtBxNotes.Multiline = true;
            this.txtBxNotes.Name = "txtBxNotes";
            this.txtBxNotes.Size = new System.Drawing.Size(284, 100);
            this.txtBxNotes.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(232, 379);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(159, 40);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Confirm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbBxCategory
            // 
            this.cmbBxCategory.DataSource = this.categoryBindingSource;
            this.cmbBxCategory.DisplayMember = "Name";
            this.cmbBxCategory.FormattingEnabled = true;
            this.cmbBxCategory.Location = new System.Drawing.Point(205, 47);
            this.cmbBxCategory.Name = "cmbBxCategory";
            this.cmbBxCategory.Size = new System.Drawing.Size(226, 21);
            this.cmbBxCategory.TabIndex = 12;
            this.cmbBxCategory.ValueMember = "Name";
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(Domain.Category);
            // 
            // AddOrModifyPasswordModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbBxCategory);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtBxNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.btnGeneratePassword);
            this.Controls.Add(this.txtBxPassword);
            this.Controls.Add(this.txtBxUsername);
            this.Controls.Add(this.txtBxSite);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.lblCategory);
            this.Name = "AddOrModifyPasswordModal";
            this.Text = "AddOrModifyPasswordModal";
            this.Load += new System.EventHandler(this.AddOrModifyPasswordModal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtBxSite;
        private System.Windows.Forms.TextBox txtBxUsername;
        private System.Windows.Forms.TextBox txtBxPassword;
        private System.Windows.Forms.Button btnGeneratePassword;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtBxNotes;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbBxCategory;
        private System.Windows.Forms.BindingSource categoryBindingSource;
    }
}