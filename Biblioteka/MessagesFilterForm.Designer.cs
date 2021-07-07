
namespace Biblioteka
{
    partial class MessagesFilterForm
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
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromUserTextBox = new System.Windows.Forms.TextBox();
            this.toUserTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.conentTextBox = new System.Windows.Forms.TextBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.cleanButton = new System.Windows.Forms.Button();
            this.fromCheckBox = new System.Windows.Forms.CheckBox();
            this.toCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Enabled = false;
            this.fromDateTimePicker.Location = new System.Drawing.Point(104, 113);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromDateTimePicker.TabIndex = 0;
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Enabled = false;
            this.toDateTimePicker.Location = new System.Drawing.Point(104, 139);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.toDateTimePicker.TabIndex = 1;
            // 
            // fromUserTextBox
            // 
            this.fromUserTextBox.Location = new System.Drawing.Point(104, 9);
            this.fromUserTextBox.Name = "fromUserTextBox";
            this.fromUserTextBox.Size = new System.Drawing.Size(200, 20);
            this.fromUserTextBox.TabIndex = 2;
            // 
            // toUserTextBox
            // 
            this.toUserTextBox.Location = new System.Drawing.Point(104, 35);
            this.toUserTextBox.Name = "toUserTextBox";
            this.toUserTextBox.Size = new System.Drawing.Size(200, 20);
            this.toUserTextBox.TabIndex = 3;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(104, 61);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(200, 20);
            this.titleTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Od";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Do";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Temat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Słowa kluczowe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Data od";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Data do";
            // 
            // conentTextBox
            // 
            this.conentTextBox.Location = new System.Drawing.Point(104, 87);
            this.conentTextBox.Name = "conentTextBox";
            this.conentTextBox.Size = new System.Drawing.Size(200, 20);
            this.conentTextBox.TabIndex = 11;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(79, 175);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 12;
            this.filterButton.Text = "Wyszukaj";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // cleanButton
            // 
            this.cleanButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cleanButton.Location = new System.Drawing.Point(160, 175);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(75, 23);
            this.cleanButton.TabIndex = 13;
            this.cleanButton.Text = "Wyczyść";
            this.cleanButton.UseVisualStyleBackColor = false;
            this.cleanButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // fromCheckBox
            // 
            this.fromCheckBox.AutoSize = true;
            this.fromCheckBox.Location = new System.Drawing.Point(83, 113);
            this.fromCheckBox.Name = "fromCheckBox";
            this.fromCheckBox.Size = new System.Drawing.Size(15, 14);
            this.fromCheckBox.TabIndex = 14;
            this.fromCheckBox.UseVisualStyleBackColor = true;
            this.fromCheckBox.CheckedChanged += new System.EventHandler(this.fromCheckBox_CheckedChanged);
            // 
            // toCheckBox
            // 
            this.toCheckBox.AutoSize = true;
            this.toCheckBox.Location = new System.Drawing.Point(83, 138);
            this.toCheckBox.Name = "toCheckBox";
            this.toCheckBox.Size = new System.Drawing.Size(15, 14);
            this.toCheckBox.TabIndex = 15;
            this.toCheckBox.UseVisualStyleBackColor = true;
            this.toCheckBox.CheckedChanged += new System.EventHandler(this.toCheckBox_CheckedChanged);
            // 
            // MessagesFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 209);
            this.Controls.Add(this.toCheckBox);
            this.Controls.Add(this.fromCheckBox);
            this.Controls.Add(this.cleanButton);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.conentTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.toUserTextBox);
            this.Controls.Add(this.fromUserTextBox);
            this.Controls.Add(this.toDateTimePicker);
            this.Controls.Add(this.fromDateTimePicker);
            this.Name = "MessagesFilterForm";
            this.Text = "MessagesFilterForm";
            this.Load += new System.EventHandler(this.MessagesFilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DateTimePicker fromDateTimePicker;
        public System.Windows.Forms.DateTimePicker toDateTimePicker;
        public System.Windows.Forms.TextBox fromUserTextBox;
        public System.Windows.Forms.TextBox toUserTextBox;
        public System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox conentTextBox;
        public System.Windows.Forms.Button filterButton;
        public System.Windows.Forms.Button cleanButton;
        public System.Windows.Forms.CheckBox fromCheckBox;
        public System.Windows.Forms.CheckBox toCheckBox;
    }
}