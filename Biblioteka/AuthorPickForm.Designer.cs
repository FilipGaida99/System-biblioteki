
namespace Biblioteka
{
    partial class AuthorPickForm
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
            this.pickButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pickButton
            // 
            this.pickButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pickButton.Location = new System.Drawing.Point(584, 359);
            this.pickButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pickButton.Name = "pickButton";
            this.pickButton.Size = new System.Drawing.Size(129, 68);
            this.pickButton.TabIndex = 16;
            this.pickButton.Text = "Wybierz";
            this.pickButton.UseVisualStyleBackColor = true;
            this.pickButton.Click += new System.EventHandler(this.pickButton_Click);
            // 
            // AuthorPickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(725, 529);
            this.Controls.Add(this.pickButton);
            this.Name = "AuthorPickForm";
            this.Controls.SetChildIndex(this.authorsListBox, 0);
            this.Controls.SetChildIndex(this.pickButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pickButton;
    }
}
