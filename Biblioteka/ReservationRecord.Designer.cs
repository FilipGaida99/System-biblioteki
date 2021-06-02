
namespace Biblioteka
{
    partial class ReservationRecord
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bookTitle = new System.Windows.Forms.Label();
            this.authors = new System.Windows.Forms.Label();
            this.readerName = new System.Windows.Forms.Label();
            this.readerSurname = new System.Windows.Forms.Label();
            this.reservationDate = new System.Windows.Forms.Label();
            this.readerId = new System.Windows.Forms.Label();
            this.checkoutButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Książka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Autorzy:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Imię czytelnika:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nazwisko czytelnika:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Data rezerwacji:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "ID czytelnika:";
            // 
            // bookTitle
            // 
            this.bookTitle.AutoSize = true;
            this.bookTitle.Location = new System.Drawing.Point(115, 14);
            this.bookTitle.Name = "bookTitle";
            this.bookTitle.Size = new System.Drawing.Size(35, 13);
            this.bookTitle.TabIndex = 6;
            this.bookTitle.Text = "label7";
            // 
            // authors
            // 
            this.authors.AutoSize = true;
            this.authors.Location = new System.Drawing.Point(115, 36);
            this.authors.Name = "authors";
            this.authors.Size = new System.Drawing.Size(35, 13);
            this.authors.TabIndex = 7;
            this.authors.Text = "label7";
            // 
            // readerName
            // 
            this.readerName.AutoSize = true;
            this.readerName.Location = new System.Drawing.Point(115, 80);
            this.readerName.Name = "readerName";
            this.readerName.Size = new System.Drawing.Size(35, 13);
            this.readerName.TabIndex = 8;
            this.readerName.Text = "label7";
            // 
            // readerSurname
            // 
            this.readerSurname.AutoSize = true;
            this.readerSurname.Location = new System.Drawing.Point(115, 102);
            this.readerSurname.Name = "readerSurname";
            this.readerSurname.Size = new System.Drawing.Size(35, 13);
            this.readerSurname.TabIndex = 9;
            this.readerSurname.Text = "label7";
            // 
            // reservationDate
            // 
            this.reservationDate.AutoSize = true;
            this.reservationDate.Location = new System.Drawing.Point(115, 124);
            this.reservationDate.Name = "reservationDate";
            this.reservationDate.Size = new System.Drawing.Size(35, 13);
            this.reservationDate.TabIndex = 10;
            this.reservationDate.Text = "label7";
            // 
            // readerId
            // 
            this.readerId.AutoSize = true;
            this.readerId.Location = new System.Drawing.Point(115, 58);
            this.readerId.Name = "readerId";
            this.readerId.Size = new System.Drawing.Size(35, 13);
            this.readerId.TabIndex = 11;
            this.readerId.Text = "label7";
            // 
            // checkoutButton
            // 
            this.checkoutButton.Location = new System.Drawing.Point(365, 58);
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.Size = new System.Drawing.Size(75, 35);
            this.checkoutButton.TabIndex = 12;
            this.checkoutButton.Text = "Wypożycz";
            this.checkoutButton.UseVisualStyleBackColor = true;
            this.checkoutButton.Click += new System.EventHandler(this.button_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(284, 58);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 35);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // ReservationRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.checkoutButton);
            this.Controls.Add(this.readerId);
            this.Controls.Add(this.reservationDate);
            this.Controls.Add(this.readerSurname);
            this.Controls.Add(this.readerName);
            this.Controls.Add(this.authors);
            this.Controls.Add(this.bookTitle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReservationRecord";
            this.Size = new System.Drawing.Size(450, 151);
            this.Load += new System.EventHandler(this.ReservationRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label bookTitle;
        private System.Windows.Forms.Label authors;
        private System.Windows.Forms.Label readerName;
        private System.Windows.Forms.Label readerSurname;
        private System.Windows.Forms.Label reservationDate;
        private System.Windows.Forms.Label readerId;
        private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.Button deleteButton;
    }
}
