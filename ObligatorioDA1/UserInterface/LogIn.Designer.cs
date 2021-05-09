
namespace UserInterface
{
    partial class LogIn
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
            this.btnLogIn = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtbxUsername = new System.Windows.Forms.TextBox();
            this.txtbxPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(312, 300);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 23);
            this.btnLogIn.TabIndex = 0;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(250, 128);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(250, 209);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // txtbxUsername
            // 
            this.txtbxUsername.Location = new System.Drawing.Point(253, 163);
            this.txtbxUsername.Name = "txtbxUsername";
            this.txtbxUsername.Size = new System.Drawing.Size(198, 20);
            this.txtbxUsername.TabIndex = 3;
            // 
            // txtbxPassword
            // 
            this.txtbxPassword.Location = new System.Drawing.Point(253, 250);
            this.txtbxPassword.Name = "txtbxPassword";
            this.txtbxPassword.Size = new System.Drawing.Size(198, 20);
            this.txtbxPassword.TabIndex = 4;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtbxPassword);
            this.Controls.Add(this.txtbxUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnLogIn);
            this.Name = "LogIn";
            this.Size = new System.Drawing.Size(739, 458);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtbxUsername;
        private System.Windows.Forms.TextBox txtbxPassword;
    }
}
