﻿
namespace Biblioteka
{
    partial class AuthorForm
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
            System.Windows.Forms.Label label2;
            this.firstNameText = new System.Windows.Forms.TextBox();
            this.surnameText = new System.Windows.Forms.TextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.chooseButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(18, 22);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(29, 13);
            label1.TabIndex = 3;
            label1.Text = "Imię:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(127, 22);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 13);
            label2.TabIndex = 4;
            label2.Text = "Nazwisko:";
            // 
            // firstNameText
            // 
            this.firstNameText.Location = new System.Drawing.Point(21, 41);
            this.firstNameText.Name = "firstNameText";
            this.firstNameText.Size = new System.Drawing.Size(100, 20);
            this.firstNameText.TabIndex = 0;
            // 
            // surnameText
            // 
            this.surnameText.Location = new System.Drawing.Point(127, 41);
            this.surnameText.Name = "surnameText";
            this.surnameText.Size = new System.Drawing.Size(100, 20);
            this.surnameText.TabIndex = 1;
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(21, 88);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(206, 21);
            this.comboBox.TabIndex = 2;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(234, 37);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 5;
            this.filterButton.Text = "Filtruj";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(234, 8);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(234, 86);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(75, 23);
            this.chooseButton.TabIndex = 7;
            this.chooseButton.Text = "Wybierz";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // AuthorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 124);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.surnameText);
            this.Controls.Add(this.firstNameText);
            this.Name = "AuthorForm";
            this.Text = "Wybieranie autora";
            this.Load += new System.EventHandler(this.AutorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNameText;
        private System.Windows.Forms.TextBox surnameText;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button chooseButton;
    }
}