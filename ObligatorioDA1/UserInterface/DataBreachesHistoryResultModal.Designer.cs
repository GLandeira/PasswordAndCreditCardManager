
namespace UserInterface
{
    partial class DataBreachesHistoryResultModal
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
            this.fwlytBreachedCreditCards = new System.Windows.Forms.FlowLayoutPanel();
            this.fwlytBreachedPassword = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCreditCardsHistory = new System.Windows.Forms.Label();
            this.lblPasswordsHistory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fwlytBreachedCreditCards
            // 
            this.fwlytBreachedCreditCards.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fwlytBreachedCreditCards.AutoScroll = true;
            this.fwlytBreachedCreditCards.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fwlytBreachedCreditCards.Location = new System.Drawing.Point(14, 262);
            this.fwlytBreachedCreditCards.Name = "fwlytBreachedCreditCards";
            this.fwlytBreachedCreditCards.Size = new System.Drawing.Size(515, 166);
            this.fwlytBreachedCreditCards.TabIndex = 11;
            this.fwlytBreachedCreditCards.WrapContents = false;
            // 
            // fwlytBreachedPassword
            // 
            this.fwlytBreachedPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fwlytBreachedPassword.AutoScroll = true;
            this.fwlytBreachedPassword.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fwlytBreachedPassword.Location = new System.Drawing.Point(14, 43);
            this.fwlytBreachedPassword.Name = "fwlytBreachedPassword";
            this.fwlytBreachedPassword.Size = new System.Drawing.Size(515, 166);
            this.fwlytBreachedPassword.TabIndex = 10;
            this.fwlytBreachedPassword.WrapContents = false;
            // 
            // lblCreditCardsHistory
            // 
            this.lblCreditCardsHistory.AutoSize = true;
            this.lblCreditCardsHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditCardsHistory.Location = new System.Drawing.Point(12, 233);
            this.lblCreditCardsHistory.Name = "lblCreditCardsHistory";
            this.lblCreditCardsHistory.Size = new System.Drawing.Size(208, 26);
            this.lblCreditCardsHistory.TabIndex = 9;
            this.lblCreditCardsHistory.Text = "Credit Cards History";
            // 
            // lblPasswordsHistory
            // 
            this.lblPasswordsHistory.AutoSize = true;
            this.lblPasswordsHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordsHistory.Location = new System.Drawing.Point(12, 9);
            this.lblPasswordsHistory.Name = "lblPasswordsHistory";
            this.lblPasswordsHistory.Size = new System.Drawing.Size(193, 26);
            this.lblPasswordsHistory.TabIndex = 8;
            this.lblPasswordsHistory.Text = "Passwords History";
            // 
            // DataBreachesHistoryResultModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 461);
            this.Controls.Add(this.fwlytBreachedCreditCards);
            this.Controls.Add(this.fwlytBreachedPassword);
            this.Controls.Add(this.lblCreditCardsHistory);
            this.Controls.Add(this.lblPasswordsHistory);
            this.Name = "DataBreachesHistoryResultModal";
            this.Text = "Data Breach History";
            this.Load += new System.EventHandler(this.DataBreachesHistoryResultModal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fwlytBreachedCreditCards;
        private System.Windows.Forms.FlowLayoutPanel fwlytBreachedPassword;
        private System.Windows.Forms.Label lblCreditCardsHistory;
        private System.Windows.Forms.Label lblPasswordsHistory;
    }
}