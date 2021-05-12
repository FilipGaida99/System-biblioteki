
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
            this.copyInventoryText = new System.Windows.Forms.TextBox();
            this.isElectronicCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkText = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(95, 13);
            label1.TabIndex = 0;
            label1.Text = "Numer inwetnarza:";
            // 
            // copyInventoryText
            // 
            this.copyInventoryText.Location = new System.Drawing.Point(112, 10);
            this.copyInventoryText.Name = "copyInventoryText";
            this.copyInventoryText.Size = new System.Drawing.Size(256, 20);
            this.copyInventoryText.TabIndex = 1;
            // 
            // isElectronicCheckBox
            // 
            this.isElectronicCheckBox.AutoSize = true;
            this.isElectronicCheckBox.Location = new System.Drawing.Point(14, 51);
            this.isElectronicCheckBox.Name = "isElectronicCheckBox";
            this.isElectronicCheckBox.Size = new System.Drawing.Size(145, 17);
            this.isElectronicCheckBox.TabIndex = 2;
            this.isElectronicCheckBox.Text = "Egzemplarz elektroniczny";
            this.isElectronicCheckBox.UseVisualStyleBackColor = true;
            this.isElectronicCheckBox.CheckedChanged += new System.EventHandler(this.isElectronicCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Odnośnik:";
            // 
            // linkText
            // 
            this.linkText.Enabled = false;
            this.linkText.Location = new System.Drawing.Point(72, 79);
            this.linkText.Name = "linkText";
            this.linkText.Size = new System.Drawing.Size(296, 20);
            this.linkText.TabIndex = 4;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(112, 142);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 5;
            this.acceptButton.Text = "Zaakceptuj";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(197, 142);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CopyModificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 177);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.linkText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.isElectronicCheckBox);
            this.Controls.Add(this.copyInventoryText);
            this.Controls.Add(label1);
            this.Name = "CopyModificationForm";
            this.Text = "Dodawanie/Modyfikowanie Egzemplarza";
            this.Load += new System.EventHandler(this.CopyModificationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox copyInventoryText;
        private System.Windows.Forms.CheckBox isElectronicCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox linkText;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
    }
}