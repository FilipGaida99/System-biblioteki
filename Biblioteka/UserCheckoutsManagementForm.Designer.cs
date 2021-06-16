
namespace Biblioteka
{
    partial class UserCheckoutsManagementForm
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
            this.returnButton = new System.Windows.Forms.Button();
            this.extensionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(163, 9);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(75, 23);
            this.returnButton.TabIndex = 5;
            this.returnButton.Text = "Zwróć";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // extensionButton
            // 
            this.extensionButton.Location = new System.Drawing.Point(244, 9);
            this.extensionButton.Name = "extensionButton";
            this.extensionButton.Size = new System.Drawing.Size(75, 23);
            this.extensionButton.TabIndex = 6;
            this.extensionButton.Text = "Prolonguj";
            this.extensionButton.UseVisualStyleBackColor = true;
            this.extensionButton.Click += new System.EventHandler(this.extensionButton_Click);
            // 
            // UserCheckoutsManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(664, 297);
            this.Controls.Add(this.extensionButton);
            this.Controls.Add(this.returnButton);
            this.Name = "UserCheckoutsManagementForm";
            this.Controls.SetChildIndex(this.checkoutsList, 0);
            this.Controls.SetChildIndex(this.returnedCheckBox, 0);
            this.Controls.SetChildIndex(this.returnButton, 0);
            this.Controls.SetChildIndex(this.extensionButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button extensionButton;
    }
}
