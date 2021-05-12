
namespace UserInterface
{
    partial class ChangePasswordModal
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
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblConfirmNewPassword = new System.Windows.Forms.Label();
            this.txtbxNewPassword = new System.Windows.Forms.TextBox();
            this.txtbxConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(35, 31);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(78, 13);
            this.lblNewPassword.TabIndex = 0;
            this.lblNewPassword.Text = "New Password";
            // 
            // lblConfirmNewPassword
            // 
            this.lblConfirmNewPassword.AutoSize = true;
            this.lblConfirmNewPassword.Location = new System.Drawing.Point(35, 94);
            this.lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            this.lblConfirmNewPassword.Size = new System.Drawing.Size(116, 13);
            this.lblConfirmNewPassword.TabIndex = 1;
            this.lblConfirmNewPassword.Text = "Confirm New Password";
            // 
            // txtbxNewPassword
            // 
            this.txtbxNewPassword.Location = new System.Drawing.Point(38, 47);
            this.txtbxNewPassword.Name = "txtbxNewPassword";
            this.txtbxNewPassword.PasswordChar = '*';
            this.txtbxNewPassword.Size = new System.Drawing.Size(242, 20);
            this.txtbxNewPassword.TabIndex = 2;
            // 
            // txtbxConfirmNewPassword
            // 
            this.txtbxConfirmNewPassword.Location = new System.Drawing.Point(38, 110);
            this.txtbxConfirmNewPassword.Name = "txtbxConfirmNewPassword";
            this.txtbxConfirmNewPassword.PasswordChar = '*';
            this.txtbxConfirmNewPassword.Size = new System.Drawing.Size(242, 20);
            this.txtbxConfirmNewPassword.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(56, 154);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(188, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ChangePasswordModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 191);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtbxConfirmNewPassword);
            this.Controls.Add(this.txtbxNewPassword);
            this.Controls.Add(this.lblConfirmNewPassword);
            this.Controls.Add(this.lblNewPassword);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 230);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 230);
            this.Name = "ChangePasswordModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblConfirmNewPassword;
        private System.Windows.Forms.TextBox txtbxNewPassword;
        private System.Windows.Forms.TextBox txtbxConfirmNewPassword;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}