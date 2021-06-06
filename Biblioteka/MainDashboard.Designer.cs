
namespace Biblioteka
{
    partial class MainDashboard
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

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.panelLibrarian = new System.Windows.Forms.Panel();
            this.reportButton = new System.Windows.Forms.Button();
            this.prolognationButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.checkoutButton = new System.Windows.Forms.Button();
            this.booksManagementButton = new System.Windows.Forms.Button();
            this.librariansManagementButton = new System.Windows.Forms.Button();
            this.readersManagementButton = new System.Windows.Forms.Button();
            this.exhibitionManagementButton = new System.Windows.Forms.Button();
            this.signButton = new System.Windows.Forms.Button();
            this.exhibitionButton = new System.Windows.Forms.Button();
            this.booksButton = new System.Windows.Forms.Button();
            this.panelReader = new System.Windows.Forms.Panel();
            this.bookingButton = new System.Windows.Forms.Button();
            this.lendButton = new System.Windows.Forms.Button();
            this.messagesButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.panelLibrarian.SuspendLayout();
            this.panelReader.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label1.Location = new System.Drawing.Point(182, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(143, 29);
            label1.TabIndex = 1;
            label1.Text = "Zarządzanie";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label2.Location = new System.Drawing.Point(182, 88);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(165, 29);
            label2.TabIndex = 5;
            label2.Text = "Wypożyczenia";
            // 
            // panelLibrarian
            // 
            this.panelLibrarian.Controls.Add(this.reportButton);
            this.panelLibrarian.Controls.Add(this.prolognationButton);
            this.panelLibrarian.Controls.Add(this.returnButton);
            this.panelLibrarian.Controls.Add(this.checkoutButton);
            this.panelLibrarian.Controls.Add(label2);
            this.panelLibrarian.Controls.Add(this.booksManagementButton);
            this.panelLibrarian.Controls.Add(this.librariansManagementButton);
            this.panelLibrarian.Controls.Add(this.readersManagementButton);
            this.panelLibrarian.Controls.Add(label1);
            this.panelLibrarian.Controls.Add(this.exhibitionManagementButton);
            this.panelLibrarian.Location = new System.Drawing.Point(12, 12);
            this.panelLibrarian.Name = "panelLibrarian";
            this.panelLibrarian.Size = new System.Drawing.Size(510, 287);
            this.panelLibrarian.TabIndex = 1;
            this.panelLibrarian.Visible = false;
            // 
            // reportButton
            // 
            this.reportButton.Enabled = false;
            this.reportButton.Location = new System.Drawing.Point(122, 222);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(265, 23);
            this.reportButton.TabIndex = 0;
            this.reportButton.Text = "Generuj raport";
            this.reportButton.UseVisualStyleBackColor = true;
            // 
            // prolognationButton
            // 
            this.prolognationButton.Location = new System.Drawing.Point(312, 135);
            this.prolognationButton.Name = "prolognationButton";
            this.prolognationButton.Size = new System.Drawing.Size(75, 23);
            this.prolognationButton.TabIndex = 8;
            this.prolognationButton.Text = "Prolongata";
            this.prolognationButton.UseVisualStyleBackColor = true;
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(217, 135);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(75, 23);
            this.returnButton.TabIndex = 7;
            this.returnButton.Text = "Zwrot";
            this.returnButton.UseVisualStyleBackColor = true;
            // 
            // checkoutButton
            // 
            this.checkoutButton.Location = new System.Drawing.Point(122, 135);
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.Size = new System.Drawing.Size(75, 23);
            this.checkoutButton.TabIndex = 6;
            this.checkoutButton.Text = "Wydawanie";
            this.checkoutButton.UseVisualStyleBackColor = true;
            this.checkoutButton.Click += new System.EventHandler(this.checkoutButton_Click);
            // 
            // booksManagementButton
            // 
            this.booksManagementButton.Location = new System.Drawing.Point(336, 39);
            this.booksManagementButton.Name = "booksManagementButton";
            this.booksManagementButton.Size = new System.Drawing.Size(82, 34);
            this.booksManagementButton.TabIndex = 4;
            this.booksManagementButton.Text = "Książki";
            this.booksManagementButton.UseVisualStyleBackColor = true;
            this.booksManagementButton.Click += new System.EventHandler(this.booksManagementButton_Click);
            // 
            // librariansManagementButton
            // 
            this.librariansManagementButton.Enabled = false;
            this.librariansManagementButton.Location = new System.Drawing.Point(248, 39);
            this.librariansManagementButton.Name = "librariansManagementButton";
            this.librariansManagementButton.Size = new System.Drawing.Size(82, 34);
            this.librariansManagementButton.TabIndex = 3;
            this.librariansManagementButton.Text = "Pracownicy";
            this.librariansManagementButton.UseVisualStyleBackColor = true;
            // 
            // readersManagementButton
            // 
            this.readersManagementButton.Location = new System.Drawing.Point(160, 39);
            this.readersManagementButton.Name = "readersManagementButton";
            this.readersManagementButton.Size = new System.Drawing.Size(82, 34);
            this.readersManagementButton.TabIndex = 2;
            this.readersManagementButton.Text = "Czytelnicy";
            this.readersManagementButton.UseVisualStyleBackColor = true;
            // 
            // exhibitionManagementButton
            // 
            this.exhibitionManagementButton.Location = new System.Drawing.Point(72, 39);
            this.exhibitionManagementButton.Name = "exhibitionManagementButton";
            this.exhibitionManagementButton.Size = new System.Drawing.Size(82, 34);
            this.exhibitionManagementButton.TabIndex = 0;
            this.exhibitionManagementButton.Text = "Wystawy";
            this.exhibitionManagementButton.UseVisualStyleBackColor = true;
            this.exhibitionManagementButton.Click += new System.EventHandler(this.exhibitionManagementButton_Click);
            // 
            // signButton
            // 
            this.signButton.Location = new System.Drawing.Point(528, 12);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(91, 23);
            this.signButton.TabIndex = 2;
            this.signButton.Text = "Zaloguj";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.Click += new System.EventHandler(this.signButton_Click);
            // 
            // exhibitionButton
            // 
            this.exhibitionButton.Location = new System.Drawing.Point(528, 41);
            this.exhibitionButton.Name = "exhibitionButton";
            this.exhibitionButton.Size = new System.Drawing.Size(91, 30);
            this.exhibitionButton.TabIndex = 0;
            this.exhibitionButton.Text = "Wystawy";
            this.exhibitionButton.UseVisualStyleBackColor = true;
            this.exhibitionButton.Click += new System.EventHandler(this.exhibitionButton_Click);
            // 
            // booksButton
            // 
            this.booksButton.Location = new System.Drawing.Point(528, 77);
            this.booksButton.Name = "booksButton";
            this.booksButton.Size = new System.Drawing.Size(91, 52);
            this.booksButton.TabIndex = 1;
            this.booksButton.Text = "Przeglądanie księgozbioru";
            this.booksButton.UseVisualStyleBackColor = true;
            this.booksButton.Click += new System.EventHandler(this.booksButton_Click);
            // 
            // panelReader
            // 
            this.panelReader.Controls.Add(this.bookingButton);
            this.panelReader.Controls.Add(this.lendButton);
            this.panelReader.Location = new System.Drawing.Point(43, 12);
            this.panelReader.Name = "panelReader";
            this.panelReader.Size = new System.Drawing.Size(247, 38);
            this.panelReader.TabIndex = 3;
            // 
            // bookingButton
            // 
            this.bookingButton.Location = new System.Drawing.Point(129, 3);
            this.bookingButton.Name = "bookingButton";
            this.bookingButton.Size = new System.Drawing.Size(114, 30);
            this.bookingButton.TabIndex = 1;
            this.bookingButton.Text = "Rezerwacje";
            this.bookingButton.UseVisualStyleBackColor = true;
            this.bookingButton.Click += new System.EventHandler(this.bookingButton_Click);
            // 
            // lendButton
            // 
            this.lendButton.Location = new System.Drawing.Point(3, 3);
            this.lendButton.Name = "lendButton";
            this.lendButton.Size = new System.Drawing.Size(120, 30);
            this.lendButton.TabIndex = 0;
            this.lendButton.Text = "Wypożyczenia";
            this.lendButton.UseVisualStyleBackColor = true;
            this.lendButton.Click += new System.EventHandler(this.rentButton_Click);
            // 
            // messagesButton
            // 
            this.messagesButton.Location = new System.Drawing.Point(528, 136);
            this.messagesButton.Name = "messagesButton";
            this.messagesButton.Size = new System.Drawing.Size(91, 34);
            this.messagesButton.TabIndex = 4;
            this.messagesButton.Text = "Wiadomości";
            this.messagesButton.UseVisualStyleBackColor = true;
            this.messagesButton.Click += new System.EventHandler(this.messagesButton_Click);
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 304);
            this.Controls.Add(this.panelLibrarian);
            this.Controls.Add(this.messagesButton);
            this.Controls.Add(this.panelReader);
            this.Controls.Add(this.signButton);
            this.Controls.Add(this.booksButton);
            this.Controls.Add(this.exhibitionButton);
            this.Name = "MainDashboard";
            this.Text = "Biblioteka publiczna";
            this.panelLibrarian.ResumeLayout(false);
            this.panelLibrarian.PerformLayout();
            this.panelReader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLibrarian;
        private System.Windows.Forms.Button booksButton;
        private System.Windows.Forms.Button exhibitionButton;
        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.Panel panelReader;
        private System.Windows.Forms.Button messagesButton;
        private System.Windows.Forms.Button bookingButton;
        private System.Windows.Forms.Button lendButton;
        private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.Button booksManagementButton;
        private System.Windows.Forms.Button librariansManagementButton;
        private System.Windows.Forms.Button readersManagementButton;
        private System.Windows.Forms.Button exhibitionManagementButton;
        private System.Windows.Forms.Button prolognationButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button reportButton;
    }
}

