
using System.IO;

namespace Biblioteka
{
    partial class BookManagementForm
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
            System.Windows.Forms.Label label2;
            this.addBookButton = new System.Windows.Forms.Button();
            this.modButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.bookList = new System.Windows.Forms.ListBox();
            this.addCopy = new System.Windows.Forms.Button();
            this.copyList = new System.Windows.Forms.ListBox();
            this.publishersButton = new System.Windows.Forms.Button();
            this.authorsButton = new System.Windows.Forms.Button();
            this.bookSearch = new Biblioteka.BookSearch();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label1.Location = new System.Drawing.Point(399, 254);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(106, 20);
            label1.TabIndex = 8;
            label1.Text = "Egzemplarze:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label2.Location = new System.Drawing.Point(12, 254);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(142, 20);
            label2.TabIndex = 9;
            label2.Text = "Znalezione książki:";
            // 
            // addBookButton
            // 
            this.addBookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addBookButton.Location = new System.Drawing.Point(15, 469);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(264, 42);
            this.addBookButton.TabIndex = 5;
            this.addBookButton.Text = "Dodaj nową książkę";
            this.addBookButton.UseVisualStyleBackColor = true;
            this.addBookButton.Click += new System.EventHandler(this.addBookButton_Click);
            // 
            // modButton
            // 
            this.modButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.modButton.Location = new System.Drawing.Point(285, 277);
            this.modButton.Name = "modButton";
            this.modButton.Size = new System.Drawing.Size(112, 42);
            this.modButton.TabIndex = 3;
            this.modButton.Text = "Modyfikuj";
            this.modButton.UseVisualStyleBackColor = true;
            this.modButton.Click += new System.EventHandler(this.modButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.deleteButton.Location = new System.Drawing.Point(285, 325);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(112, 42);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // bookList
            // 
            this.bookList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bookList.FormattingEnabled = true;
            this.bookList.ItemHeight = 20;
            this.bookList.Location = new System.Drawing.Point(15, 277);
            this.bookList.Name = "bookList";
            this.bookList.Size = new System.Drawing.Size(264, 184);
            this.bookList.TabIndex = 2;
            this.bookList.SelectedIndexChanged += new System.EventHandler(this.bookList_SelectedIndexChanged);
            // 
            // addCopy
            // 
            this.addCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addCopy.Location = new System.Drawing.Point(403, 469);
            this.addCopy.Name = "addCopy";
            this.addCopy.Size = new System.Drawing.Size(264, 42);
            this.addCopy.TabIndex = 7;
            this.addCopy.Text = "Dodaj egzemplarz";
            this.addCopy.UseVisualStyleBackColor = true;
            this.addCopy.Click += new System.EventHandler(this.addCopy_Click);
            // 
            // copyList
            // 
            this.copyList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.copyList.FormattingEnabled = true;
            this.copyList.ItemHeight = 20;
            this.copyList.Location = new System.Drawing.Point(403, 277);
            this.copyList.Name = "copyList";
            this.copyList.Size = new System.Drawing.Size(264, 184);
            this.copyList.TabIndex = 6;
            // 
            // publishersButton
            // 
            this.publishersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.publishersButton.Location = new System.Drawing.Point(15, 517);
            this.publishersButton.Name = "publishersButton";
            this.publishersButton.Size = new System.Drawing.Size(264, 42);
            this.publishersButton.TabIndex = 10;
            this.publishersButton.Text = "Wydawnictwa";
            this.publishersButton.UseVisualStyleBackColor = true;
            this.publishersButton.Click += new System.EventHandler(this.publishersButton_Click);
            // 
            // authorsButton
            // 
            this.authorsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.authorsButton.Location = new System.Drawing.Point(403, 517);
            this.authorsButton.Name = "authorsButton";
            this.authorsButton.Size = new System.Drawing.Size(264, 42);
            this.authorsButton.TabIndex = 11;
            this.authorsButton.Text = "Autorzy";
            this.authorsButton.UseVisualStyleBackColor = true;
            this.authorsButton.Click += new System.EventHandler(this.authorsButton_Click);
            // 
            // bookSearch
            // 
            this.bookSearch.Location = new System.Drawing.Point(29, 12);
            this.bookSearch.Name = "bookSearch";
            this.bookSearch.Size = new System.Drawing.Size(638, 238);
            this.bookSearch.TabIndex = 1;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = (new FileInfo(@"Help/help.chm")).FullName;
            // 
            // BookManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 591);
            this.Controls.Add(this.authorsButton);
            this.Controls.Add(this.publishersButton);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.bookSearch);
            this.Controls.Add(this.copyList);
            this.Controls.Add(this.addCopy);
            this.Controls.Add(this.addBookButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.bookList);
            this.Controls.Add(this.modButton);
            this.Name = "BookManagementForm";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Zarządzanie książkami";
            this.Load += new System.EventHandler(this.BookManagementForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.ListBox bookList;
        private System.Windows.Forms.Button modButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addCopy;
        private System.Windows.Forms.ListBox copyList;
        private BookSearch bookSearch;
        private System.Windows.Forms.Button publishersButton;
        private System.Windows.Forms.Button authorsButton;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}