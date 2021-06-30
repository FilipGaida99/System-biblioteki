
namespace Biblioteka
{
    partial class PublisherManagementForm
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
            this.publishersListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.modButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.unusedCheckBox = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label1.Location = new System.Drawing.Point(13, 15);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(112, 20);
            label1.TabIndex = 5;
            label1.Text = "Wyszukiwanie:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label2.Location = new System.Drawing.Point(13, 95);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(187, 20);
            label2.TabIndex = 6;
            label2.Text = "Znalezione wydawnictwa:";
            // 
            // publishersListBox
            // 
            this.publishersListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.publishersListBox.FormattingEnabled = true;
            this.publishersListBox.ItemHeight = 20;
            this.publishersListBox.Location = new System.Drawing.Point(13, 125);
            this.publishersListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.publishersListBox.Name = "publishersListBox";
            this.publishersListBox.Size = new System.Drawing.Size(560, 384);
            this.publishersListBox.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addButton.Location = new System.Drawing.Point(585, 125);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(129, 68);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // modButton
            // 
            this.modButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.modButton.Location = new System.Drawing.Point(585, 202);
            this.modButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.modButton.Name = "modButton";
            this.modButton.Size = new System.Drawing.Size(129, 68);
            this.modButton.TabIndex = 2;
            this.modButton.Text = "Modyfikuj";
            this.modButton.UseVisualStyleBackColor = true;
            this.modButton.Click += new System.EventHandler(this.modButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteButton.Location = new System.Drawing.Point(585, 278);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(129, 68);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.search.Location = new System.Drawing.Point(13, 45);
            this.search.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(698, 26);
            this.search.TabIndex = 4;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // unusedCheckBox
            // 
            this.unusedCheckBox.AutoSize = true;
            this.unusedCheckBox.Location = new System.Drawing.Point(128, 14);
            this.unusedCheckBox.Name = "unusedCheckBox";
            this.unusedCheckBox.Size = new System.Drawing.Size(151, 24);
            this.unusedCheckBox.TabIndex = 7;
            this.unusedCheckBox.Text = "Tylko nieużywane";
            this.unusedCheckBox.UseVisualStyleBackColor = true;
            this.unusedCheckBox.CheckedChanged += new System.EventHandler(this.unusedCheckBox_CheckedChanged);
            // 
            // PublisherManagementForm
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
            this.Controls.Add(this.publishersListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PublisherManagementForm";
            this.Text = "Zarządzanie wydawnictwami";
            this.Load += new System.EventHandler(this.PublisherManagementForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button modButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox search;
        protected System.Windows.Forms.ListBox publishersListBox;
        private System.Windows.Forms.CheckBox unusedCheckBox;
    }
}