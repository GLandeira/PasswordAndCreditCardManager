
namespace UserInterface
{
    partial class DataBreachesController
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
            this.lblDataBreachesTitle = new System.Windows.Forms.Label();
            this.txtbxDataBreaches = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lblExposedText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDataBreachesTitle
            // 
            this.lblDataBreachesTitle.AutoSize = true;
            this.lblDataBreachesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataBreachesTitle.Location = new System.Drawing.Point(24, 62);
            this.lblDataBreachesTitle.Name = "lblDataBreachesTitle";
            this.lblDataBreachesTitle.Size = new System.Drawing.Size(404, 39);
            this.lblDataBreachesTitle.TabIndex = 0;
            this.lblDataBreachesTitle.Text = "Check for Data Breaches";
            // 
            // txtbxDataBreaches
            // 
            this.txtbxDataBreaches.Location = new System.Drawing.Point(51, 149);
            this.txtbxDataBreaches.Multiline = true;
            this.txtbxDataBreaches.Name = "txtbxDataBreaches";
            this.txtbxDataBreaches.Size = new System.Drawing.Size(786, 402);
            this.txtbxDataBreaches.TabIndex = 1;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(682, 578);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(105, 39);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // lblExposedText
            // 
            this.lblExposedText.AutoSize = true;
            this.lblExposedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExposedText.Location = new System.Drawing.Point(47, 122);
            this.lblExposedText.Name = "lblExposedText";
            this.lblExposedText.Size = new System.Drawing.Size(128, 24);
            this.lblExposedText.TabIndex = 3;
            this.lblExposedText.Text = "Exposed Text";
            // 
            // DataBreachesController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblExposedText);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtbxDataBreaches);
            this.Controls.Add(this.lblDataBreachesTitle);
            this.Name = "DataBreachesController";
            this.Size = new System.Drawing.Size(904, 656);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDataBreachesTitle;
        private System.Windows.Forms.TextBox txtbxDataBreaches;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblExposedText;
    }
}
