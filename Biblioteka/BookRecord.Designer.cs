
namespace Biblioteka
{
    partial class BookRecord
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.publisherLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.authorsLabel = new System.Windows.Forms.Label();
            this.showButton = new System.Windows.Forms.Button();
            this.isbnLabel = new System.Windows.Forms.Label();
            this.checkoutToReader = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label1.Location = new System.Drawing.Point(3, 84);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(109, 20);
            label1.TabIndex = 1;
            label1.Text = "Wydawnictwo:";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label2.Location = new System.Drawing.Point(9, 64);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(103, 20);
            label2.TabIndex = 3;
            label2.Text = "Rok wydania:";
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label3.Location = new System.Drawing.Point(45, 104);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 20);
            label3.TabIndex = 5;
            label3.Text = "Autorzy:";
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label4.Location = new System.Drawing.Point(61, 44);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(51, 20);
            label4.TabIndex = 8;
            label4.Text = "ISBN:";
            //
            // titleLabel
            //
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel.Location = new System.Drawing.Point(20, 14);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(85, 29);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "label1";
            //
            // publisherLabel
            //
            this.publisherLabel.AutoSize = true;
            this.publisherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.publisherLabel.Location = new System.Drawing.Point(118, 84);
            this.publisherLabel.Name = "publisherLabel";
            this.publisherLabel.Size = new System.Drawing.Size(105, 20);
            this.publisherLabel.TabIndex = 2;
            this.publisherLabel.Text = "Wydawnictwo";
            //
            // yearLabel
            //
            this.yearLabel.AutoSize = true;
            this.yearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.yearLabel.Location = new System.Drawing.Point(118, 64);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(38, 20);
            this.yearLabel.TabIndex = 4;
            this.yearLabel.Text = "Rok";
            //
            // authorsLabel
            //
            this.authorsLabel.AutoSize = true;
            this.authorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.authorsLabel.Location = new System.Drawing.Point(118, 104);
            this.authorsLabel.Name = "authorsLabel";
            this.authorsLabel.Size = new System.Drawing.Size(63, 20);
            this.authorsLabel.TabIndex = 6;
            this.authorsLabel.Text = "Autorzy";
            //
            // showButton
            //
            this.showButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.showButton.Location = new System.Drawing.Point(475, 33);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(63, 55);
            this.showButton.TabIndex = 7;
            this.showButton.Text = "Pokaż";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            //
            // isbnLabel
            //
            this.isbnLabel.AutoSize = true;
            this.isbnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.isbnLabel.Location = new System.Drawing.Point(118, 44);
            this.isbnLabel.Name = "isbnLabel";
            this.isbnLabel.Size = new System.Drawing.Size(47, 20);
            this.isbnLabel.TabIndex = 9;
            this.isbnLabel.Text = "ISBN";
            //
            // checkoutToReader
            //
            this.checkoutToReader.Location = new System.Drawing.Point(279, 39);
            this.checkoutToReader.Name = "checkoutToReader";
            this.checkoutToReader.Size = new System.Drawing.Size(75, 23);
            this.checkoutToReader.TabIndex = 10;
            this.checkoutToReader.Text = "Wypożycz";
            this.checkoutToReader.UseVisualStyleBackColor = true;
            this.checkoutToReader.Click += new System.EventHandler(this.checkoutToReader_Click);
            //
            // BookRecord
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.checkoutToReader);
            this.Controls.Add(this.isbnLabel);
            this.Controls.Add(label4);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.authorsLabel);
            this.Controls.Add(label3);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(label2);
            this.Controls.Add(this.publisherLabel);
            this.Controls.Add(label1);
            this.Controls.Add(this.titleLabel);
            this.Name = "BookRecord";
            this.Size = new System.Drawing.Size(557, 129);
            this.Load += new System.EventHandler(this.BookRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label publisherLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label authorsLabel;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Label isbnLabel;
        private System.Windows.Forms.Button checkoutToReader;
    }
}
