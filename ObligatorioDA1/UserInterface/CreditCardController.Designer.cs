
namespace UserInterface
{
    partial class CreditCardController
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNewCreditCard = new System.Windows.Forms.Button();
            this.btnDeleteCreditCard = new System.Windows.Forms.Button();
            this.btnModifyCreditCard = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grdvwCreditCard = new System.Windows.Forms.DataGridView();
            this.creditCardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecurityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validDueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvwCreditCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditCardBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewCreditCard
            // 
            this.btnNewCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCreditCard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNewCreditCard.Location = new System.Drawing.Point(180, 542);
            this.btnNewCreditCard.Name = "btnNewCreditCard";
            this.btnNewCreditCard.Size = new System.Drawing.Size(162, 66);
            this.btnNewCreditCard.TabIndex = 0;
            this.btnNewCreditCard.Text = "New";
            this.btnNewCreditCard.UseVisualStyleBackColor = true;
            this.btnNewCreditCard.Click += new System.EventHandler(this.btnNewCreditCard_Click);
            // 
            // btnDeleteCreditCard
            // 
            this.btnDeleteCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnDeleteCreditCard.Location = new System.Drawing.Point(358, 542);
            this.btnDeleteCreditCard.Name = "btnDeleteCreditCard";
            this.btnDeleteCreditCard.Size = new System.Drawing.Size(162, 66);
            this.btnDeleteCreditCard.TabIndex = 1;
            this.btnDeleteCreditCard.Text = "Delete";
            this.btnDeleteCreditCard.UseVisualStyleBackColor = true;
            this.btnDeleteCreditCard.Click += new System.EventHandler(this.btnDeleteCreditCard_Click);
            // 
            // btnModifyCreditCard
            // 
            this.btnModifyCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnModifyCreditCard.Location = new System.Drawing.Point(537, 542);
            this.btnModifyCreditCard.Name = "btnModifyCreditCard";
            this.btnModifyCreditCard.Size = new System.Drawing.Size(162, 66);
            this.btnModifyCreditCard.TabIndex = 2;
            this.btnModifyCreditCard.Text = "Modify";
            this.btnModifyCreditCard.UseVisualStyleBackColor = true;
            this.btnModifyCreditCard.Click += new System.EventHandler(this.btnModifyCreditCard_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(128, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 357);
            this.dataGridView1.TabIndex = 4;
            // 
            // grdvwCreditCard
            // 
            this.grdvwCreditCard.AllowUserToAddRows = false;
            this.grdvwCreditCard.AllowUserToDeleteRows = false;
            this.grdvwCreditCard.AllowUserToResizeColumns = false;
            this.grdvwCreditCard.AllowUserToResizeRows = false;
            this.grdvwCreditCard.AutoGenerateColumns = false;
            this.grdvwCreditCard.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdvwCreditCard.CausesValidation = false;
            this.grdvwCreditCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdvwCreditCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.SecurityCode,
            this.validDueDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn});
            this.grdvwCreditCard.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.creditCardBindingSource, "Category", true));
            this.grdvwCreditCard.DataSource = this.creditCardBindingSource;
            this.grdvwCreditCard.Location = new System.Drawing.Point(62, 63);
            this.grdvwCreditCard.Name = "grdvwCreditCard";
            this.grdvwCreditCard.ReadOnly = true;
            this.grdvwCreditCard.Size = new System.Drawing.Size(740, 425);
            this.grdvwCreditCard.TabIndex = 5;
            this.grdvwCreditCard.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdvwCreditCard_CellDoubleClick);
            this.grdvwCreditCard.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdvwCreditCard_CellEnter_1);
            this.grdvwCreditCard.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdvwCreditCard_CellFormatting);
            // 
            // creditCardBindingSource
            // 
            this.creditCardBindingSource.DataSource = typeof(Domain.CreditCard);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Your Credit Cards";
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.Frozen = true;
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Width = 150;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            dataGridViewCellStyle1.NullValue = null;
            this.numberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn.Width = 200;
            // 
            // SecurityCode
            // 
            this.SecurityCode.DataPropertyName = "SecurityCode";
            this.SecurityCode.HeaderText = "CVV";
            this.SecurityCode.Name = "SecurityCode";
            this.SecurityCode.ReadOnly = true;
            this.SecurityCode.Visible = false;
            // 
            // validDueDataGridViewTextBoxColumn
            // 
            this.validDueDataGridViewTextBoxColumn.DataPropertyName = "ValidDue";
            dataGridViewCellStyle2.Format = "\"\"MM/yyyy\"\"";
            dataGridViewCellStyle2.NullValue = null;
            this.validDueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.validDueDataGridViewTextBoxColumn.HeaderText = "DateDue";
            this.validDueDataGridViewTextBoxColumn.Name = "validDueDataGridViewTextBoxColumn";
            this.validDueDataGridViewTextBoxColumn.ReadOnly = true;
            this.validDueDataGridViewTextBoxColumn.Width = 75;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.ReadOnly = true;
            this.notesDataGridViewTextBoxColumn.Visible = false;
            // 
            // CreditCardController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdvwCreditCard);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnModifyCreditCard);
            this.Controls.Add(this.btnDeleteCreditCard);
            this.Controls.Add(this.btnNewCreditCard);
            this.Name = "CreditCardController";
            this.Size = new System.Drawing.Size(904, 656);
            this.Load += new System.EventHandler(this.CreditCardController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvwCreditCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditCardBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewCreditCard;
        private System.Windows.Forms.Button btnDeleteCreditCard;
        private System.Windows.Forms.Button btnModifyCreditCard;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView grdvwCreditCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource creditCardBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecurityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn validDueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
    }
}
