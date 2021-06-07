namespace Biblioteka
{
    partial class ReadersManagmentForm
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
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.boxName = new System.Windows.Forms.TextBox();
            this.boxSurname = new System.Windows.Forms.TextBox();
            this.boxPhone = new System.Windows.Forms.TextBox();
            this.boxMail = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonPenalty = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonAddUser.Location = new System.Drawing.Point(530, 49);
            this.buttonAddUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(163, 90);
            this.buttonAddUser.TabIndex = 0;
            this.buttonAddUser.Text = "Dodaj Czytelnika";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(550, 181);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(577, 181);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(56, 15);
            this.labelID.TabIndex = 2;
            this.labelID.Text = "0000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(538, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Imię:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nazwisko:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(498, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nr Telefonu:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(527, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "e-mail:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 157);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(473, 349);
            this.listBox1.TabIndex = 7;
            // 
            // boxName
            // 
            this.boxName.Location = new System.Drawing.Point(578, 210);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(134, 21);
            this.boxName.TabIndex = 8;
            // 
            // boxSurname
            // 
            this.boxSurname.Location = new System.Drawing.Point(578, 237);
            this.boxSurname.Name = "boxSurname";
            this.boxSurname.Size = new System.Drawing.Size(134, 21);
            this.boxSurname.TabIndex = 9;
            // 
            // boxPhone
            // 
            this.boxPhone.Location = new System.Drawing.Point(578, 264);
            this.boxPhone.Name = "boxPhone";
            this.boxPhone.Size = new System.Drawing.Size(135, 21);
            this.boxPhone.TabIndex = 10;
            // 
            // boxMail
            // 
            this.boxMail.Location = new System.Drawing.Point(578, 291);
            this.boxMail.Name = "boxMail";
            this.boxMail.Size = new System.Drawing.Size(134, 21);
            this.boxMail.TabIndex = 11;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(501, 318);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(137, 49);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Zapisz zmiany";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(100, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(257, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "miejsce na panel wyszukiwania uzytkownikow";
            // 
            // buttonPenalty
            // 
            this.buttonPenalty.Location = new System.Drawing.Point(541, 399);
            this.buttonPenalty.Name = "buttonPenalty";
            this.buttonPenalty.Size = new System.Drawing.Size(132, 75);
            this.buttonPenalty.TabIndex = 14;
            this.buttonPenalty.Text = "Aktualne Kary Czytelnika";
            this.buttonPenalty.UseVisualStyleBackColor = true;
            this.buttonPenalty.Click += new System.EventHandler(this.penaltyButton_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonDelete.Location = new System.Drawing.Point(640, 318);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(73, 49);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "Usuń czytelnika";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // ReadersManagmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(725, 524);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonPenalty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.boxMail);
            this.Controls.Add(this.boxPhone);
            this.Controls.Add(this.boxSurname);
            this.Controls.Add(this.boxName);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddUser);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadersManagmentForm";
            this.ShowInTaskbar = false;
            this.Text = "Zarządzanie Czytelnikami";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox boxName;
        private System.Windows.Forms.TextBox boxSurname;
        private System.Windows.Forms.TextBox boxPhone;
        private System.Windows.Forms.TextBox boxMail;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonPenalty;
        private System.Windows.Forms.Button buttonDelete;
    }
}