
namespace UserInterface
{
    partial class UnsharePasswordModal
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
            this.lblShareyourPassword = new System.Windows.Forms.Label();
            this.btnUnshare = new System.Windows.Forms.Button();
            this.lblUnshareWith = new System.Windows.Forms.Label();
            this.cmbBxUsers = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblShareyourPassword
            // 
            this.lblShareyourPassword.AutoSize = true;
            this.lblShareyourPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShareyourPassword.Location = new System.Drawing.Point(96, 23);
            this.lblShareyourPassword.Name = "lblShareyourPassword";
            this.lblShareyourPassword.Size = new System.Drawing.Size(243, 24);
            this.lblShareyourPassword.TabIndex = 2;
            this.lblShareyourPassword.Text = "Stop sharing your password";
            // 
            // btnUnshare
            // 
            this.btnUnshare.Location = new System.Drawing.Point(146, 137);
            this.btnUnshare.Name = "btnUnshare";
            this.btnUnshare.Size = new System.Drawing.Size(126, 44);
            this.btnUnshare.TabIndex = 6;
            this.btnUnshare.Text = "Unshare";
            this.btnUnshare.UseVisualStyleBackColor = true;
            this.btnUnshare.Click += new System.EventHandler(this.btnUnshare_Click);
            // 
            // lblUnshareWith
            // 
            this.lblUnshareWith.AutoSize = true;
            this.lblUnshareWith.Location = new System.Drawing.Point(31, 77);
            this.lblUnshareWith.Name = "lblUnshareWith";
            this.lblUnshareWith.Size = new System.Drawing.Size(72, 13);
            this.lblUnshareWith.TabIndex = 5;
            this.lblUnshareWith.Text = "Unshare with:";
            // 
            // cmbBxUsers
            // 
            this.cmbBxUsers.DataSource = this.userBindingSource;
            this.cmbBxUsers.DisplayMember = "Name";
            this.cmbBxUsers.FormattingEnabled = true;
            this.cmbBxUsers.Location = new System.Drawing.Point(109, 74);
            this.cmbBxUsers.Name = "cmbBxUsers";
            this.cmbBxUsers.Size = new System.Drawing.Size(211, 21);
            this.cmbBxUsers.TabIndex = 4;
            this.cmbBxUsers.ValueMember = "Name";
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(Domain.User);
            // 
            // UnsharePasswordModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 232);
            this.Controls.Add(this.btnUnshare);
            this.Controls.Add(this.lblUnshareWith);
            this.Controls.Add(this.cmbBxUsers);
            this.Controls.Add(this.lblShareyourPassword);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(447, 271);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(447, 271);
            this.Name = "UnsharePasswordModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stop sharing your password";
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblShareyourPassword;
        private System.Windows.Forms.Button btnUnshare;
        private System.Windows.Forms.Label lblUnshareWith;
        private System.Windows.Forms.ComboBox cmbBxUsers;
        private System.Windows.Forms.BindingSource userBindingSource;
    }
}