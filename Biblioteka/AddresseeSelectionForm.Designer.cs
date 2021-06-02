
namespace Biblioteka
{
    partial class AddresseeSelectionForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chosenConstLabel = new System.Windows.Forms.Label();
            this.availableConstLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.removeAddresseeButton = new System.Windows.Forms.Button();
            this.addAddresseeButton = new System.Windows.Forms.Button();
            this.chosenListBox = new System.Windows.Forms.ListBox();
            this.availableListBox = new System.Windows.Forms.ListBox();
            this.availableFilterTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chosenFilterTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chosenFilterTextBox);
            this.panel1.Controls.Add(this.availableFilterTextBox);
            this.panel1.Controls.Add(this.chosenConstLabel);
            this.panel1.Controls.Add(this.availableConstLabel);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.selectButton);
            this.panel1.Controls.Add(this.removeAddresseeButton);
            this.panel1.Controls.Add(this.addAddresseeButton);
            this.panel1.Controls.Add(this.chosenListBox);
            this.panel1.Controls.Add(this.availableListBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 339);
            this.panel1.TabIndex = 0;
            // 
            // chosenConstLabel
            // 
            this.chosenConstLabel.AutoSize = true;
            this.chosenConstLabel.Location = new System.Drawing.Point(299, 9);
            this.chosenConstLabel.Name = "chosenConstLabel";
            this.chosenConstLabel.Size = new System.Drawing.Size(46, 13);
            this.chosenConstLabel.TabIndex = 15;
            this.chosenConstLabel.Text = "Wybrani";
            // 
            // availableConstLabel
            // 
            this.availableConstLabel.AutoSize = true;
            this.availableConstLabel.Location = new System.Drawing.Point(12, 9);
            this.availableConstLabel.Name = "availableConstLabel";
            this.availableConstLabel.Size = new System.Drawing.Size(49, 13);
            this.availableConstLabel.TabIndex = 14;
            this.availableConstLabel.Text = "Dostępni";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(265, 305);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(184, 305);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 23);
            this.selectButton.TabIndex = 12;
            this.selectButton.Text = "Wybierz";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // removeAddresseeButton
            // 
            this.removeAddresseeButton.Location = new System.Drawing.Point(237, 136);
            this.removeAddresseeButton.Name = "removeAddresseeButton";
            this.removeAddresseeButton.Size = new System.Drawing.Size(50, 49);
            this.removeAddresseeButton.TabIndex = 11;
            this.removeAddresseeButton.Text = "<";
            this.removeAddresseeButton.UseVisualStyleBackColor = true;
            this.removeAddresseeButton.Click += new System.EventHandler(this.removeAddresseeButton_Click);
            // 
            // addAddresseeButton
            // 
            this.addAddresseeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addAddresseeButton.Location = new System.Drawing.Point(237, 67);
            this.addAddresseeButton.Name = "addAddresseeButton";
            this.addAddresseeButton.Size = new System.Drawing.Size(50, 49);
            this.addAddresseeButton.TabIndex = 10;
            this.addAddresseeButton.Text = ">";
            this.addAddresseeButton.UseVisualStyleBackColor = true;
            this.addAddresseeButton.Click += new System.EventHandler(this.addAddresseeButton_Click);
            // 
            // chosenListBox
            // 
            this.chosenListBox.FormattingEnabled = true;
            this.chosenListBox.Location = new System.Drawing.Point(302, 34);
            this.chosenListBox.Name = "chosenListBox";
            this.chosenListBox.Size = new System.Drawing.Size(210, 238);
            this.chosenListBox.TabIndex = 9;
            // 
            // availableListBox
            // 
            this.availableListBox.FormattingEnabled = true;
            this.availableListBox.Location = new System.Drawing.Point(15, 34);
            this.availableListBox.Name = "availableListBox";
            this.availableListBox.Size = new System.Drawing.Size(210, 238);
            this.availableListBox.TabIndex = 8;
            // 
            // availableFilterTextBox
            // 
            this.availableFilterTextBox.Location = new System.Drawing.Point(15, 279);
            this.availableFilterTextBox.Name = "availableFilterTextBox";
            this.availableFilterTextBox.Size = new System.Drawing.Size(210, 20);
            this.availableFilterTextBox.TabIndex = 16;
            this.availableFilterTextBox.TextChanged += new System.EventHandler(this.availableFilterTextBox_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // chosenFilterTextBox
            // 
            this.chosenFilterTextBox.Location = new System.Drawing.Point(302, 279);
            this.chosenFilterTextBox.Name = "chosenFilterTextBox";
            this.chosenFilterTextBox.Size = new System.Drawing.Size(210, 20);
            this.chosenFilterTextBox.TabIndex = 17;
            this.chosenFilterTextBox.TextChanged += new System.EventHandler(this.chosenFilterTextBox_TextChanged);
            // 
            // AddresseeSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 363);
            this.Controls.Add(this.panel1);
            this.Name = "AddresseeSelectionForm";
            this.Text = "addresseeSelectionForm";
            this.Load += new System.EventHandler(this.AddresseeSelectionForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label chosenConstLabel;
        private System.Windows.Forms.Label availableConstLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button removeAddresseeButton;
        private System.Windows.Forms.Button addAddresseeButton;
        private System.Windows.Forms.ListBox chosenListBox;
        private System.Windows.Forms.ListBox availableListBox;
        private System.Windows.Forms.TextBox chosenFilterTextBox;
        private System.Windows.Forms.TextBox availableFilterTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}