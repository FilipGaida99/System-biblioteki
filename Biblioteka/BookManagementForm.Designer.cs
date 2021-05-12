﻿
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
            this.addBookButton = new System.Windows.Forms.Button();
            this.modButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.bookList = new System.Windows.Forms.ListBox();
            this.addCopy = new System.Windows.Forms.Button();
            this.copyList = new System.Windows.Forms.ListBox();
            this.bookSearch = new Biblioteka.BookSearch();
            this.SuspendLayout();
            // 
            // addBookButton
            // 
            this.addBookButton.Location = new System.Drawing.Point(13, 402);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(264, 42);
            this.addBookButton.TabIndex = 0;
            this.addBookButton.Text = "Dodaj nową książkę";
            this.addBookButton.UseVisualStyleBackColor = true;
            this.addBookButton.Click += new System.EventHandler(this.addBookButton_Click);
            // 
            // modButton
            // 
            this.modButton.Location = new System.Drawing.Point(283, 210);
            this.modButton.Name = "modButton";
            this.modButton.Size = new System.Drawing.Size(112, 23);
            this.modButton.TabIndex = 3;
            this.modButton.Text = "Modyfikuj";
            this.modButton.UseVisualStyleBackColor = true;
            this.modButton.Click += new System.EventHandler(this.modButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(283, 239);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(112, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // bookList
            // 
            this.bookList.FormattingEnabled = true;
            this.bookList.Location = new System.Drawing.Point(13, 210);
            this.bookList.Name = "bookList";
            this.bookList.Size = new System.Drawing.Size(264, 186);
            this.bookList.TabIndex = 1;
            this.bookList.SelectedIndexChanged += new System.EventHandler(this.bookList_SelectedIndexChanged);
            // 
            // addCopy
            // 
            this.addCopy.Location = new System.Drawing.Point(401, 402);
            this.addCopy.Name = "addCopy";
            this.addCopy.Size = new System.Drawing.Size(264, 42);
            this.addCopy.TabIndex = 4;
            this.addCopy.Text = "Dodaj egzemplarz";
            this.addCopy.UseVisualStyleBackColor = true;
            this.addCopy.Click += new System.EventHandler(this.addCopy_Click);
            // 
            // copyList
            // 
            this.copyList.FormattingEnabled = true;
            this.copyList.Location = new System.Drawing.Point(401, 210);
            this.copyList.Name = "copyList";
            this.copyList.Size = new System.Drawing.Size(264, 186);
            this.copyList.TabIndex = 5;
            // 
            // bookSearch
            // 
            this.bookSearch.Location = new System.Drawing.Point(97, 12);
            this.bookSearch.Name = "bookSearch";
            this.bookSearch.Size = new System.Drawing.Size(466, 145);
            this.bookSearch.TabIndex = 6;
            // 
            // BookManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 467);
            this.Controls.Add(this.bookSearch);
            this.Controls.Add(this.copyList);
            this.Controls.Add(this.addCopy);
            this.Controls.Add(this.addBookButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.bookList);
            this.Controls.Add(this.modButton);
            this.Name = "BookManagementForm";
            this.Text = "Zarządzanie książkami";
            this.Load += new System.EventHandler(this.BookManagementForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.ListBox bookList;
        private System.Windows.Forms.Button modButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addCopy;
        private System.Windows.Forms.ListBox copyList;
        private BookSearch bookSearch;
    }
}