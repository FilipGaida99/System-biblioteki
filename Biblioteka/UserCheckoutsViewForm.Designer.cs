
namespace Biblioteka
{
    partial class UserCheckoutsViewForm
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
            this.extensionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // extensionButton
            // 
            this.extensionButton.Location = new System.Drawing.Point(244, 9);
            this.extensionButton.Name = "extensionButton";
            this.extensionButton.Size = new System.Drawing.Size(75, 23);
            this.extensionButton.TabIndex = 4;
            this.extensionButton.Text = "Prolonguj";
            this.extensionButton.UseVisualStyleBackColor = true;
            this.extensionButton.Click += new System.EventHandler(this.extensionButton_Click);
            // 
            // UserCheckoutsViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(664, 297);
            this.Controls.Add(this.extensionButton);
            this.Name = "UserCheckoutsViewForm";
            this.Controls.SetChildIndex(this.checkoutsList, 0);
            this.Controls.SetChildIndex(this.returnedCheckBox, 0);
            this.Controls.SetChildIndex(this.extensionButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button extensionButton;
    }
}
