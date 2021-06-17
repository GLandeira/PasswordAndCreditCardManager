
namespace UserInterface
{
    partial class DataBreachHistoryModal
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
            this.grdvwDataBreachesHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdvwDataBreachesHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // grdvwDataBreachesHistory
            // 
            this.grdvwDataBreachesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdvwDataBreachesHistory.Location = new System.Drawing.Point(29, 33);
            this.grdvwDataBreachesHistory.Name = "grdvwDataBreachesHistory";
            this.grdvwDataBreachesHistory.Size = new System.Drawing.Size(343, 378);
            this.grdvwDataBreachesHistory.TabIndex = 0;
            this.grdvwDataBreachesHistory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdvwDataBreachesHistory_CellDoubleClick);
            this.grdvwDataBreachesHistory.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdvwDataBreachesHistory_CellEnter);
            // 
            // DataBreachHistoryModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 450);
            this.Controls.Add(this.grdvwDataBreachesHistory);
            this.Name = "DataBreachHistoryModal";
            this.Text = "DataBreachHistoryModal";
            ((System.ComponentModel.ISupportInitialize)(this.grdvwDataBreachesHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdvwDataBreachesHistory;
    }
}