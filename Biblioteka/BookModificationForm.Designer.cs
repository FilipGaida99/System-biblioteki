
namespace Biblioteka
{
    partial class BookModificationForm
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
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label7;
            this.cancelButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.deleteAutorButton = new System.Windows.Forms.Button();
            this.addAutorButton = new System.Windows.Forms.Button();
            this.authorsList = new System.Windows.Forms.ListBox();
            this.descriptionText = new System.Windows.Forms.TextBox();
            this.titleText = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.isbnText = new System.Windows.Forms.TextBox();
            this.daySpanPicker = new System.Windows.Forms.NumericUpDown();
            this.publisherPicker = new Biblioteka.PublisherPicker();
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.daySpanPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label6.Location = new System.Drawing.Point(55, 145);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(67, 20);
            label6.TabIndex = 11;
            label6.Text = "Autorzy:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label4.Location = new System.Drawing.Point(369, 57);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(45, 20);
            label4.TabIndex = 5;
            label4.Text = "Opis:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label3.Location = new System.Drawing.Point(367, 18);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(47, 20);
            label3.TabIndex = 4;
            label3.Text = "Tytuł:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label2.Location = new System.Drawing.Point(9, 52);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(113, 20);
            label2.TabIndex = 1;
            label2.Text = "Data Wydania:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label1.Location = new System.Drawing.Point(71, 21);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 20);
            label1.TabIndex = 0;
            label1.Text = "ISBN:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.SystemColors.Control;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label7.Location = new System.Drawing.Point(32, 84);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(90, 20);
            label7.TabIndex = 18;
            label7.Text = "Okres (dni):";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cancelButton.Location = new System.Drawing.Point(327, 283);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(91, 38);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.acceptButton.Location = new System.Drawing.Point(229, 283);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(92, 38);
            this.acceptButton.TabIndex = 16;
            this.acceptButton.Text = "Akceptuj";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // deleteAutorButton
            // 
            this.deleteAutorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.deleteAutorButton.Location = new System.Drawing.Point(271, 184);
            this.deleteAutorButton.Name = "deleteAutorButton";
            this.deleteAutorButton.Size = new System.Drawing.Size(30, 30);
            this.deleteAutorButton.TabIndex = 8;
            this.deleteAutorButton.Text = "-";
            this.deleteAutorButton.UseVisualStyleBackColor = true;
            this.deleteAutorButton.Click += new System.EventHandler(this.deleteAutorButton_Click);
            // 
            // addAutorButton
            // 
            this.addAutorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addAutorButton.Location = new System.Drawing.Point(271, 148);
            this.addAutorButton.Name = "addAutorButton";
            this.addAutorButton.Size = new System.Drawing.Size(30, 30);
            this.addAutorButton.TabIndex = 7;
            this.addAutorButton.Text = "+";
            this.addAutorButton.UseVisualStyleBackColor = true;
            this.addAutorButton.Click += new System.EventHandler(this.addAutorButton_Click);
            // 
            // authorsList
            // 
            this.authorsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.authorsList.FormattingEnabled = true;
            this.authorsList.ItemHeight = 20;
            this.authorsList.Location = new System.Drawing.Point(120, 145);
            this.authorsList.Name = "authorsList";
            this.authorsList.Size = new System.Drawing.Size(145, 124);
            this.authorsList.TabIndex = 12;
            // 
            // descriptionText
            // 
            this.descriptionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.descriptionText.Location = new System.Drawing.Point(418, 57);
            this.descriptionText.MaxLength = 4000;
            this.descriptionText.Multiline = true;
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(272, 174);
            this.descriptionText.TabIndex = 4;
            // 
            // titleText
            // 
            this.titleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.titleText.Location = new System.Drawing.Point(418, 15);
            this.titleText.MaxLength = 200;
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(272, 26);
            this.titleText.TabIndex = 2;
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "";
            this.datePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(121, 50);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(144, 26);
            this.datePicker.TabIndex = 3;
            this.datePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // isbnText
            // 
            this.isbnText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.isbnText.Location = new System.Drawing.Point(121, 18);
            this.isbnText.MaxLength = 17;
            this.isbnText.Name = "isbnText";
            this.isbnText.Size = new System.Drawing.Size(144, 26);
            this.isbnText.TabIndex = 1;
            // 
            // daySpanPicker
            // 
            this.daySpanPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.daySpanPicker.Location = new System.Drawing.Point(120, 82);
            this.daySpanPicker.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.daySpanPicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.daySpanPicker.Name = "daySpanPicker";
            this.daySpanPicker.Size = new System.Drawing.Size(145, 26);
            this.daySpanPicker.TabIndex = 5;
            this.daySpanPicker.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // publisherPicker
            // 
            this.publisherPicker.Location = new System.Drawing.Point(12, 107);
            this.publisherPicker.Name = "publisherPicker";
            this.publisherPicker.PublisherName = "";
            this.publisherPicker.Size = new System.Drawing.Size(338, 35);
            this.publisherPicker.TabIndex = 6;
            // 
            // BookModificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 334);
            this.Controls.Add(this.daySpanPicker);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.descriptionText);
            this.Controls.Add(this.deleteAutorButton);
            this.Controls.Add(this.addAutorButton);
            this.Controls.Add(this.authorsList);
            this.Controls.Add(this.isbnText);
            this.Controls.Add(label6);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(label3);
            this.Controls.Add(label4);
            this.Controls.Add(this.titleText);
            this.Controls.Add(this.publisherPicker);
            this.Controls.Add(label7);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Name = "BookModificationForm";
            this.Text = "Modyfikacja ksiązki";
            this.Load += new System.EventHandler(this.BookModificationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.daySpanPicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button deleteAutorButton;
        private System.Windows.Forms.Button addAutorButton;
        private System.Windows.Forms.ListBox authorsList;
        private System.Windows.Forms.TextBox descriptionText;
        private System.Windows.Forms.TextBox titleText;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox isbnText;
        private System.Windows.Forms.NumericUpDown daySpanPicker;
        private PublisherPicker publisherPicker;
    }
}