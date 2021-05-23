
namespace Biblioteka
{
    partial class ReaderSearch
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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.label4 = new System.Windows.Forms.Label();
            this.searchMail = new System.Windows.Forms.TextBox();
            this.searchPhone = new System.Windows.Forms.TextBox();
            this.searchSurname = new System.Windows.Forms.TextBox();
            this.searchName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(38, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Szukaj Czytelników";
            // 
            // searchMail
            // 
            this.searchMail.Location = new System.Drawing.Point(91, 155);
            this.searchMail.Name = "searchMail";
            this.searchMail.Size = new System.Drawing.Size(100, 20);
            this.searchMail.TabIndex = 42;
            // 
            // searchPhone
            // 
            this.searchPhone.Location = new System.Drawing.Point(91, 127);
            this.searchPhone.Name = "searchPhone";
            this.searchPhone.Size = new System.Drawing.Size(100, 20);
            this.searchPhone.TabIndex = 41;
            // 
            // searchSurname
            // 
            this.searchSurname.Location = new System.Drawing.Point(91, 97);
            this.searchSurname.Name = "searchSurname";
            this.searchSurname.Size = new System.Drawing.Size(100, 20);
            this.searchSurname.TabIndex = 40;
            // 
            // searchName
            // 
            this.searchName.Location = new System.Drawing.Point(91, 68);
            this.searchName.Name = "searchName";
            this.searchName.Size = new System.Drawing.Size(100, 20);
            this.searchName.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "E-mail:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(39, 130);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(46, 13);
            label5.TabIndex = 37;
            label5.Text = "Telefon:";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(236, 55);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 136);
            this.searchButton.TabIndex = 36;
            this.searchButton.Text = "Szukaj";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(29, 100);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 13);
            label2.TabIndex = 35;
            label2.Text = "Nazwisko:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(56, 71);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(29, 13);
            label1.TabIndex = 34;
            label1.Text = "Imię:";
            // 
            // ReaderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.searchMail);
            this.Controls.Add(this.searchPhone);
            this.Controls.Add(this.searchSurname);
            this.Controls.Add(this.searchName);
            this.Controls.Add(this.label3);
            this.Controls.Add(label5);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Name = "ReaderSearch";
            this.Size = new System.Drawing.Size(365, 205);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox searchMail;
        private System.Windows.Forms.TextBox searchPhone;
        private System.Windows.Forms.TextBox searchSurname;
        private System.Windows.Forms.TextBox searchName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button searchButton;
    }
}
