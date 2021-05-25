
namespace Biblioteka
{
    partial class WriteMessageForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.msgContentTextBox = new System.Windows.Forms.TextBox();
            this.addAddresseeButton = new System.Windows.Forms.Button();
            this.addresseeLabel = new System.Windows.Forms.Label();
            this.titleConstLabel = new System.Windows.Forms.Label();
            this.toConstLabel = new System.Windows.Forms.Label();
            this.msgTitleTextBox = new System.Windows.Forms.TextBox();
            this.cancelMsgButton = new System.Windows.Forms.Button();
            this.sendMsgButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.msgContentTextBox);
            this.panel1.Controls.Add(this.addAddresseeButton);
            this.panel1.Controls.Add(this.addresseeLabel);
            this.panel1.Controls.Add(this.titleConstLabel);
            this.panel1.Controls.Add(this.toConstLabel);
            this.panel1.Controls.Add(this.msgTitleTextBox);
            this.panel1.Controls.Add(this.cancelMsgButton);
            this.panel1.Controls.Add(this.sendMsgButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 366);
            this.panel1.TabIndex = 0;
            // 
            // msgContentTextBox
            // 
            this.msgContentTextBox.Location = new System.Drawing.Point(3, 68);
            this.msgContentTextBox.Multiline = true;
            this.msgContentTextBox.Name = "msgContentTextBox";
            this.msgContentTextBox.Size = new System.Drawing.Size(538, 257);
            this.msgContentTextBox.TabIndex = 9;
            // 
            // addAddresseeButton
            // 
            this.addAddresseeButton.Location = new System.Drawing.Point(466, 13);
            this.addAddresseeButton.Name = "addAddresseeButton";
            this.addAddresseeButton.Size = new System.Drawing.Size(75, 23);
            this.addAddresseeButton.TabIndex = 8;
            this.addAddresseeButton.Text = "Dodaj";
            this.addAddresseeButton.UseVisualStyleBackColor = true;
            this.addAddresseeButton.Click += new System.EventHandler(this.addAddresseeButton_Click);
            // 
            // addresseeLabel
            // 
            this.addresseeLabel.AutoSize = true;
            this.addresseeLabel.Location = new System.Drawing.Point(47, 18);
            this.addresseeLabel.Name = "addresseeLabel";
            this.addresseeLabel.Size = new System.Drawing.Size(35, 13);
            this.addresseeLabel.TabIndex = 7;
            this.addresseeLabel.Text = "label3";
            // 
            // titleConstLabel
            // 
            this.titleConstLabel.AutoSize = true;
            this.titleConstLabel.Location = new System.Drawing.Point(11, 49);
            this.titleConstLabel.Name = "titleConstLabel";
            this.titleConstLabel.Size = new System.Drawing.Size(38, 13);
            this.titleConstLabel.TabIndex = 6;
            this.titleConstLabel.Text = "Tytuł: ";
            // 
            // toConstLabel
            // 
            this.toConstLabel.AutoSize = true;
            this.toConstLabel.Location = new System.Drawing.Point(14, 18);
            this.toConstLabel.Name = "toConstLabel";
            this.toConstLabel.Size = new System.Drawing.Size(27, 13);
            this.toConstLabel.TabIndex = 5;
            this.toConstLabel.Text = "Do: ";
            // 
            // msgTitleTextBox
            // 
            this.msgTitleTextBox.Location = new System.Drawing.Point(50, 42);
            this.msgTitleTextBox.Name = "msgTitleTextBox";
            this.msgTitleTextBox.Size = new System.Drawing.Size(491, 20);
            this.msgTitleTextBox.TabIndex = 4;
            // 
            // cancelMsgButton
            // 
            this.cancelMsgButton.Location = new System.Drawing.Point(274, 331);
            this.cancelMsgButton.Name = "cancelMsgButton";
            this.cancelMsgButton.Size = new System.Drawing.Size(75, 23);
            this.cancelMsgButton.TabIndex = 1;
            this.cancelMsgButton.Text = "Anuluj";
            this.cancelMsgButton.UseVisualStyleBackColor = true;
            this.cancelMsgButton.Click += new System.EventHandler(this.cancelMsgButton_Click);
            // 
            // sendMsgButton
            // 
            this.sendMsgButton.Location = new System.Drawing.Point(175, 331);
            this.sendMsgButton.Name = "sendMsgButton";
            this.sendMsgButton.Size = new System.Drawing.Size(75, 23);
            this.sendMsgButton.TabIndex = 0;
            this.sendMsgButton.Text = "Wyślij";
            this.sendMsgButton.UseVisualStyleBackColor = true;
            this.sendMsgButton.Click += new System.EventHandler(this.sendMsgButton_Click);
            // 
            // WriteMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 390);
            this.Controls.Add(this.panel1);
            this.Name = "WriteMessageForm";
            this.Text = "WriteMessageForm";
            this.Load += new System.EventHandler(this.WriteMessageForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleConstLabel;
        private System.Windows.Forms.Label toConstLabel;
        private System.Windows.Forms.TextBox msgTitleTextBox;
        private System.Windows.Forms.Button cancelMsgButton;
        private System.Windows.Forms.Button sendMsgButton;
        private System.Windows.Forms.Button addAddresseeButton;
        private System.Windows.Forms.Label addresseeLabel;
        private System.Windows.Forms.TextBox msgContentTextBox;
    }
}