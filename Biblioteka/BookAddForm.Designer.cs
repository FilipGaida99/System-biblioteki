
namespace Biblioteka
{
    partial class BookAddForm
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
            this.firstCopyInventoryNumber = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.firstCopyInventoryNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label1.Location = new System.Drawing.Point(308, 241);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(110, 20);
            label1.TabIndex = 17;
            label1.Text = "Nr inwentarza:";
            // 
            // firstCopyInventoryNumber
            // 
            this.firstCopyInventoryNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.firstCopyInventoryNumber.Location = new System.Drawing.Point(418, 239);
            this.firstCopyInventoryNumber.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.firstCopyInventoryNumber.Name = "firstCopyInventoryNumber";
            this.firstCopyInventoryNumber.Size = new System.Drawing.Size(255, 26);
            this.firstCopyInventoryNumber.TabIndex = 14;
            // 
            // BookAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(693, 334);
            this.Controls.Add(this.firstCopyInventoryNumber);
            this.Controls.Add(label1);
            this.Name = "BookAddForm";
            this.Text = "Dodawanie książki";
            this.Controls.SetChildIndex(label1, 0);
            this.Controls.SetChildIndex(this.firstCopyInventoryNumber, 0);
            ((System.ComponentModel.ISupportInitialize)(this.firstCopyInventoryNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown firstCopyInventoryNumber;
    }
}
