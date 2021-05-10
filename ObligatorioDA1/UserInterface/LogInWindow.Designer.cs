
namespace UserInterface
{
    partial class LogInWindow
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
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtbxLogInUsername = new System.Windows.Forms.TextBox();
            this.txtbxLogInPassword = new System.Windows.Forms.TextBox();
            this.txtbxSignUpUsername = new System.Windows.Forms.TextBox();
            this.txtbxSignUpPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblSignUpUsername = new System.Windows.Forms.Label();
            this.lblSignUpPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblLogIn = new System.Windows.Forms.Label();
            this.lblSignUp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(82, 284);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 23);
            this.btnLogIn.TabIndex = 0;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(497, 339);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(75, 23);
            this.btnSignUp.TabIndex = 1;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(77, 117);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(79, 201);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // txtbxLogInUsername
            // 
            this.txtbxLogInUsername.Location = new System.Drawing.Point(80, 152);
            this.txtbxLogInUsername.Name = "txtbxLogInUsername";
            this.txtbxLogInUsername.Size = new System.Drawing.Size(210, 20);
            this.txtbxLogInUsername.TabIndex = 4;
            // 
            // txtbxLogInPassword
            // 
            this.txtbxLogInPassword.Location = new System.Drawing.Point(82, 233);
            this.txtbxLogInPassword.Name = "txtbxLogInPassword";
            this.txtbxLogInPassword.PasswordChar = '*';
            this.txtbxLogInPassword.Size = new System.Drawing.Size(210, 20);
            this.txtbxLogInPassword.TabIndex = 5;
            // 
            // txtbxSignUpUsername
            // 
            this.txtbxSignUpUsername.Location = new System.Drawing.Point(499, 152);
            this.txtbxSignUpUsername.Name = "txtbxSignUpUsername";
            this.txtbxSignUpUsername.Size = new System.Drawing.Size(210, 20);
            this.txtbxSignUpUsername.TabIndex = 7;
            // 
            // txtbxSignUpPassword
            // 
            this.txtbxSignUpPassword.Location = new System.Drawing.Point(497, 233);
            this.txtbxSignUpPassword.Name = "txtbxSignUpPassword";
            this.txtbxSignUpPassword.PasswordChar = '*';
            this.txtbxSignUpPassword.Size = new System.Drawing.Size(210, 20);
            this.txtbxSignUpPassword.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(404, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 407);
            this.label1.TabIndex = 9;
            // 
            // txtbxConfirmPassword
            // 
            this.txtbxConfirmPassword.Location = new System.Drawing.Point(497, 284);
            this.txtbxConfirmPassword.Name = "txtbxConfirmPassword";
            this.txtbxConfirmPassword.PasswordChar = '*';
            this.txtbxConfirmPassword.Size = new System.Drawing.Size(210, 20);
            this.txtbxConfirmPassword.TabIndex = 10;
            // 
            // lblSignUpUsername
            // 
            this.lblSignUpUsername.AutoSize = true;
            this.lblSignUpUsername.Location = new System.Drawing.Point(494, 117);
            this.lblSignUpUsername.Name = "lblSignUpUsername";
            this.lblSignUpUsername.Size = new System.Drawing.Size(55, 13);
            this.lblSignUpUsername.TabIndex = 11;
            this.lblSignUpUsername.Text = "Username";
            // 
            // lblSignUpPassword
            // 
            this.lblSignUpPassword.AutoSize = true;
            this.lblSignUpPassword.Location = new System.Drawing.Point(496, 201);
            this.lblSignUpPassword.Name = "lblSignUpPassword";
            this.lblSignUpPassword.Size = new System.Drawing.Size(53, 13);
            this.lblSignUpPassword.TabIndex = 12;
            this.lblSignUpPassword.Text = "Password";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(496, 256);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(91, 13);
            this.lblConfirmPassword.TabIndex = 13;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // lblLogIn
            // 
            this.lblLogIn.AutoSize = true;
            this.lblLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogIn.Location = new System.Drawing.Point(43, 46);
            this.lblLogIn.Name = "lblLogIn";
            this.lblLogIn.Size = new System.Drawing.Size(89, 31);
            this.lblLogIn.TabIndex = 14;
            this.lblLogIn.Text = "Log In";
            // 
            // lblSignUp
            // 
            this.lblSignUp.AutoSize = true;
            this.lblSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignUp.Location = new System.Drawing.Point(439, 46);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(110, 31);
            this.lblSignUp.TabIndex = 15;
            this.lblSignUp.Text = "Sign Up";
            // 
            // LogInWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lblSignUp);
            this.Controls.Add(this.lblLogIn);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblSignUpPassword);
            this.Controls.Add(this.lblSignUpUsername);
            this.Controls.Add(this.txtbxConfirmPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbxSignUpPassword);
            this.Controls.Add(this.txtbxSignUpUsername);
            this.Controls.Add(this.txtbxLogInPassword);
            this.Controls.Add(this.txtbxLogInUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnLogIn);
            this.Name = "LogInWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogInWindow_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtbxLogInUsername;
        private System.Windows.Forms.TextBox txtbxLogInPassword;
        private System.Windows.Forms.TextBox txtbxSignUpUsername;
        private System.Windows.Forms.TextBox txtbxSignUpPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxConfirmPassword;
        private System.Windows.Forms.Label lblSignUpUsername;
        private System.Windows.Forms.Label lblSignUpPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblLogIn;
        private System.Windows.Forms.Label lblSignUp;
    }
}

