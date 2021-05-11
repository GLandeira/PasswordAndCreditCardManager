
namespace UserInterface
{
    partial class PasswordMoreInfoModal
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
            this.lblSecurityLevel = new System.Windows.Forms.Label();
            this.lblCategoryFill = new System.Windows.Forms.Label();
            this.lblSiteFill = new System.Windows.Forms.Label();
            this.lblUsernameFill = new System.Windows.Forms.Label();
            this.lblPasswordFill = new System.Windows.Forms.Label();
            this.lblSecurityLevelFill = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblNotesFill = new System.Windows.Forms.Label();
            this.timerPasswordMoreInfo = new System.Windows.Forms.Timer(this.components);
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.txtBxTimeLeft = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(66, 55);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category";
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(66, 96);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(28, 13);
            this.lblSite.TabIndex = 1;
            this.lblSite.Text = "Site:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(66, 142);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(66, 186);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // lblSecurityLevel
            // 
            this.lblSecurityLevel.AutoSize = true;
            this.lblSecurityLevel.Location = new System.Drawing.Point(66, 224);
            this.lblSecurityLevel.Name = "lblSecurityLevel";
            this.lblSecurityLevel.Size = new System.Drawing.Size(73, 13);
            this.lblSecurityLevel.TabIndex = 4;
            this.lblSecurityLevel.Text = "Security level:";
            // 
            // lblCategoryFill
            // 
            this.lblCategoryFill.AutoSize = true;
            this.lblCategoryFill.Location = new System.Drawing.Point(195, 55);
            this.lblCategoryFill.Name = "lblCategoryFill";
            this.lblCategoryFill.Size = new System.Drawing.Size(0, 13);
            this.lblCategoryFill.TabIndex = 5;
            // 
            // lblSiteFill
            // 
            this.lblSiteFill.AutoSize = true;
            this.lblSiteFill.Location = new System.Drawing.Point(195, 96);
            this.lblSiteFill.Name = "lblSiteFill";
            this.lblSiteFill.Size = new System.Drawing.Size(35, 13);
            this.lblSiteFill.TabIndex = 6;
            this.lblSiteFill.Text = "label7";
            // 
            // lblUsernameFill
            // 
            this.lblUsernameFill.AutoSize = true;
            this.lblUsernameFill.Location = new System.Drawing.Point(195, 142);
            this.lblUsernameFill.Name = "lblUsernameFill";
            this.lblUsernameFill.Size = new System.Drawing.Size(35, 13);
            this.lblUsernameFill.TabIndex = 7;
            this.lblUsernameFill.Text = "label8";
            // 
            // lblPasswordFill
            // 
            this.lblPasswordFill.AutoSize = true;
            this.lblPasswordFill.Location = new System.Drawing.Point(195, 186);
            this.lblPasswordFill.Name = "lblPasswordFill";
            this.lblPasswordFill.Size = new System.Drawing.Size(35, 13);
            this.lblPasswordFill.TabIndex = 8;
            this.lblPasswordFill.Text = "label9";
            // 
            // lblSecurityLevelFill
            // 
            this.lblSecurityLevelFill.AutoSize = true;
            this.lblSecurityLevelFill.Location = new System.Drawing.Point(189, 224);
            this.lblSecurityLevelFill.Name = "lblSecurityLevelFill";
            this.lblSecurityLevelFill.Size = new System.Drawing.Size(41, 13);
            this.lblSecurityLevelFill.TabIndex = 9;
            this.lblSecurityLevelFill.Text = "label10";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(66, 265);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 10;
            this.lblNotes.Text = "Notes:";
            // 
            // lblNotesFill
            // 
            this.lblNotesFill.AutoSize = true;
            this.lblNotesFill.Location = new System.Drawing.Point(195, 265);
            this.lblNotesFill.Name = "lblNotesFill";
            this.lblNotesFill.Size = new System.Drawing.Size(35, 13);
            this.lblNotesFill.TabIndex = 11;
            this.lblNotesFill.Text = "label1";
            // 
            // timerPasswordMoreInfo
            // 
            this.timerPasswordMoreInfo.Interval = 1000;
            this.timerPasswordMoreInfo.Tick += new System.EventHandler(this.timerPasswordMoreInfo_Tick);
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Location = new System.Drawing.Point(66, 369);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(85, 13);
            this.lblTimeLeft.TabIndex = 12;
            this.lblTimeLeft.Text = "Time left in page";
            // 
            // txtBxTimeLeft
            // 
            this.txtBxTimeLeft.Location = new System.Drawing.Point(181, 368);
            this.txtBxTimeLeft.Name = "txtBxTimeLeft";
            this.txtBxTimeLeft.ReadOnly = true;
            this.txtBxTimeLeft.Size = new System.Drawing.Size(27, 20);
            this.txtBxTimeLeft.TabIndex = 13;
            // 
            // PasswordMoreInfoModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 432);
            this.Controls.Add(this.txtBxTimeLeft);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.lblNotesFill);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblSecurityLevelFill);
            this.Controls.Add(this.lblPasswordFill);
            this.Controls.Add(this.lblUsernameFill);
            this.Controls.Add(this.lblSiteFill);
            this.Controls.Add(this.lblCategoryFill);
            this.Controls.Add(this.lblSecurityLevel);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.lblCategory);
            this.Name = "PasswordMoreInfoModal";
            this.Text = "PasswordMoreInfoModal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblSecurityLevel;
        private System.Windows.Forms.Label lblCategoryFill;
        private System.Windows.Forms.Label lblSiteFill;
        private System.Windows.Forms.Label lblUsernameFill;
        private System.Windows.Forms.Label lblPasswordFill;
        private System.Windows.Forms.Label lblSecurityLevelFill;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblNotesFill;
        private System.Windows.Forms.Timer timerPasswordMoreInfo;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.TextBox txtBxTimeLeft;
    }
}