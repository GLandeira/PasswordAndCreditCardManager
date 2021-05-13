
namespace UserInterface
{
    partial class PasswordGeneratorModal
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
            this.lblLength = new System.Windows.Forms.Label();
            this.txtBxLength = new System.Windows.Forms.TextBox();
            this.chkBxMinus = new System.Windows.Forms.CheckBox();
            this.chkBxMayus = new System.Windows.Forms.CheckBox();
            this.chkBxDigits = new System.Windows.Forms.CheckBox();
            this.chkBxSymbols = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblLengthrestriction = new System.Windows.Forms.Label();
            this.lblGenerationSettingsRestriction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLength.Location = new System.Drawing.Point(56, 57);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(73, 24);
            this.lblLength.TabIndex = 0;
            this.lblLength.Text = "Length:";
            // 
            // txtBxLength
            // 
            this.txtBxLength.Location = new System.Drawing.Point(137, 59);
            this.txtBxLength.Name = "txtBxLength";
            this.txtBxLength.Size = new System.Drawing.Size(158, 20);
            this.txtBxLength.TabIndex = 1;
            // 
            // chkBxMinus
            // 
            this.chkBxMinus.AutoSize = true;
            this.chkBxMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBxMinus.Location = new System.Drawing.Point(86, 107);
            this.chkBxMinus.Name = "chkBxMinus";
            this.chkBxMinus.Size = new System.Drawing.Size(130, 24);
            this.chkBxMinus.TabIndex = 2;
            this.chkBxMinus.Text = "Minus (a,b,c...)";
            this.chkBxMinus.UseVisualStyleBackColor = true;
            // 
            // chkBxMayus
            // 
            this.chkBxMayus.AutoSize = true;
            this.chkBxMayus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBxMayus.Location = new System.Drawing.Point(86, 159);
            this.chkBxMayus.Name = "chkBxMayus";
            this.chkBxMayus.Size = new System.Drawing.Size(141, 24);
            this.chkBxMayus.TabIndex = 3;
            this.chkBxMayus.Text = "Mayus (A,B,C...)";
            this.chkBxMayus.UseVisualStyleBackColor = true;
            // 
            // chkBxDigits
            // 
            this.chkBxDigits.AutoSize = true;
            this.chkBxDigits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBxDigits.Location = new System.Drawing.Point(86, 213);
            this.chkBxDigits.Name = "chkBxDigits";
            this.chkBxDigits.Size = new System.Drawing.Size(129, 24);
            this.chkBxDigits.TabIndex = 4;
            this.chkBxDigits.Text = "Digits (0,1,2...)";
            this.chkBxDigits.UseVisualStyleBackColor = true;
            // 
            // chkBxSymbols
            // 
            this.chkBxSymbols.AutoSize = true;
            this.chkBxSymbols.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBxSymbols.Location = new System.Drawing.Point(86, 265);
            this.chkBxSymbols.Name = "chkBxSymbols";
            this.chkBxSymbols.Size = new System.Drawing.Size(156, 24);
            this.chkBxSymbols.TabIndex = 5;
            this.chkBxSymbols.Text = "Symbols (/,@,%...)";
            this.chkBxSymbols.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(86, 328);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(188, 41);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblLengthrestriction
            // 
            this.lblLengthrestriction.AutoSize = true;
            this.lblLengthrestriction.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLengthrestriction.Location = new System.Drawing.Point(135, 82);
            this.lblLengthrestriction.Name = "lblLengthrestriction";
            this.lblLengthrestriction.Size = new System.Drawing.Size(146, 12);
            this.lblLengthrestriction.TabIndex = 7;
            this.lblLengthrestriction.Text = "Must have from 5 to 25 characters";
            // 
            // lblGenerationSettingsRestriction
            // 
            this.lblGenerationSettingsRestriction.AutoSize = true;
            this.lblGenerationSettingsRestriction.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerationSettingsRestriction.Location = new System.Drawing.Point(85, 296);
            this.lblGenerationSettingsRestriction.Name = "lblGenerationSettingsRestriction";
            this.lblGenerationSettingsRestriction.Size = new System.Drawing.Size(136, 12);
            this.lblGenerationSettingsRestriction.TabIndex = 8;
            this.lblGenerationSettingsRestriction.Text = "Must check at least one of them";
            // 
            // PasswordGeneratorModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 435);
            this.Controls.Add(this.lblGenerationSettingsRestriction);
            this.Controls.Add(this.lblLengthrestriction);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.chkBxSymbols);
            this.Controls.Add(this.chkBxDigits);
            this.Controls.Add(this.chkBxMayus);
            this.Controls.Add(this.chkBxMinus);
            this.Controls.Add(this.txtBxLength);
            this.Controls.Add(this.lblLength);
            this.Name = "PasswordGeneratorModal";
            this.Text = "PasswordGeneratorModal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtBxLength;
        private System.Windows.Forms.CheckBox chkBxMinus;
        private System.Windows.Forms.CheckBox chkBxMayus;
        private System.Windows.Forms.CheckBox chkBxDigits;
        private System.Windows.Forms.CheckBox chkBxSymbols;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblLengthrestriction;
        private System.Windows.Forms.Label lblGenerationSettingsRestriction;
    }
}