
namespace Biblioteka
{
    partial class BookDetails
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            this.tabControl = new System.Windows.Forms.TabControl();
            this.informationPage = new System.Windows.Forms.TabPage();
            this.availabilityPage = new System.Windows.Forms.TabPage();
            this.isbnLabel = new System.Windows.Forms.Label();
            this.authorsLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.publisherLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.maxDaysLabel = new System.Windows.Forms.Label();
            this.descriptionText = new System.Windows.Forms.TextBox();
            this.copyPage = new System.Windows.Forms.TabPage();
            this.refreshAvailabilityButton = new System.Windows.Forms.Button();
            this.bookingButton = new System.Windows.Forms.Button();
            this.availabilityLabel = new System.Windows.Forms.Label();
            this.copyList = new System.Windows.Forms.ListView();
            this.availability = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inventory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.refreshCopyButton = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.informationPage.SuspendLayout();
            this.availabilityPage.SuspendLayout();
            this.copyPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.informationPage);
            this.tabControl.Controls.Add(this.availabilityPage);
            this.tabControl.Controls.Add(this.copyPage);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(511, 426);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // informationPage
            // 
            this.informationPage.Controls.Add(this.descriptionText);
            this.informationPage.Controls.Add(label7);
            this.informationPage.Controls.Add(this.maxDaysLabel);
            this.informationPage.Controls.Add(label6);
            this.informationPage.Controls.Add(label5);
            this.informationPage.Controls.Add(this.isbnLabel);
            this.informationPage.Controls.Add(label4);
            this.informationPage.Controls.Add(this.authorsLabel);
            this.informationPage.Controls.Add(label3);
            this.informationPage.Controls.Add(this.dateLabel);
            this.informationPage.Controls.Add(label2);
            this.informationPage.Controls.Add(this.publisherLabel);
            this.informationPage.Controls.Add(label1);
            this.informationPage.Controls.Add(this.titleLabel);
            this.informationPage.Location = new System.Drawing.Point(4, 22);
            this.informationPage.Name = "informationPage";
            this.informationPage.Padding = new System.Windows.Forms.Padding(3);
            this.informationPage.Size = new System.Drawing.Size(503, 400);
            this.informationPage.TabIndex = 0;
            this.informationPage.Text = "Informacje";
            this.informationPage.UseVisualStyleBackColor = true;
            // 
            // availabilityPage
            // 
            this.availabilityPage.Controls.Add(this.availabilityLabel);
            this.availabilityPage.Controls.Add(this.bookingButton);
            this.availabilityPage.Controls.Add(this.refreshAvailabilityButton);
            this.availabilityPage.Location = new System.Drawing.Point(4, 22);
            this.availabilityPage.Name = "availabilityPage";
            this.availabilityPage.Padding = new System.Windows.Forms.Padding(3);
            this.availabilityPage.Size = new System.Drawing.Size(503, 400);
            this.availabilityPage.TabIndex = 1;
            this.availabilityPage.Text = "Dostępność";
            this.availabilityPage.UseVisualStyleBackColor = true;
            // 
            // isbnLabel
            // 
            this.isbnLabel.AutoSize = true;
            this.isbnLabel.Location = new System.Drawing.Point(96, 40);
            this.isbnLabel.Name = "isbnLabel";
            this.isbnLabel.Size = new System.Drawing.Size(32, 13);
            this.isbnLabel.TabIndex = 18;
            this.isbnLabel.Text = "ISBN";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(54, 40);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(35, 13);
            label4.TabIndex = 17;
            label4.Text = "ISBN:";
            // 
            // authorsLabel
            // 
            this.authorsLabel.AutoSize = true;
            this.authorsLabel.Location = new System.Drawing.Point(96, 66);
            this.authorsLabel.Name = "authorsLabel";
            this.authorsLabel.Size = new System.Drawing.Size(42, 13);
            this.authorsLabel.TabIndex = 16;
            this.authorsLabel.Text = "Autorzy";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(44, 66);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(45, 13);
            label3.TabIndex = 15;
            label3.Text = "Autorzy:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(390, 40);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(30, 13);
            this.dateLabel.TabIndex = 14;
            this.dateLabel.Text = "Data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(308, 40);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 13);
            label2.TabIndex = 13;
            label2.Text = "Data wydania:";
            // 
            // publisherLabel
            // 
            this.publisherLabel.AutoSize = true;
            this.publisherLabel.Location = new System.Drawing.Point(96, 53);
            this.publisherLabel.Name = "publisherLabel";
            this.publisherLabel.Size = new System.Drawing.Size(74, 13);
            this.publisherLabel.TabIndex = 12;
            this.publisherLabel.Text = "Wydawnictwo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 53);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 13);
            label1.TabIndex = 11;
            label1.Text = "Wydawnictwo:";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel.Location = new System.Drawing.Point(96, 25);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(32, 13);
            this.titleLabel.TabIndex = 10;
            this.titleLabel.Text = "Tytuł";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(54, 25);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(35, 13);
            label5.TabIndex = 19;
            label5.Text = "Tytuł:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(253, 25);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(130, 13);
            label6.TabIndex = 20;
            label6.Text = "Okres wypożyczenia (dni):";
            // 
            // maxDaysLabel
            // 
            this.maxDaysLabel.AutoSize = true;
            this.maxDaysLabel.Location = new System.Drawing.Point(390, 25);
            this.maxDaysLabel.Name = "maxDaysLabel";
            this.maxDaysLabel.Size = new System.Drawing.Size(23, 13);
            this.maxDaysLabel.TabIndex = 21;
            this.maxDaysLabel.Text = "Dni";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(58, 94);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(31, 13);
            label7.TabIndex = 22;
            label7.Text = "Opis:";
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(61, 110);
            this.descriptionText.Multiline = true;
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.ReadOnly = true;
            this.descriptionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionText.Size = new System.Drawing.Size(359, 222);
            this.descriptionText.TabIndex = 23;
            // 
            // copyPage
            // 
            this.copyPage.Controls.Add(this.refreshCopyButton);
            this.copyPage.Controls.Add(this.copyList);
            this.copyPage.Location = new System.Drawing.Point(4, 22);
            this.copyPage.Name = "copyPage";
            this.copyPage.Size = new System.Drawing.Size(503, 400);
            this.copyPage.TabIndex = 2;
            this.copyPage.Text = "Egzemplarze";
            this.copyPage.UseVisualStyleBackColor = true;
            // 
            // refreshAvailabilityButton
            // 
            this.refreshAvailabilityButton.Location = new System.Drawing.Point(213, 78);
            this.refreshAvailabilityButton.Name = "refreshAvailabilityButton";
            this.refreshAvailabilityButton.Size = new System.Drawing.Size(75, 23);
            this.refreshAvailabilityButton.TabIndex = 0;
            this.refreshAvailabilityButton.Text = "Odśwież";
            this.refreshAvailabilityButton.UseVisualStyleBackColor = true;
            this.refreshAvailabilityButton.Click += new System.EventHandler(this.refreshAvailabilityButton_Click);
            // 
            // bookingButton
            // 
            this.bookingButton.Location = new System.Drawing.Point(213, 127);
            this.bookingButton.Name = "bookingButton";
            this.bookingButton.Size = new System.Drawing.Size(75, 23);
            this.bookingButton.TabIndex = 1;
            this.bookingButton.Text = "Zarezerwuj";
            this.bookingButton.UseVisualStyleBackColor = true;
            // 
            // availabilityLabel
            // 
            this.availabilityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.availabilityLabel.Location = new System.Drawing.Point(0, 46);
            this.availabilityLabel.Name = "availabilityLabel";
            this.availabilityLabel.Size = new System.Drawing.Size(503, 13);
            this.availabilityLabel.TabIndex = 2;
            this.availabilityLabel.Text = "Informacje";
            this.availabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // copyList
            // 
            this.copyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.inventory,
            this.availability});
            this.copyList.HideSelection = false;
            this.copyList.Location = new System.Drawing.Point(8, 38);
            this.copyList.Name = "copyList";
            this.copyList.Size = new System.Drawing.Size(486, 352);
            this.copyList.TabIndex = 0;
            this.copyList.UseCompatibleStateImageBehavior = false;
            this.copyList.View = System.Windows.Forms.View.Details;
            // 
            // availability
            // 
            this.availability.Text = "Dostępność";
            this.availability.Width = 241;
            // 
            // inventory
            // 
            this.inventory.Text = "Numer inwentarza";
            this.inventory.Width = 240;
            // 
            // refreshCopyButton
            // 
            this.refreshCopyButton.Location = new System.Drawing.Point(8, 3);
            this.refreshCopyButton.Name = "refreshCopyButton";
            this.refreshCopyButton.Size = new System.Drawing.Size(486, 31);
            this.refreshCopyButton.TabIndex = 1;
            this.refreshCopyButton.Text = "Odśwież";
            this.refreshCopyButton.UseVisualStyleBackColor = true;
            this.refreshCopyButton.Click += new System.EventHandler(this.refreshCopyButton_Click);
            // 
            // BookDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 424);
            this.Controls.Add(this.tabControl);
            this.Name = "BookDetails";
            this.Text = "BookDetails";
            this.Load += new System.EventHandler(this.BookDetails_Load);
            this.tabControl.ResumeLayout(false);
            this.informationPage.ResumeLayout(false);
            this.informationPage.PerformLayout();
            this.availabilityPage.ResumeLayout(false);
            this.copyPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage informationPage;
        private System.Windows.Forms.TabPage availabilityPage;
        private System.Windows.Forms.Label isbnLabel;
        private System.Windows.Forms.Label authorsLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label publisherLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label maxDaysLabel;
        private System.Windows.Forms.TextBox descriptionText;
        private System.Windows.Forms.TabPage copyPage;
        private System.Windows.Forms.Button bookingButton;
        private System.Windows.Forms.Button refreshAvailabilityButton;
        private System.Windows.Forms.Label availabilityLabel;
        private System.Windows.Forms.ListView copyList;
        private System.Windows.Forms.ColumnHeader inventory;
        private System.Windows.Forms.ColumnHeader availability;
        private System.Windows.Forms.Button refreshCopyButton;
    }
}