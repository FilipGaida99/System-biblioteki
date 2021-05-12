
namespace Biblioteka
{
    partial class PublisherPicker
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
            this.choosePublisherButton = new System.Windows.Forms.Button();
            this.publisherText = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // choosePublisherButton
            // 
            this.choosePublisherButton.Location = new System.Drawing.Point(192, 4);
            this.choosePublisherButton.Name = "choosePublisherButton";
            this.choosePublisherButton.Size = new System.Drawing.Size(75, 23);
            this.choosePublisherButton.TabIndex = 13;
            this.choosePublisherButton.Text = "Wybierz";
            this.choosePublisherButton.UseVisualStyleBackColor = true;
            this.choosePublisherButton.Click += new System.EventHandler(this.choosePublisherButton_Click);
            // 
            // publisherText
            // 
            this.publisherText.Location = new System.Drawing.Point(86, 6);
            this.publisherText.Name = "publisherText";
            this.publisherText.Size = new System.Drawing.Size(100, 20);
            this.publisherText.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 9);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(77, 13);
            label5.TabIndex = 11;
            label5.Text = "Wydawnictwo:";
            // 
            // PublisherPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.choosePublisherButton);
            this.Controls.Add(this.publisherText);
            this.Controls.Add(label5);
            this.Name = "PublisherPicker";
            this.Size = new System.Drawing.Size(271, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button choosePublisherButton;
        private System.Windows.Forms.TextBox publisherText;
    }
}
