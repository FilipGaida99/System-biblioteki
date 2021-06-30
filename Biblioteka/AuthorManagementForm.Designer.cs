
namespace Biblioteka
{
    partial class AuthorManagementForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.unusedCheckBox = new System.Windows.Forms.CheckBox();
            this.search = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.modButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.authorsListBox = new System.Windows.Forms.ListBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label2.Location = new System.Drawing.Point(12, 98);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(187, 20);
            label2.TabIndex = 14;
            label2.Text = "Znalezione wydawnictwa:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label1.Location = new System.Drawing.Point(12, 18);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(112, 20);
            label1.TabIndex = 13;
            label1.Text = "Wyszukiwanie:";
            // 
            // unusedCheckBox
            // 
            this.unusedCheckBox.AutoSize = true;
            this.unusedCheckBox.Location = new System.Drawing.Point(127, 17);
            this.unusedCheckBox.Name = "unusedCheckBox";
            this.unusedCheckBox.Size = new System.Drawing.Size(151, 24);
            this.unusedCheckBox.TabIndex = 15;
            this.unusedCheckBox.Text = "Tylko nieużywane";
            this.unusedCheckBox.UseVisualStyleBackColor = true;
            this.unusedCheckBox.CheckedChanged += new System.EventHandler(this.unusedCheckBox_CheckedChanged);
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.search.Location = new System.Drawing.Point(12, 48);
            this.search.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(698, 26);
            this.search.TabIndex = 12;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteButton.Location = new System.Drawing.Point(584, 281);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(129, 68);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // modButton
            // 
            this.modButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.modButton.Location = new System.Drawing.Point(584, 205);
            this.modButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.modButton.Name = "modButton";
            this.modButton.Size = new System.Drawing.Size(129, 68);
            this.modButton.TabIndex = 10;
            this.modButton.Text = "Modyfikuj";
            this.modButton.UseVisualStyleBackColor = true;
            this.modButton.Click += new System.EventHandler(this.modButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addButton.Location = new System.Drawing.Point(584, 128);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(129, 68);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // authorsListBox
            // 
            this.authorsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.authorsListBox.FormattingEnabled = true;
            this.authorsListBox.ItemHeight = 20;
            this.authorsListBox.Location = new System.Drawing.Point(12, 128);
            this.authorsListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.authorsListBox.Name = "authorsListBox";
            this.authorsListBox.Size = new System.Drawing.Size(560, 384);
            this.authorsListBox.TabIndex = 8;
            // 
            // AuthorManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 529);
            this.Controls.Add(this.unusedCheckBox);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.modButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.authorsListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AuthorManagementForm";
            this.Text = "Zarządzanie autorami";
            this.Load += new System.EventHandler(this.AuthorManagementForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox unusedCheckBox;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button modButton;
        private System.Windows.Forms.Button addButton;
        protected System.Windows.Forms.ListBox authorsListBox;
    }
}