
namespace Biblioteka
{
    partial class ExhibitionManagementForm
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
            this.newButton = new System.Windows.Forms.Button();
            this.exhibitionList = new System.Windows.Forms.ListBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(530, 269);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(100, 34);
            this.newButton.TabIndex = 2;
            this.newButton.Text = "Dodaj";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // exhibitionList
            // 
            this.exhibitionList.FormattingEnabled = true;
            this.exhibitionList.Location = new System.Drawing.Point(13, 13);
            this.exhibitionList.Name = "exhibitionList";
            this.exhibitionList.Size = new System.Drawing.Size(491, 290);
            this.exhibitionList.TabIndex = 3;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(530, 213);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 34);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(530, 144);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(100, 34);
            this.modifyButton.TabIndex = 5;
            this.modifyButton.Text = "Modyfikuj";
            this.modifyButton.UseVisualStyleBackColor = true;
            // 
            // ExhibitionManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 327);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.exhibitionList);
            this.Controls.Add(this.newButton);
            this.Name = "ExhibitionManagementForm";
            this.Text = "Wystawy - Zarządzanie";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.ListBox exhibitionList;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button modifyButton;
    }
}