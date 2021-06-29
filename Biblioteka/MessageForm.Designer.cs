
namespace Biblioteka
{
    partial class MessageForm
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
            this.msgListFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.writeMsgButton = new System.Windows.Forms.Button();
            this.receivedMsgButton = new System.Windows.Forms.Button();
            this.sentMsgButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.msgListFlowPanel);
            this.panel1.Controls.Add(this.writeMsgButton);
            this.panel1.Controls.Add(this.receivedMsgButton);
            this.panel1.Controls.Add(this.sentMsgButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 426);
            this.panel1.TabIndex = 0;
            // 
            // msgListFlowPanel
            // 
            this.msgListFlowPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.msgListFlowPanel.Location = new System.Drawing.Point(157, 5);
            this.msgListFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.msgListFlowPanel.Name = "msgListFlowPanel";
            this.msgListFlowPanel.Size = new System.Drawing.Size(524, 418);
            this.msgListFlowPanel.TabIndex = 4;
            // 
            // writeMsgButton
            // 
            this.writeMsgButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.writeMsgButton.Location = new System.Drawing.Point(4, 5);
            this.writeMsgButton.Name = "writeMsgButton";
            this.writeMsgButton.Size = new System.Drawing.Size(147, 50);
            this.writeMsgButton.TabIndex = 3;
            this.writeMsgButton.Text = "Wyślij wiadomość";
            this.writeMsgButton.UseVisualStyleBackColor = false;
            this.writeMsgButton.Click += new System.EventHandler(this.sendMsgButton_Click);
            // 
            // receivedMsgButton
            // 
            this.receivedMsgButton.Location = new System.Drawing.Point(4, 166);
            this.receivedMsgButton.Name = "receivedMsgButton";
            this.receivedMsgButton.Size = new System.Drawing.Size(147, 50);
            this.receivedMsgButton.TabIndex = 1;
            this.receivedMsgButton.Text = "Odebrane wiadomości";
            this.receivedMsgButton.UseVisualStyleBackColor = true;
            this.receivedMsgButton.Click += new System.EventHandler(this.receivedMsgButton_Click);
            // 
            // sentMsgButton
            // 
            this.sentMsgButton.Location = new System.Drawing.Point(4, 222);
            this.sentMsgButton.Name = "sentMsgButton";
            this.sentMsgButton.Size = new System.Drawing.Size(148, 50);
            this.sentMsgButton.TabIndex = 0;
            this.sentMsgButton.Text = "Wysłane wiadomości";
            this.sentMsgButton.UseVisualStyleBackColor = true;
            this.sentMsgButton.Click += new System.EventHandler(this.sentMsgButton_Click);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(707, 450);
            this.Controls.Add(this.panel1);
            this.Name = "MessageForm";
            this.Text = "MessageForm";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button receivedMsgButton;
        private System.Windows.Forms.Button sentMsgButton;
        private System.Windows.Forms.Button writeMsgButton;
        private System.Windows.Forms.FlowLayoutPanel msgListFlowPanel;
    }
}