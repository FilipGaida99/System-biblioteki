
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.addButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.bookList = new System.Windows.Forms.ListBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.modButton = new System.Windows.Forms.Button();
            this.modPanel = new System.Windows.Forms.Panel();
            this.isbnText = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.titleText = new System.Windows.Forms.TextBox();
            this.descriptionText = new System.Windows.Forms.TextBox();
            this.publisherText = new System.Windows.Forms.TextBox();
            this.choosePublisherButton = new System.Windows.Forms.Button();
            this.autorsList = new System.Windows.Forms.ListBox();
            this.addAutorButton = new System.Windows.Forms.Button();
            this.deleteAutorButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.modPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(281, 400);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(213, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Dodaj nową książkę";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.modButton);
            this.mainPanel.Controls.Add(this.deleteButton);
            this.mainPanel.Controls.Add(this.bookList);
            this.mainPanel.Controls.Add(this.addButton);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(776, 426);
            this.mainPanel.TabIndex = 1;
            // 
            // bookList
            // 
            this.bookList.FormattingEnabled = true;
            this.bookList.Location = new System.Drawing.Point(94, 86);
            this.bookList.Name = "bookList";
            this.bookList.Size = new System.Drawing.Size(264, 186);
            this.bookList.TabIndex = 1;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(364, 117);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // modButton
            // 
            this.modButton.Location = new System.Drawing.Point(365, 86);
            this.modButton.Name = "modButton";
            this.modButton.Size = new System.Drawing.Size(75, 23);
            this.modButton.TabIndex = 3;
            this.modButton.Text = "Modyfikuj";
            this.modButton.UseVisualStyleBackColor = true;
            this.modButton.Click += new System.EventHandler(this.modButton_Click);
            // 
            // modPanel
            // 
            this.modPanel.Controls.Add(this.cancelButton);
            this.modPanel.Controls.Add(this.acceptButton);
            this.modPanel.Controls.Add(this.deleteAutorButton);
            this.modPanel.Controls.Add(this.addAutorButton);
            this.modPanel.Controls.Add(this.autorsList);
            this.modPanel.Controls.Add(label6);
            this.modPanel.Controls.Add(this.choosePublisherButton);
            this.modPanel.Controls.Add(this.publisherText);
            this.modPanel.Controls.Add(label5);
            this.modPanel.Controls.Add(this.descriptionText);
            this.modPanel.Controls.Add(this.titleText);
            this.modPanel.Controls.Add(label4);
            this.modPanel.Controls.Add(label3);
            this.modPanel.Controls.Add(this.datePicker);
            this.modPanel.Controls.Add(this.isbnText);
            this.modPanel.Controls.Add(label2);
            this.modPanel.Controls.Add(label1);
            this.modPanel.Location = new System.Drawing.Point(12, 9);
            this.modPanel.Name = "modPanel";
            this.modPanel.Size = new System.Drawing.Size(776, 426);
            this.modPanel.TabIndex = 4;
            this.modPanel.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(53, 43);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 13);
            label1.TabIndex = 0;
            label1.Text = "ISBN:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 69);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(78, 13);
            label2.TabIndex = 1;
            label2.Text = "Data Wydania:";
            // 
            // isbnText
            // 
            this.isbnText.Location = new System.Drawing.Point(94, 40);
            this.isbnText.Name = "isbnText";
            this.isbnText.Size = new System.Drawing.Size(100, 20);
            this.isbnText.TabIndex = 2;
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(94, 66);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(99, 20);
            this.datePicker.TabIndex = 3;
            this.datePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(362, 47);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(35, 13);
            label3.TabIndex = 4;
            label3.Text = "Tytuł:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(366, 73);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(31, 13);
            label4.TabIndex = 5;
            label4.Text = "Opis:";
            // 
            // titleText
            // 
            this.titleText.Location = new System.Drawing.Point(403, 43);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(194, 20);
            this.titleText.TabIndex = 6;
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(403, 70);
            this.descriptionText.Multiline = true;
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(194, 150);
            this.descriptionText.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(11, 94);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(77, 13);
            label5.TabIndex = 8;
            label5.Text = "Wydawnictwo:";
            // 
            // publisherText
            // 
            this.publisherText.Location = new System.Drawing.Point(94, 91);
            this.publisherText.Name = "publisherText";
            this.publisherText.Size = new System.Drawing.Size(100, 20);
            this.publisherText.TabIndex = 9;
            // 
            // choosePublisherButton
            // 
            this.choosePublisherButton.Location = new System.Drawing.Point(200, 89);
            this.choosePublisherButton.Name = "choosePublisherButton";
            this.choosePublisherButton.Size = new System.Drawing.Size(75, 23);
            this.choosePublisherButton.TabIndex = 10;
            this.choosePublisherButton.Text = "Wybierz";
            this.choosePublisherButton.UseVisualStyleBackColor = true;
            this.choosePublisherButton.Click += new System.EventHandler(this.choosePublisherButton_Click);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(43, 120);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(45, 13);
            label6.TabIndex = 11;
            label6.Text = "Autorzy:";
            // 
            // autorsList
            // 
            this.autorsList.FormattingEnabled = true;
            this.autorsList.Location = new System.Drawing.Point(95, 118);
            this.autorsList.Name = "autorsList";
            this.autorsList.Size = new System.Drawing.Size(99, 95);
            this.autorsList.TabIndex = 12;
            // 
            // addAutorButton
            // 
            this.addAutorButton.Location = new System.Drawing.Point(200, 118);
            this.addAutorButton.Name = "addAutorButton";
            this.addAutorButton.Size = new System.Drawing.Size(22, 23);
            this.addAutorButton.TabIndex = 13;
            this.addAutorButton.Text = "+";
            this.addAutorButton.UseVisualStyleBackColor = true;
            // 
            // deleteAutorButton
            // 
            this.deleteAutorButton.Location = new System.Drawing.Point(201, 148);
            this.deleteAutorButton.Name = "deleteAutorButton";
            this.deleteAutorButton.Size = new System.Drawing.Size(21, 23);
            this.deleteAutorButton.TabIndex = 14;
            this.deleteAutorButton.Text = "-";
            this.deleteAutorButton.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(257, 252);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 15;
            this.acceptButton.Text = "Akceptuj";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(338, 252);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // BookManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.modPanel);
            this.Controls.Add(this.mainPanel);
            this.Name = "BookManagementForm";
            this.Text = "BookManagementForm";
            this.Load += new System.EventHandler(this.BookManagementForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.modPanel.ResumeLayout(false);
            this.modPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ListBox bookList;
        private System.Windows.Forms.Button modButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Panel modPanel;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox isbnText;
        private System.Windows.Forms.TextBox descriptionText;
        private System.Windows.Forms.TextBox titleText;
        private System.Windows.Forms.Button choosePublisherButton;
        private System.Windows.Forms.TextBox publisherText;
        private System.Windows.Forms.ListBox autorsList;
        private System.Windows.Forms.Button addAutorButton;
        private System.Windows.Forms.Button deleteAutorButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
    }
}