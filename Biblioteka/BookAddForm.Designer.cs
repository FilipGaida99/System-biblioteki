
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
            this.firstCopyInventoryText = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(321, 200);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(75, 13);
            label1.TabIndex = 17;
            label1.Text = "Nr inwentarza:";
            // 
            // firstCopyInventoryText
            // 
            this.firstCopyInventoryText.Location = new System.Drawing.Point(404, 197);
            this.firstCopyInventoryText.Name = "firstCopyInventoryText";
            this.firstCopyInventoryText.Size = new System.Drawing.Size(100, 20);
            this.firstCopyInventoryText.TabIndex = 18;
            // 
            // BookAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(621, 264);
            this.Controls.Add(this.firstCopyInventoryText);
            this.Controls.Add(label1);
            this.Name = "BookAddForm";
            this.Text = "Dodawanie książki";
            this.Controls.SetChildIndex(label1, 0);
            this.Controls.SetChildIndex(this.firstCopyInventoryText, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstCopyInventoryText;
    }
}
