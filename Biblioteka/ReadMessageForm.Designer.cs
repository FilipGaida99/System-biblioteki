
namespace Biblioteka
{
    partial class ReadMessageForm
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
            this.readMsgPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleConstLabel = new System.Windows.Forms.Label();
            this.msgTextBox = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.toConstLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.fromConstLabel = new System.Windows.Forms.Label();
            this.readMsgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // readMsgPanel
            // 
            this.readMsgPanel.Controls.Add(this.titleLabel);
            this.readMsgPanel.Controls.Add(this.titleConstLabel);
            this.readMsgPanel.Controls.Add(this.msgTextBox);
            this.readMsgPanel.Controls.Add(this.dateLabel);
            this.readMsgPanel.Controls.Add(this.toLabel);
            this.readMsgPanel.Controls.Add(this.toConstLabel);
            this.readMsgPanel.Controls.Add(this.fromLabel);
            this.readMsgPanel.Controls.Add(this.fromConstLabel);
            this.readMsgPanel.Location = new System.Drawing.Point(12, 12);
            this.readMsgPanel.Name = "readMsgPanel";
            this.readMsgPanel.Size = new System.Drawing.Size(526, 414);
            this.readMsgPanel.TabIndex = 3;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(36, 39);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(35, 13);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "label3";
            // 
            // titleConstLabel
            // 
            this.titleConstLabel.AutoSize = true;
            this.titleConstLabel.Location = new System.Drawing.Point(3, 39);
            this.titleConstLabel.Name = "titleConstLabel";
            this.titleConstLabel.Size = new System.Drawing.Size(38, 13);
            this.titleConstLabel.TabIndex = 6;
            this.titleConstLabel.Text = "Tytuł: ";
            // 
            // msgTextBox
            // 
            this.msgTextBox.Location = new System.Drawing.Point(3, 55);
            this.msgTextBox.Multiline = true;
            this.msgTextBox.Name = "msgTextBox";
            this.msgTextBox.Size = new System.Drawing.Size(520, 356);
            this.msgTextBox.TabIndex = 5;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(3, 26);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(30, 13);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "Data";
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(36, 15);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(35, 13);
            this.toLabel.TabIndex = 3;
            this.toLabel.Text = "label2";
            // 
            // toConstLabel
            // 
            this.toConstLabel.AutoSize = true;
            this.toConstLabel.Location = new System.Drawing.Point(3, 13);
            this.toConstLabel.Name = "toConstLabel";
            this.toConstLabel.Size = new System.Drawing.Size(27, 13);
            this.toConstLabel.TabIndex = 2;
            this.toConstLabel.Text = "Do: ";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(36, 0);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(35, 13);
            this.fromLabel.TabIndex = 1;
            this.fromLabel.Text = "label1";
            // 
            // fromConstLabel
            // 
            this.fromConstLabel.AutoSize = true;
            this.fromConstLabel.Location = new System.Drawing.Point(3, 0);
            this.fromConstLabel.Name = "fromConstLabel";
            this.fromConstLabel.Size = new System.Drawing.Size(27, 13);
            this.fromConstLabel.TabIndex = 0;
            this.fromConstLabel.Text = "Od: ";
            // 
            // ReadMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 438);
            this.Controls.Add(this.readMsgPanel);
            this.Name = "ReadMessageForm";
            this.Text = "ReadMessageForm";
            this.readMsgPanel.ResumeLayout(false);
            this.readMsgPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel readMsgPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label titleConstLabel;
        private System.Windows.Forms.TextBox msgTextBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label toConstLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label fromConstLabel;
    }
}