
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
            System.Windows.Forms.Label label1;
            this.filterButton = new System.Windows.Forms.Button();
            this.chooseButton = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.publisherNameText = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(61, 20);
            label1.TabIndex = 10;
            label1.Text = "Nazwa:";
            // 
            // filterButton
            // 
            this.filterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filterButton.Location = new System.Drawing.Point(193, 47);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(79, 29);
            this.filterButton.TabIndex = 9;
            this.filterButton.Text = "Filtruj";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // chooseButton
            // 
            this.chooseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chooseButton.Location = new System.Drawing.Point(193, 82);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(79, 29);
            this.chooseButton.TabIndex = 8;
            this.chooseButton.Text = "Wybierz";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // comboBox
            // 
            this.comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(11, 82);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(162, 28);
            this.comboBox.TabIndex = 7;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addButton.Location = new System.Drawing.Point(193, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(79, 29);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // publisherNameText
            // 
            this.publisherNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.publisherNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.publisherNameText.Location = new System.Drawing.Point(11, 41);
            this.publisherNameText.MaxLength = 50;
            this.publisherNameText.Name = "publisherNameText";
            this.publisherNameText.Size = new System.Drawing.Size(162, 26);
            this.publisherNameText.TabIndex = 5;
            // 
            // PublisherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 117);
            this.Controls.Add(label1);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.publisherNameText);
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
        private System.Windows.Forms.TextBox publisherNameText;
    }
}