
namespace Biblioteka
{
    partial class BookBrowse
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
            this.bookLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.bookSearch = new Biblioteka.BookSearch();
            this.SuspendLayout();
            // 
            // bookLayout
            // 
            this.bookLayout.AutoScroll = true;
            this.bookLayout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bookLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.bookLayout.Location = new System.Drawing.Point(12, 222);
            this.bookLayout.Name = "bookLayout";
            this.bookLayout.Size = new System.Drawing.Size(583, 400);
            this.bookLayout.TabIndex = 1;
            this.bookLayout.WrapContents = false;
            // 
            // bookSearch
            // 
            this.bookSearch.Location = new System.Drawing.Point(12, 12);
            this.bookSearch.Name = "bookSearch";
            this.bookSearch.Size = new System.Drawing.Size(583, 192);
            this.bookSearch.TabIndex = 0;
            // 
            // BookBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 634);
            this.Controls.Add(this.bookLayout);
            this.Controls.Add(this.bookSearch);
            this.Name = "BookBrowse";
            this.Text = "Przeglądanie księgozbioru";
            this.Load += new System.EventHandler(this.BookBrowse_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BookSearch bookSearch;
        private System.Windows.Forms.FlowLayoutPanel bookLayout;
    }
}