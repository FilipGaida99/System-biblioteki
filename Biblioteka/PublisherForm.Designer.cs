
namespace Biblioteka
{
    partial class PublisherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filterButton = new System.Windows.Forms.Button();
            this.chooseButton = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.nazwa = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(193, 41);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 9;
            this.filterButton.Text = "Filtruj";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(193, 79);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(75, 23);
            this.chooseButton.TabIndex = 8;
            this.chooseButton.Text = "Wybierz";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(11, 82);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(162, 21);
            this.comboBox.TabIndex = 7;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(193, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // nazwa
            // 
            this.nazwa.Location = new System.Drawing.Point(11, 41);
            this.nazwa.Name = "nazwa";
            this.nazwa.Size = new System.Drawing.Size(162, 20);
            this.nazwa.TabIndex = 5;
            // 
            // PublisherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 116);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.nazwa);
            this.Name = "PublisherForm";
            this.Text = "Wybór wydawnictwa";
            this.Load += new System.EventHandler(this.WydawnictwoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox nazwa;
    }
}