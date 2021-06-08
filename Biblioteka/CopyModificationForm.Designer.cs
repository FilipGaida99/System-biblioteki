
namespace Biblioteka
{
    partial class CopyModificationForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            this.isElectronicCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkText = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.copyInventoryNumber = new System.Windows.Forms.NumericUpDown();
            this.printDatePicker = new System.Windows.Forms.DateTimePicker();
            this.identityInventoryButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.copyInventoryNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label1.Location = new System.Drawing.Point(11, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(141, 20);
            label1.TabIndex = 0;
            label1.Text = "Numer inwetnarza:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label3.Location = new System.Drawing.Point(10, 49);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(110, 20);
            label3.TabIndex = 7;
            label3.Text = "Data wydruku:";
            // 
            // isElectronicCheckBox
            // 
            this.isElectronicCheckBox.AutoSize = true;
            this.isElectronicCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.isElectronicCheckBox.Location = new System.Drawing.Point(14, 79);
            this.isElectronicCheckBox.Name = "isElectronicCheckBox";
            this.isElectronicCheckBox.Size = new System.Drawing.Size(208, 24);
            this.isElectronicCheckBox.TabIndex = 4;
            this.isElectronicCheckBox.Text = "Egzemplarz elektroniczny";
            this.isElectronicCheckBox.UseVisualStyleBackColor = true;
            this.isElectronicCheckBox.CheckedChanged += new System.EventHandler(this.isElectronicCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(11, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Odnośnik:";
            // 
            // linkText
            // 
            this.linkText.Enabled = false;
            this.linkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkText.Location = new System.Drawing.Point(97, 107);
            this.linkText.MaxLength = 50;
            this.linkText.Name = "linkText";
            this.linkText.Size = new System.Drawing.Size(341, 26);
            this.linkText.TabIndex = 5;
            // 
            // acceptButton
            // 
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.acceptButton.Location = new System.Drawing.Point(81, 166);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(114, 31);
            this.acceptButton.TabIndex = 6;
            this.acceptButton.Text = "Zaakceptuj";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelButton.Location = new System.Drawing.Point(217, 166);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(114, 31);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // copyInventoryNumber
            // 
            this.copyInventoryNumber.AllowDrop = true;
            this.copyInventoryNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.copyInventoryNumber.Location = new System.Drawing.Point(158, 11);
            this.copyInventoryNumber.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.copyInventoryNumber.Name = "copyInventoryNumber";
            this.copyInventoryNumber.Size = new System.Drawing.Size(256, 26);
            this.copyInventoryNumber.TabIndex = 1;
            // 
            // printDatePicker
            // 
            this.printDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.printDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.printDatePicker.Location = new System.Drawing.Point(126, 44);
            this.printDatePicker.Name = "printDatePicker";
            this.printDatePicker.Size = new System.Drawing.Size(129, 26);
            this.printDatePicker.TabIndex = 3;
            // 
            // identityInventoryButton
            // 
            this.identityInventoryButton.Location = new System.Drawing.Point(420, 13);
            this.identityInventoryButton.Name = "identityInventoryButton";
            this.identityInventoryButton.Size = new System.Drawing.Size(18, 26);
            this.identityInventoryButton.TabIndex = 2;
            this.identityInventoryButton.Text = "★";
            this.identityInventoryButton.UseVisualStyleBackColor = true;
            this.identityInventoryButton.Click += new System.EventHandler(this.identityInventoryButton_Click);
            // 
            // CopyModificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 209);
            this.Controls.Add(this.identityInventoryButton);
            this.Controls.Add(label3);
            this.Controls.Add(this.printDatePicker);
            this.Controls.Add(this.copyInventoryNumber);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.linkText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.isElectronicCheckBox);
            this.Controls.Add(label1);
            this.Name = "CopyModificationForm";
            this.Text = "Dodawanie/Modyfikowanie Egzemplarza";
            this.Load += new System.EventHandler(this.CopyModificationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.copyInventoryNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox isElectronicCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox linkText;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown copyInventoryNumber;
        private System.Windows.Forms.DateTimePicker printDatePicker;
        private System.Windows.Forms.Button identityInventoryButton;
    }
}