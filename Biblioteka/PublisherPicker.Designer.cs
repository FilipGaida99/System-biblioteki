﻿
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label5.Location = new System.Drawing.Point(3, 9);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(109, 20);
            label5.TabIndex = 11;
            label5.Text = "Wydawnictwo:";
            // 
            // choosePublisherButton
            // 
            this.choosePublisherButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.choosePublisherButton.Location = new System.Drawing.Point(258, 6);
            this.choosePublisherButton.Name = "choosePublisherButton";
            this.choosePublisherButton.Size = new System.Drawing.Size(75, 26);
            this.choosePublisherButton.TabIndex = 2;
            this.choosePublisherButton.Text = "Wybierz";
            this.choosePublisherButton.UseVisualStyleBackColor = true;
            this.choosePublisherButton.Click += new System.EventHandler(this.choosePublisherButton_Click);
            // 
            // publisherText
            // 
            this.publisherText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.publisherText.Location = new System.Drawing.Point(109, 7);
            this.publisherText.MaxLength = 200;
            this.publisherText.Name = "publisherText";
            this.publisherText.Size = new System.Drawing.Size(143, 26);
            this.publisherText.TabIndex = 1;
            // 
            // PublisherPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.choosePublisherButton);
            this.Controls.Add(this.publisherText);
            this.Controls.Add(label5);
            this.Name = "PublisherPicker";
            this.Size = new System.Drawing.Size(336, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button choosePublisherButton;
        private System.Windows.Forms.TextBox publisherText;
    }
}
