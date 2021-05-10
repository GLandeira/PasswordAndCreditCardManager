
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
            this.lstvwPasswordLists = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lstvwPasswordLists
            // 
            this.lstvwPasswordLists.HideSelection = false;
            this.lstvwPasswordLists.Location = new System.Drawing.Point(34, 77);
            this.lstvwPasswordLists.Name = "lstvwPasswordLists";
            this.lstvwPasswordLists.Size = new System.Drawing.Size(253, 97);
            this.lstvwPasswordLists.TabIndex = 0;
            this.lstvwPasswordLists.UseCompatibleStateImageBehavior = false;
            // 
            // DataBreachMatchesModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 461);
            this.Controls.Add(this.lstvwPasswordLists);
            this.Name = "DataBreachMatchesModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataBreachMatchesModal";
            this.Load += new System.EventHandler(this.DataBreachMatchesModal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstvwPasswordLists;
    }
}