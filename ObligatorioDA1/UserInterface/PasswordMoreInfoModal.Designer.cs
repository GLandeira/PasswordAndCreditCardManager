
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
            this.lblNotes = new System.Windows.Forms.Label();
            this.timerPasswordMoreInfo = new System.Windows.Forms.Timer(this.components);
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.txtbxTimeLeft = new System.Windows.Forms.TextBox();
            this.lblSharedWith = new System.Windows.Forms.Label();
            this.fwlytSharedWith = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCreditCardInfo = new System.Windows.Forms.Label();
            this.txtbxPasswordString = new System.Windows.Forms.TextBox();
            this.txtbxPasswordUsername = new System.Windows.Forms.TextBox();
            this.txtbxPasswordSite = new System.Windows.Forms.TextBox();
            this.txtbxPasswordCategory = new System.Windows.Forms.TextBox();
            this.txtbxPasswordSecurityLevel = new System.Windows.Forms.TextBox();
            this.txtbxPasswordNotes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(36, 47);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category";
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(36, 73);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(28, 13);
            this.lblSite.TabIndex = 1;
            this.lblSite.Text = "Site:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(36, 99);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(36, 125);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // lblSecurityLevel
            // 
            this.lblSecurityLevel.AutoSize = true;
            this.lblSecurityLevel.Location = new System.Drawing.Point(36, 151);
            this.lblSecurityLevel.Name = "lblSecurityLevel";
            this.lblSecurityLevel.Size = new System.Drawing.Size(73, 13);
            this.lblSecurityLevel.TabIndex = 4;
            this.lblSecurityLevel.Text = "Security level:";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(36, 242);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 10;
            this.lblNotes.Text = "Notes:";
            // 
            // timerPasswordMoreInfo
            // 
            this.timerPasswordMoreInfo.Interval = 1000;
            this.timerPasswordMoreInfo.Tick += new System.EventHandler(this.timerPasswordMoreInfo_Tick);
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Location = new System.Drawing.Point(83, 374);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(85, 13);
            this.lblTimeLeft.TabIndex = 12;
            this.lblTimeLeft.Text = "Time left in page";
            // 
            // txtbxTimeLeft
            // 
            this.txtbxTimeLeft.Location = new System.Drawing.Point(174, 371);
            this.txtbxTimeLeft.Name = "txtbxTimeLeft";
            this.txtbxTimeLeft.ReadOnly = true;
            this.txtbxTimeLeft.Size = new System.Drawing.Size(27, 20);
            this.txtbxTimeLeft.TabIndex = 13;
            // 
            // lblSharedWith
            // 
            this.lblSharedWith.AutoSize = true;
            this.lblSharedWith.Location = new System.Drawing.Point(36, 176);
            this.lblSharedWith.Name = "lblSharedWith";
            this.lblSharedWith.Size = new System.Drawing.Size(66, 13);
            this.lblSharedWith.TabIndex = 14;
            this.lblSharedWith.Text = "Shared with:";
            // 
            // fwlytSharedWith
            // 
            this.fwlytSharedWith.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fwlytSharedWith.Location = new System.Drawing.Point(117, 176);
            this.fwlytSharedWith.Name = "fwlytSharedWith";
            this.fwlytSharedWith.Size = new System.Drawing.Size(142, 60);
            this.fwlytSharedWith.TabIndex = 15;
            // 
            // lblCreditCardInfo
            // 
            this.lblCreditCardInfo.AutoSize = true;
            this.lblCreditCardInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditCardInfo.Location = new System.Drawing.Point(12, 9);
            this.lblCreditCardInfo.Name = "lblCreditCardInfo";
            this.lblCreditCardInfo.Size = new System.Drawing.Size(156, 16);
            this.lblCreditCardInfo.TabIndex = 16;
            this.lblCreditCardInfo.Text = "Password Information";
            // 
            // txtbxPasswordString
            // 
            this.txtbxPasswordString.Location = new System.Drawing.Point(117, 122);
            this.txtbxPasswordString.Name = "txtbxPasswordString";
            this.txtbxPasswordString.ReadOnly = true;
            this.txtbxPasswordString.Size = new System.Drawing.Size(151, 20);
            this.txtbxPasswordString.TabIndex = 20;
            // 
            // txtbxPasswordUsername
            // 
            this.txtbxPasswordUsername.Location = new System.Drawing.Point(117, 96);
            this.txtbxPasswordUsername.Name = "txtbxPasswordUsername";
            this.txtbxPasswordUsername.ReadOnly = true;
            this.txtbxPasswordUsername.Size = new System.Drawing.Size(151, 20);
            this.txtbxPasswordUsername.TabIndex = 19;
            // 
            // txtbxPasswordSite
            // 
            this.txtbxPasswordSite.Location = new System.Drawing.Point(117, 70);
            this.txtbxPasswordSite.Name = "txtbxPasswordSite";
            this.txtbxPasswordSite.ReadOnly = true;
            this.txtbxPasswordSite.Size = new System.Drawing.Size(151, 20);
            this.txtbxPasswordSite.TabIndex = 18;
            // 
            // txtbxPasswordCategory
            // 
            this.txtbxPasswordCategory.Location = new System.Drawing.Point(117, 44);
            this.txtbxPasswordCategory.Name = "txtbxPasswordCategory";
            this.txtbxPasswordCategory.ReadOnly = true;
            this.txtbxPasswordCategory.Size = new System.Drawing.Size(151, 20);
            this.txtbxPasswordCategory.TabIndex = 17;
            // 
            // txtbxPasswordSecurityLevel
            // 
            this.txtbxPasswordSecurityLevel.Location = new System.Drawing.Point(117, 148);
            this.txtbxPasswordSecurityLevel.Name = "txtbxPasswordSecurityLevel";
            this.txtbxPasswordSecurityLevel.ReadOnly = true;
            this.txtbxPasswordSecurityLevel.Size = new System.Drawing.Size(151, 20);
            this.txtbxPasswordSecurityLevel.TabIndex = 21;
            // 
            // txtbxPasswordNotes
            // 
            this.txtbxPasswordNotes.Location = new System.Drawing.Point(39, 260);
            this.txtbxPasswordNotes.Multiline = true;
            this.txtbxPasswordNotes.Name = "txtbxPasswordNotes";
            this.txtbxPasswordNotes.ReadOnly = true;
            this.txtbxPasswordNotes.Size = new System.Drawing.Size(229, 76);
            this.txtbxPasswordNotes.TabIndex = 22;
            // 
            // PasswordMoreInfoModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 413);
            this.Controls.Add(this.txtbxPasswordNotes);
            this.Controls.Add(this.txtbxPasswordSecurityLevel);
            this.Controls.Add(this.txtbxPasswordString);
            this.Controls.Add(this.txtbxPasswordUsername);
            this.Controls.Add(this.txtbxPasswordSite);
            this.Controls.Add(this.txtbxPasswordCategory);
            this.Controls.Add(this.lblCreditCardInfo);
            this.Controls.Add(this.fwlytSharedWith);
            this.Controls.Add(this.lblSharedWith);
            this.Controls.Add(this.txtbxTimeLeft);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.lblNotes);
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
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Timer timerPasswordMoreInfo;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.TextBox txtbxTimeLeft;
        private System.Windows.Forms.Label lblSharedWith;
        private System.Windows.Forms.FlowLayoutPanel fwlytSharedWith;
        private System.Windows.Forms.Label lblCreditCardInfo;
        private System.Windows.Forms.TextBox txtbxPasswordString;
        private System.Windows.Forms.TextBox txtbxPasswordUsername;
        private System.Windows.Forms.TextBox txtbxPasswordSite;
        private System.Windows.Forms.TextBox txtbxPasswordCategory;
        private System.Windows.Forms.TextBox txtbxPasswordSecurityLevel;
        private System.Windows.Forms.TextBox txtbxPasswordNotes;
    }
}