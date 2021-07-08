
using System.IO;

namespace Biblioteka
{
    partial class ExtensionForm
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
            this.acceptButton = new System.Windows.Forms.Button();
            this.discardButton = new System.Windows.Forms.Button();
            this.extensionList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(422, 165);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 40);
            this.acceptButton.TabIndex = 1;
            this.acceptButton.Text = "Zaakceptuj";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // discardButton
            // 
            this.discardButton.Location = new System.Drawing.Point(422, 224);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(75, 40);
            this.discardButton.TabIndex = 2;
            this.discardButton.Text = "Odrzuć";
            this.discardButton.UseVisualStyleBackColor = true;
            this.discardButton.Click += new System.EventHandler(this.discardButton_Click);
            // 
            // extensionList
            // 
            this.extensionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.extensionList.HideSelection = false;
            this.extensionList.Location = new System.Drawing.Point(12, 12);
            this.extensionList.Name = "extensionList";
            this.extensionList.Size = new System.Drawing.Size(404, 426);
            this.extensionList.TabIndex = 3;
            this.extensionList.UseCompatibleStateImageBehavior = false;
            this.extensionList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Imię";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nazwisko";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID Czytelnika";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Data zwrotu";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Książka";
            this.columnHeader5.Width = 140;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = (new FileInfo(@"Help/help.chm")).FullName;
            // 
            // ExtensionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 450);
            this.Controls.Add(this.extensionList);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.acceptButton);
            this.Name = "ExtensionForm";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "ExtensionForm";
            this.Load += new System.EventHandler(this.ExtensionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button discardButton;
        private System.Windows.Forms.ListView extensionList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}