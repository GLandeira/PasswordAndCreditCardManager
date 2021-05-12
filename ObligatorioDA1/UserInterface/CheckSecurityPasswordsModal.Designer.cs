
namespace UserInterface
{
    partial class CheckSecurityPasswordsModal
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
            this.lblPasswords = new System.Windows.Forms.Label();
            this.fwlytPasswords = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPasswords
            // 
            this.lblPasswords.AutoSize = true;
            this.lblPasswords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswords.Location = new System.Drawing.Point(25, 37);
            this.lblPasswords.Name = "lblPasswords";
            this.lblPasswords.Size = new System.Drawing.Size(172, 26);
            this.lblPasswords.TabIndex = 1;
            this.lblPasswords.Text = "Your Passwords";
            // 
            // fwlytPasswords
            // 
            this.fwlytPasswords.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fwlytPasswords.AutoScroll = true;
            this.fwlytPasswords.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fwlytPasswords.Location = new System.Drawing.Point(12, 72);
            this.fwlytPasswords.Name = "fwlytPasswords";
            this.fwlytPasswords.Size = new System.Drawing.Size(515, 232);
            this.fwlytPasswords.TabIndex = 7;
            this.fwlytPasswords.WrapContents = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(388, 335);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(104, 36);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // CheckSecurityPasswordsModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 399);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.fwlytPasswords);
            this.Controls.Add(this.lblPasswords);
            this.Name = "CheckSecurityPasswordsModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckSecurityPasswordsModal";
            this.Load += new System.EventHandler(this.CheckSecurityPasswordsModal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPasswords;
        private System.Windows.Forms.FlowLayoutPanel fwlytPasswords;
        private System.Windows.Forms.Button btnOk;
    }
}