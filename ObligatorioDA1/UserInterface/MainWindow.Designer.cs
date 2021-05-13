
namespace UserInterface
{
    partial class MainWindow
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
            this.btnCategory = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnPasswords = new System.Windows.Forms.Button();
            this.btnCreditCard = new System.Windows.Forms.Button();
            this.btnSecurityReport = new System.Windows.Forms.Button();
            this.btnDataBreaches = new System.Windows.Forms.Button();
            this.lblLogOut = new System.Windows.Forms.Label();
            this.lblChangePassword = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCategory
            // 
            this.btnCategory.Location = new System.Drawing.Point(39, 142);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(195, 52);
            this.btnCategory.TabIndex = 0;
            this.btnCategory.Text = "Categories";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(292, 6);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(904, 656);
            this.pnlMain.TabIndex = 1;
            // 
            // btnPasswords
            // 
            this.btnPasswords.Location = new System.Drawing.Point(39, 244);
            this.btnPasswords.Name = "btnPasswords";
            this.btnPasswords.Size = new System.Drawing.Size(195, 52);
            this.btnPasswords.TabIndex = 2;
            this.btnPasswords.Text = "Passwords";
            this.btnPasswords.UseVisualStyleBackColor = true;
            this.btnPasswords.Click += new System.EventHandler(this.btnPasswords_Click);
            // 
            // btnCreditCard
            // 
            this.btnCreditCard.Location = new System.Drawing.Point(39, 355);
            this.btnCreditCard.Name = "btnCreditCard";
            this.btnCreditCard.Size = new System.Drawing.Size(195, 52);
            this.btnCreditCard.TabIndex = 3;
            this.btnCreditCard.Text = "Credit Cards";
            this.btnCreditCard.UseVisualStyleBackColor = true;
            this.btnCreditCard.Click += new System.EventHandler(this.btnCreditCard_Click);
            // 
            // btnSecurityReport
            // 
            this.btnSecurityReport.Location = new System.Drawing.Point(39, 472);
            this.btnSecurityReport.Name = "btnSecurityReport";
            this.btnSecurityReport.Size = new System.Drawing.Size(195, 52);
            this.btnSecurityReport.TabIndex = 4;
            this.btnSecurityReport.Text = "Security Report";
            this.btnSecurityReport.UseVisualStyleBackColor = true;
            this.btnSecurityReport.Click += new System.EventHandler(this.btnSecurityReport_Click);
            // 
            // btnDataBreaches
            // 
            this.btnDataBreaches.Location = new System.Drawing.Point(39, 579);
            this.btnDataBreaches.Name = "btnDataBreaches";
            this.btnDataBreaches.Size = new System.Drawing.Size(195, 52);
            this.btnDataBreaches.TabIndex = 5;
            this.btnDataBreaches.Text = "Data Breaches";
            this.btnDataBreaches.UseVisualStyleBackColor = true;
            this.btnDataBreaches.Click += new System.EventHandler(this.btnDataBreaches_Click);
            // 
            // lblLogOut
            // 
            this.lblLogOut.AutoSize = true;
            this.lblLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogOut.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLogOut.Location = new System.Drawing.Point(12, 87);
            this.lblLogOut.Name = "lblLogOut";
            this.lblLogOut.Size = new System.Drawing.Size(82, 25);
            this.lblLogOut.TabIndex = 6;
            this.lblLogOut.Text = "Log Out";
            this.lblLogOut.Click += new System.EventHandler(this.lblLogOut_Click);
            // 
            // lblChangePassword
            // 
            this.lblChangePassword.AutoSize = true;
            this.lblChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangePassword.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblChangePassword.Location = new System.Drawing.Point(12, 58);
            this.lblChangePassword.Name = "lblChangePassword";
            this.lblChangePassword.Size = new System.Drawing.Size(173, 25);
            this.lblChangePassword.TabIndex = 7;
            this.lblChangePassword.Text = "Change Password";
            this.lblChangePassword.Click += new System.EventHandler(this.lblChangePassword_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblWelcome.Location = new System.Drawing.Point(12, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(213, 31);
            this.lblWelcome.TabIndex = 8;
            this.lblWelcome.Text = "Welcome Name!";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 668);
            this.Controls.Add(this.lblLogOut);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblChangePassword);
            this.Controls.Add(this.btnDataBreaches);
            this.Controls.Add(this.btnSecurityReport);
            this.Controls.Add(this.btnCreditCard);
            this.Controls.Add(this.btnPasswords);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnCategory);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnPasswords;
        private System.Windows.Forms.Button btnCreditCard;
        private System.Windows.Forms.Button btnSecurityReport;
        private System.Windows.Forms.Button btnDataBreaches;
        private System.Windows.Forms.Label lblLogOut;
        private System.Windows.Forms.Label lblChangePassword;
        private System.Windows.Forms.Label lblWelcome;
    }
}