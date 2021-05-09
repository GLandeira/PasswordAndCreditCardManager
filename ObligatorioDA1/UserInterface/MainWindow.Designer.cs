
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
            this.pnlLogIn = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlLogIn
            // 
            this.pnlLogIn.Location = new System.Drawing.Point(30, 12);
            this.pnlLogIn.Name = "pnlLogIn";
            this.pnlLogIn.Size = new System.Drawing.Size(740, 410);
            this.pnlLogIn.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlLogIn);
            this.Name = "MainWindow";
            this.Text = "NOMBRE APP";
            this.Load += new System.EventHandler(this.LogInPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogIn;
    }
}

