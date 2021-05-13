
namespace UserInterface
{
    partial class ModifyCategoryModal
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
            this.lblNewCategoryName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtbxNewCategoryName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNewCategoryName
            // 
            this.lblNewCategoryName.AutoSize = true;
            this.lblNewCategoryName.Location = new System.Drawing.Point(38, 28);
            this.lblNewCategoryName.Name = "lblNewCategoryName";
            this.lblNewCategoryName.Size = new System.Drawing.Size(105, 13);
            this.lblNewCategoryName.TabIndex = 0;
            this.lblNewCategoryName.Text = "New Category Name";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(69, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtbxNewCategoryName
            // 
            this.txtbxNewCategoryName.Location = new System.Drawing.Point(41, 62);
            this.txtbxNewCategoryName.Name = "txtbxNewCategoryName";
            this.txtbxNewCategoryName.Size = new System.Drawing.Size(250, 20);
            this.txtbxNewCategoryName.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(192, 104);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ModifyCategoryModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtbxNewCategoryName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblNewCategoryName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "ModifyCategoryModal";
            this.Text = "ModifyCategoryModal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewCategoryName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtbxNewCategoryName;
        private System.Windows.Forms.Button btnOk;
    }
}