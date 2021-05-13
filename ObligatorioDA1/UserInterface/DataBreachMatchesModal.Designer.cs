
namespace UserInterface
{
    partial class DataBreachMatchesModal
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
            this.lblBreachedPasswords = new System.Windows.Forms.Label();
            this.lblBreachedCreditCards = new System.Windows.Forms.Label();
            this.fwlytBreachedPassword = new System.Windows.Forms.FlowLayoutPanel();
            this.fwlytBreachedCreditCards = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblBreachedPasswords
            // 
            this.lblBreachedPasswords.AutoSize = true;
            this.lblBreachedPasswords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreachedPasswords.Location = new System.Drawing.Point(17, 18);
            this.lblBreachedPasswords.Name = "lblBreachedPasswords";
            this.lblBreachedPasswords.Size = new System.Drawing.Size(218, 26);
            this.lblBreachedPasswords.TabIndex = 0;
            this.lblBreachedPasswords.Text = "Breached Passwords";
            // 
            // lblBreachedCreditCards
            // 
            this.lblBreachedCreditCards.AutoSize = true;
            this.lblBreachedCreditCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreachedCreditCards.Location = new System.Drawing.Point(17, 237);
            this.lblBreachedCreditCards.Name = "lblBreachedCreditCards";
            this.lblBreachedCreditCards.Size = new System.Drawing.Size(233, 26);
            this.lblBreachedCreditCards.TabIndex = 1;
            this.lblBreachedCreditCards.Text = "Breached Credit Cards";
            // 
            // fwlytBreachedPassword
            // 
            this.fwlytBreachedPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fwlytBreachedPassword.AutoScroll = true;
            this.fwlytBreachedPassword.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fwlytBreachedPassword.Location = new System.Drawing.Point(12, 47);
            this.fwlytBreachedPassword.Name = "fwlytBreachedPassword";
            this.fwlytBreachedPassword.Size = new System.Drawing.Size(515, 166);
            this.fwlytBreachedPassword.TabIndex = 6;
            this.fwlytBreachedPassword.WrapContents = false;
            // 
            // fwlytBreachedCreditCards
            // 
            this.fwlytBreachedCreditCards.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fwlytBreachedCreditCards.AutoScroll = true;
            this.fwlytBreachedCreditCards.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fwlytBreachedCreditCards.Location = new System.Drawing.Point(12, 266);
            this.fwlytBreachedCreditCards.Name = "fwlytBreachedCreditCards";
            this.fwlytBreachedCreditCards.Size = new System.Drawing.Size(515, 166);
            this.fwlytBreachedCreditCards.TabIndex = 7;
            this.fwlytBreachedCreditCards.WrapContents = false;
            // 
            // DataBreachMatchesModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 461);
            this.Controls.Add(this.fwlytBreachedCreditCards);
            this.Controls.Add(this.fwlytBreachedPassword);
            this.Controls.Add(this.lblBreachedCreditCards);
            this.Controls.Add(this.lblBreachedPasswords);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(555, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(555, 500);
            this.Name = "DataBreachMatchesModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Results";
            this.Load += new System.EventHandler(this.DataBreachMatchesModal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBreachedPasswords;
        private System.Windows.Forms.Label lblBreachedCreditCards;
        private System.Windows.Forms.FlowLayoutPanel fwlytBreachedPassword;
        private System.Windows.Forms.FlowLayoutPanel fwlytBreachedCreditCards;
    }
}