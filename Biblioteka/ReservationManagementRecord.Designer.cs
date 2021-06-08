
namespace Biblioteka
{
    partial class ReservationManagementRecord
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
            this.checkoutFromReservation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkoutFromReservation
            // 
            this.checkoutFromReservation.Location = new System.Drawing.Point(365, 58);
            this.checkoutFromReservation.Name = "checkoutFromReservation";
            this.checkoutFromReservation.Size = new System.Drawing.Size(75, 34);
            this.checkoutFromReservation.TabIndex = 14;
            this.checkoutFromReservation.Text = "Wypożycz";
            this.checkoutFromReservation.UseVisualStyleBackColor = true;
            this.checkoutFromReservation.Click += new System.EventHandler(this.checkoutFromReservation_Click);
            // 
            // ReservationManagementRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.checkoutFromReservation);
            this.Name = "ReservationManagementRecord";
            this.Controls.SetChildIndex(this.checkoutFromReservation, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkoutFromReservation;
    }
}
