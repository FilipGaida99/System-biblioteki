
namespace Biblioteka
{
    partial class ExhibitionViewerForm
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
            this.exhibitionList = new System.Windows.Forms.ListBox();
            this.showButton = new System.Windows.Forms.Button();
            this.exhibitionDetails1 = new Biblioteka.ExhibitionDetails();
            this.SuspendLayout();
            // 
            // exhibitionList
            // 
            this.exhibitionList.FormattingEnabled = true;
            this.exhibitionList.Location = new System.Drawing.Point(13, 13);
            this.exhibitionList.Name = "exhibitionList";
            this.exhibitionList.Size = new System.Drawing.Size(491, 147);
            this.exhibitionList.TabIndex = 0;
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(510, 58);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(100, 54);
            this.showButton.TabIndex = 1;
            this.showButton.Text = "Pokaż";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // exhibitionDetails1
            // 
            this.exhibitionDetails1.Location = new System.Drawing.Point(13, 167);
            this.exhibitionDetails1.Name = "exhibitionDetails1";
            this.exhibitionDetails1.Size = new System.Drawing.Size(597, 271);
            this.exhibitionDetails1.TabIndex = 2;
            // 
            // ExhibitionViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 450);
            this.Controls.Add(this.exhibitionDetails1);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.exhibitionList);
            this.Name = "ExhibitionViewerForm";
            this.Text = "Wystawy";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox exhibitionList;
        private System.Windows.Forms.Button showButton;
        private ExhibitionDetails exhibitionDetails1;
    }
}