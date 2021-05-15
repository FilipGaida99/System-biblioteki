
namespace Biblioteka
{
    partial class BookSearch
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            this.searchText = new System.Windows.Forms.TextBox();
            this.descriptionSearchCheckBox = new System.Windows.Forms.CheckBox();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.publisherPicker = new Biblioteka.PublisherPicker();
            this.authorText = new System.Windows.Forms.TextBox();
            this.authorChooseButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.isbnText = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(40, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(42, 13);
            label1.TabIndex = 0;
            label1.Text = "Szukaj:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(49, 39);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 13);
            label2.TabIndex = 3;
            label2.Text = "Data:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label3.Location = new System.Drawing.Point(212, 29);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(18, 24);
            label3.TabIndex = 6;
            label3.Text = "–";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(47, 119);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(35, 13);
            label4.TabIndex = 8;
            label4.Text = "Autor:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(47, 64);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(35, 13);
            label5.TabIndex = 12;
            label5.Text = "ISBN:";
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(89, 6);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(121, 20);
            this.searchText.TabIndex = 1;
            // 
            // descriptionSearchCheckBox
            // 
            this.descriptionSearchCheckBox.AutoSize = true;
            this.descriptionSearchCheckBox.Location = new System.Drawing.Point(216, 9);
            this.descriptionSearchCheckBox.Name = "descriptionSearchCheckBox";
            this.descriptionSearchCheckBox.Size = new System.Drawing.Size(109, 17);
            this.descriptionSearchCheckBox.TabIndex = 2;
            this.descriptionSearchCheckBox.Text = "Szukaj w opisach";
            this.descriptionSearchCheckBox.UseVisualStyleBackColor = true;
            // 
            // startDatePicker
            // 
            this.startDatePicker.Checked = false;
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(89, 33);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.ShowCheckBox = true;
            this.startDatePicker.Size = new System.Drawing.Size(120, 20);
            this.startDatePicker.TabIndex = 3;
            this.startDatePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // endDatePicker
            // 
            this.endDatePicker.Checked = false;
            this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDatePicker.Location = new System.Drawing.Point(236, 33);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.ShowCheckBox = true;
            this.endDatePicker.Size = new System.Drawing.Size(121, 20);
            this.endDatePicker.TabIndex = 4;
            this.endDatePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // publisherPicker
            // 
            this.publisherPicker.Location = new System.Drawing.Point(3, 80);
            this.publisherPicker.Name = "publisherPicker";
            this.publisherPicker.PublisherName = "";
            this.publisherPicker.Size = new System.Drawing.Size(271, 30);
            this.publisherPicker.TabIndex = 6;
            // 
            // authorText
            // 
            this.authorText.Location = new System.Drawing.Point(89, 116);
            this.authorText.Name = "authorText";
            this.authorText.Size = new System.Drawing.Size(100, 20);
            this.authorText.TabIndex = 7;
            // 
            // authorChooseButton
            // 
            this.authorChooseButton.Location = new System.Drawing.Point(195, 114);
            this.authorChooseButton.Name = "authorChooseButton";
            this.authorChooseButton.Size = new System.Drawing.Size(75, 23);
            this.authorChooseButton.TabIndex = 8;
            this.authorChooseButton.Text = "Wybierz";
            this.authorChooseButton.UseVisualStyleBackColor = true;
            this.authorChooseButton.Click += new System.EventHandler(this.authorChooseButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(363, 6);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 136);
            this.searchButton.TabIndex = 9;
            this.searchButton.Text = "Szukaj";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // isbnText
            // 
            this.isbnText.Location = new System.Drawing.Point(89, 61);
            this.isbnText.Name = "isbnText";
            this.isbnText.Size = new System.Drawing.Size(100, 20);
            this.isbnText.TabIndex = 5;
            // 
            // BookSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.isbnText);
            this.Controls.Add(label5);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.authorChooseButton);
            this.Controls.Add(this.authorText);
            this.Controls.Add(label4);
            this.Controls.Add(this.publisherPicker);
            this.Controls.Add(label3);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(label2);
            this.Controls.Add(this.descriptionSearchCheckBox);
            this.Controls.Add(this.searchText);
            this.Controls.Add(label1);
            this.Name = "BookSearch";
            this.Size = new System.Drawing.Size(466, 145);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.CheckBox descriptionSearchCheckBox;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private PublisherPicker publisherPicker;
        private System.Windows.Forms.TextBox authorText;
        private System.Windows.Forms.Button authorChooseButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox isbnText;
    }
}
