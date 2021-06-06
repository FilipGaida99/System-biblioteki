namespace Biblioteka
{
    partial class LibrarianCreateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.boxName = new System.Windows.Forms.TextBox();
            this.boxSurnname = new System.Windows.Forms.TextBox();
            this.boxPhone = new System.Windows.Forms.TextBox();
            this.boxMail = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.boxID = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.checkSuper = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imię:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nazwisko:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telefon:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "E-mail:";
            // 
            // boxName
            // 
            this.boxName.Location = new System.Drawing.Point(76, 9);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(175, 20);
            this.boxName.TabIndex = 4;
            // 
            // boxSurnname
            // 
            this.boxSurnname.Location = new System.Drawing.Point(76, 39);
            this.boxSurnname.Name = "boxSurnname";
            this.boxSurnname.Size = new System.Drawing.Size(175, 20);
            this.boxSurnname.TabIndex = 5;
            // 
            // boxPhone
            // 
            this.boxPhone.Location = new System.Drawing.Point(76, 70);
            this.boxPhone.Name = "boxPhone";
            this.boxPhone.Size = new System.Drawing.Size(175, 20);
            this.boxPhone.TabIndex = 6;
            // 
            // boxMail
            // 
            this.boxMail.Location = new System.Drawing.Point(76, 99);
            this.boxMail.Name = "boxMail";
            this.boxMail.Size = new System.Drawing.Size(175, 20);
            this.boxMail.TabIndex = 7;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(56, 158);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(151, 35);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "Utwórz Bibliotekarza";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Wygenerowane ID:";
            // 
            // boxID
            // 
            this.boxID.Location = new System.Drawing.Point(119, 210);
            this.boxID.Name = "boxID";
            this.boxID.ReadOnly = true;
            this.boxID.Size = new System.Drawing.Size(117, 20);
            this.boxID.TabIndex = 10;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(56, 246);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(151, 23);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "Zakończ";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // checkSuper
            // 
            this.checkSuper.AutoSize = true;
            this.checkSuper.Location = new System.Drawing.Point(76, 126);
            this.checkSuper.Name = "checkSuper";
            this.checkSuper.Size = new System.Drawing.Size(108, 17);
            this.checkSuper.TabIndex = 12;
            this.checkSuper.Text = "SuperBibliotekarz";
            this.checkSuper.UseVisualStyleBackColor = true;
            // 
            // LibrarianCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 281);
            this.Controls.Add(this.checkSuper);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.boxID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.boxMail);
            this.Controls.Add(this.boxPhone);
            this.Controls.Add(this.boxSurnname);
            this.Controls.Add(this.boxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(280, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(280, 320);
            this.Name = "LibrarianCreateForm";
            this.Text = "Dodawanie Bibliotekarza";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox boxName;
        private System.Windows.Forms.TextBox boxSurnname;
        private System.Windows.Forms.TextBox boxPhone;
        private System.Windows.Forms.TextBox boxMail;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox boxID;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.CheckBox checkSuper;
    }
}