
namespace UserInterface
{
    partial class SharePasswordModal
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
            this.cmbBxUsers = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblShareyourPassword = new System.Windows.Forms.Label();
            this.lblShareWith = new System.Windows.Forms.Label();
            this.btnShare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBxUsers
            // 
            this.cmbBxUsers.DataSource = this.userBindingSource;
            this.cmbBxUsers.DisplayMember = "Name";
            this.cmbBxUsers.FormattingEnabled = true;
            this.cmbBxUsers.Location = new System.Drawing.Point(107, 71);
            this.cmbBxUsers.Name = "cmbBxUsers";
            this.cmbBxUsers.Size = new System.Drawing.Size(211, 21);
            this.cmbBxUsers.TabIndex = 0;
            this.cmbBxUsers.ValueMember = "Name";
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(Domain.User);
            // 
            // lblShareyourPassword
            // 
            this.lblShareyourPassword.AutoSize = true;
            this.lblShareyourPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShareyourPassword.Location = new System.Drawing.Point(118, 23);
            this.lblShareyourPassword.Name = "lblShareyourPassword";
            this.lblShareyourPassword.Size = new System.Drawing.Size(188, 24);
            this.lblShareyourPassword.TabIndex = 1;
            this.lblShareyourPassword.Text = "Share your password";
            // 
            // lblShareWith
            // 
            this.lblShareWith.AutoSize = true;
            this.lblShareWith.Location = new System.Drawing.Point(31, 74);
            this.lblShareWith.Name = "lblShareWith";
            this.lblShareWith.Size = new System.Drawing.Size(60, 13);
            this.lblShareWith.TabIndex = 2;
            this.lblShareWith.Text = "Share with:";
            // 
            // btnShare
            // 
            this.btnShare.Location = new System.Drawing.Point(144, 134);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(126, 44);
            this.btnShare.TabIndex = 3;
            this.btnShare.Text = "Share";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // SharePasswordModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 232);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.lblShareWith);
            this.Controls.Add(this.lblShareyourPassword);
            this.Controls.Add(this.cmbBxUsers);
            this.Name = "SharePasswordModal";
            this.Text = "SharePasswordModal";
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBxUsers;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Label lblShareyourPassword;
        private System.Windows.Forms.Label lblShareWith;
        private System.Windows.Forms.Button btnShare;
    }
}