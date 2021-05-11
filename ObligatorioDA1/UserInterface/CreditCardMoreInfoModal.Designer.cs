
namespace UserInterface
{
    partial class CreditCardMoreInfoModal
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
            this.lblCreditCardInfo = new System.Windows.Forms.Label();
            this.lblCreditCardName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblCreditCardSecurityCode = new System.Windows.Forms.Label();
            this.lblCreditCardValidDue = new System.Windows.Forms.Label();
            this.lblCreditCardCategory = new System.Windows.Forms.Label();
            this.lblCreditCardNotes = new System.Windows.Forms.Label();
            this.dtmCreditCardValidDue = new System.Windows.Forms.DateTimePicker();
            this.txtbxCreditCardCategory = new System.Windows.Forms.TextBox();
            this.txtbxCreditCardName = new System.Windows.Forms.TextBox();
            this.txtbxCreditCardType = new System.Windows.Forms.TextBox();
            this.txtbxCreditCardNumber = new System.Windows.Forms.TextBox();
            this.txtbxCreditCardSecurityCode = new System.Windows.Forms.TextBox();
            this.timerCreditCardMoreInfo = new System.Windows.Forms.Timer(this.components);
            this.txtbxTimer = new System.Windows.Forms.TextBox();
            this.txtbxCreditCardNotes = new System.Windows.Forms.TextBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCreditCardInfo
            // 
            this.lblCreditCardInfo.AutoSize = true;
            this.lblCreditCardInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditCardInfo.Location = new System.Drawing.Point(12, 9);
            this.lblCreditCardInfo.Name = "lblCreditCardInfo";
            this.lblCreditCardInfo.Size = new System.Drawing.Size(173, 16);
            this.lblCreditCardInfo.TabIndex = 0;
            this.lblCreditCardInfo.Text = "Credit Card Information";
            // 
            // lblCreditCardName
            // 
            this.lblCreditCardName.AutoSize = true;
            this.lblCreditCardName.Location = new System.Drawing.Point(36, 73);
            this.lblCreditCardName.Name = "lblCreditCardName";
            this.lblCreditCardName.Size = new System.Drawing.Size(35, 13);
            this.lblCreditCardName.TabIndex = 1;
            this.lblCreditCardName.Text = "Name";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(36, 99);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(36, 125);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "Number";
            // 
            // lblCreditCardSecurityCode
            // 
            this.lblCreditCardSecurityCode.AutoSize = true;
            this.lblCreditCardSecurityCode.Location = new System.Drawing.Point(36, 151);
            this.lblCreditCardSecurityCode.Name = "lblCreditCardSecurityCode";
            this.lblCreditCardSecurityCode.Size = new System.Drawing.Size(28, 13);
            this.lblCreditCardSecurityCode.TabIndex = 4;
            this.lblCreditCardSecurityCode.Text = "CVV";
            // 
            // lblCreditCardValidDue
            // 
            this.lblCreditCardValidDue.AutoSize = true;
            this.lblCreditCardValidDue.Location = new System.Drawing.Point(36, 192);
            this.lblCreditCardValidDue.Name = "lblCreditCardValidDue";
            this.lblCreditCardValidDue.Size = new System.Drawing.Size(53, 13);
            this.lblCreditCardValidDue.TabIndex = 5;
            this.lblCreditCardValidDue.Text = "Date Due";
            // 
            // lblCreditCardCategory
            // 
            this.lblCreditCardCategory.AutoSize = true;
            this.lblCreditCardCategory.Location = new System.Drawing.Point(36, 47);
            this.lblCreditCardCategory.Name = "lblCreditCardCategory";
            this.lblCreditCardCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCreditCardCategory.TabIndex = 6;
            this.lblCreditCardCategory.Text = "Category";
            // 
            // lblCreditCardNotes
            // 
            this.lblCreditCardNotes.AutoSize = true;
            this.lblCreditCardNotes.Location = new System.Drawing.Point(36, 239);
            this.lblCreditCardNotes.Name = "lblCreditCardNotes";
            this.lblCreditCardNotes.Size = new System.Drawing.Size(35, 13);
            this.lblCreditCardNotes.TabIndex = 7;
            this.lblCreditCardNotes.Text = "Notes";
            // 
            // dtmCreditCardValidDue
            // 
            this.dtmCreditCardValidDue.CustomFormat = "\"MM/yyyy\"";
            this.dtmCreditCardValidDue.Enabled = false;
            this.dtmCreditCardValidDue.Location = new System.Drawing.Point(117, 192);
            this.dtmCreditCardValidDue.Name = "dtmCreditCardValidDue";
            this.dtmCreditCardValidDue.Size = new System.Drawing.Size(62, 20);
            this.dtmCreditCardValidDue.TabIndex = 8;
            // 
            // txtbxCreditCardCategory
            // 
            this.txtbxCreditCardCategory.Location = new System.Drawing.Point(117, 44);
            this.txtbxCreditCardCategory.Name = "txtbxCreditCardCategory";
            this.txtbxCreditCardCategory.ReadOnly = true;
            this.txtbxCreditCardCategory.Size = new System.Drawing.Size(151, 20);
            this.txtbxCreditCardCategory.TabIndex = 9;
            // 
            // txtbxCreditCardName
            // 
            this.txtbxCreditCardName.Location = new System.Drawing.Point(117, 70);
            this.txtbxCreditCardName.Name = "txtbxCreditCardName";
            this.txtbxCreditCardName.ReadOnly = true;
            this.txtbxCreditCardName.Size = new System.Drawing.Size(151, 20);
            this.txtbxCreditCardName.TabIndex = 10;
            // 
            // txtbxCreditCardType
            // 
            this.txtbxCreditCardType.Location = new System.Drawing.Point(117, 96);
            this.txtbxCreditCardType.Name = "txtbxCreditCardType";
            this.txtbxCreditCardType.ReadOnly = true;
            this.txtbxCreditCardType.Size = new System.Drawing.Size(151, 20);
            this.txtbxCreditCardType.TabIndex = 11;
            // 
            // txtbxCreditCardNumber
            // 
            this.txtbxCreditCardNumber.Location = new System.Drawing.Point(117, 122);
            this.txtbxCreditCardNumber.Name = "txtbxCreditCardNumber";
            this.txtbxCreditCardNumber.ReadOnly = true;
            this.txtbxCreditCardNumber.Size = new System.Drawing.Size(151, 20);
            this.txtbxCreditCardNumber.TabIndex = 12;
            // 
            // txtbxCreditCardSecurityCode
            // 
            this.txtbxCreditCardSecurityCode.Location = new System.Drawing.Point(117, 148);
            this.txtbxCreditCardSecurityCode.Name = "txtbxCreditCardSecurityCode";
            this.txtbxCreditCardSecurityCode.ReadOnly = true;
            this.txtbxCreditCardSecurityCode.Size = new System.Drawing.Size(34, 20);
            this.txtbxCreditCardSecurityCode.TabIndex = 13;
            // 
            // timerCreditCardMoreInfo
            // 
            this.timerCreditCardMoreInfo.Interval = 1000;
            this.timerCreditCardMoreInfo.Tick += new System.EventHandler(this.timerCreditCardMoreInfo_Tick);
            // 
            // txtbxTimer
            // 
            this.txtbxTimer.Location = new System.Drawing.Point(174, 371);
            this.txtbxTimer.Name = "txtbxTimer";
            this.txtbxTimer.ReadOnly = true;
            this.txtbxTimer.Size = new System.Drawing.Size(20, 20);
            this.txtbxTimer.TabIndex = 14;
            // 
            // txtbxCreditCardNotes
            // 
            this.txtbxCreditCardNotes.Location = new System.Drawing.Point(39, 255);
            this.txtbxCreditCardNotes.Multiline = true;
            this.txtbxCreditCardNotes.Name = "txtbxCreditCardNotes";
            this.txtbxCreditCardNotes.ReadOnly = true;
            this.txtbxCreditCardNotes.Size = new System.Drawing.Size(229, 76);
            this.txtbxCreditCardNotes.TabIndex = 15;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(83, 374);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(85, 13);
            this.lblTimer.TabIndex = 16;
            this.lblTimer.Text = "Time left in page";
            // 
            // CreditCardMoreInfoModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 413);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.txtbxCreditCardNotes);
            this.Controls.Add(this.txtbxTimer);
            this.Controls.Add(this.txtbxCreditCardSecurityCode);
            this.Controls.Add(this.txtbxCreditCardNumber);
            this.Controls.Add(this.txtbxCreditCardType);
            this.Controls.Add(this.txtbxCreditCardName);
            this.Controls.Add(this.txtbxCreditCardCategory);
            this.Controls.Add(this.dtmCreditCardValidDue);
            this.Controls.Add(this.lblCreditCardNotes);
            this.Controls.Add(this.lblCreditCardCategory);
            this.Controls.Add(this.lblCreditCardValidDue);
            this.Controls.Add(this.lblCreditCardSecurityCode);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblCreditCardName);
            this.Controls.Add(this.lblCreditCardInfo);
            this.Name = "CreditCardMoreInfoModal";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCreditCardInfo;
        private System.Windows.Forms.Label lblCreditCardName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblCreditCardSecurityCode;
        private System.Windows.Forms.Label lblCreditCardValidDue;
        private System.Windows.Forms.Label lblCreditCardCategory;
        private System.Windows.Forms.Label lblCreditCardNotes;
        private System.Windows.Forms.DateTimePicker dtmCreditCardValidDue;
        private System.Windows.Forms.TextBox txtbxCreditCardCategory;
        private System.Windows.Forms.TextBox txtbxCreditCardName;
        private System.Windows.Forms.TextBox txtbxCreditCardType;
        private System.Windows.Forms.TextBox txtbxCreditCardNumber;
        private System.Windows.Forms.TextBox txtbxCreditCardSecurityCode;
        private System.Windows.Forms.Timer timerCreditCardMoreInfo;
        private System.Windows.Forms.TextBox txtbxTimer;
        private System.Windows.Forms.TextBox txtbxCreditCardNotes;
        private System.Windows.Forms.Label lblTimer;
    }
}