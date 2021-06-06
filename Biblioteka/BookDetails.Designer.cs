
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
            System.Windows.Forms.Label label8;
            this.tabControl = new System.Windows.Forms.TabControl();
            this.informationPage = new System.Windows.Forms.TabPage();
            this.descriptionText = new System.Windows.Forms.TextBox();
            this.maxDaysLabel = new System.Windows.Forms.Label();
            this.isbnLabel = new System.Windows.Forms.Label();
            this.authorsLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.publisherLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.availabilityPage = new System.Windows.Forms.TabPage();
            this.electronicCopyGroup = new System.Windows.Forms.GroupBox();
            this.lendBookButton = new System.Windows.Forms.Button();
            this.availabilityLabel = new System.Windows.Forms.Label();
            this.bookingButton = new System.Windows.Forms.Button();
            this.refreshAvailabilityButton = new System.Windows.Forms.Button();
            this.copyPage = new System.Windows.Forms.TabPage();
            this.refreshCopyButton = new System.Windows.Forms.Button();
            this.copyList = new System.Windows.Forms.ListView();
            this.inventory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.availability = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.informationPage.SuspendLayout();
            this.availabilityPage.SuspendLayout();
            this.electronicCopyGroup.SuspendLayout();
            this.copyPage.SuspendLayout();
            this.SuspendLayout();
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label4.Location = new System.Drawing.Point(62, 34);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(51, 20);
            label4.TabIndex = 17;
            label4.Text = "ISBN:";
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label3.Location = new System.Drawing.Point(46, 74);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 20);
            label3.TabIndex = 15;
            label3.Text = "Autorzy:";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label2.Location = new System.Drawing.Point(316, 34);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(109, 20);
            label2.TabIndex = 13;
            label2.Text = "Data wydania:";
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label1.Location = new System.Drawing.Point(5, 54);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(109, 20);
            label1.TabIndex = 11;
            label1.Text = "Wydawnictwo:";
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label5.Location = new System.Drawing.Point(66, 14);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(47, 20);
            label5.TabIndex = 19;
            label5.Text = "Tytuł:";
            //
            // label6
            //
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label6.Location = new System.Drawing.Point(234, 14);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(191, 20);
            label6.TabIndex = 20;
            label6.Text = "Okres wypożyczenia (dni):";
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label7.Location = new System.Drawing.Point(68, 94);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(45, 20);
            label7.TabIndex = 22;
            label7.Text = "Opis:";
            //
            // label8
            //
            label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            label8.Location = new System.Drawing.Point(6, 20);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(270, 56);
            label8.TabIndex = 0;
            label8.Text = "Dostępna w wersji elektronicznej";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // tabControl
            //
            this.tabControl.Controls.Add(this.informationPage);
            this.tabControl.Controls.Add(this.availabilityPage);
            this.tabControl.Controls.Add(this.copyPage);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(684, 443);
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
            this.informationPage.Location = new System.Drawing.Point(4, 29);
            this.informationPage.Name = "informationPage";
            this.informationPage.Padding = new System.Windows.Forms.Padding(3);
            this.informationPage.Size = new System.Drawing.Size(676, 410);
            this.informationPage.TabIndex = 0;
            this.informationPage.Text = "Informacje";
            this.informationPage.UseVisualStyleBackColor = true;
            //
            // descriptionText
            //
            this.descriptionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.descriptionText.Location = new System.Drawing.Point(10, 117);
            this.descriptionText.Multiline = true;
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.ReadOnly = true;
            this.descriptionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionText.Size = new System.Drawing.Size(662, 286);
            this.descriptionText.TabIndex = 23;
            //
            // maxDaysLabel
            //
            this.maxDaysLabel.AutoSize = true;
            this.maxDaysLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.maxDaysLabel.Location = new System.Drawing.Point(420, 14);
            this.maxDaysLabel.Name = "maxDaysLabel";
            this.maxDaysLabel.Size = new System.Drawing.Size(33, 20);
            this.maxDaysLabel.TabIndex = 21;
            this.maxDaysLabel.Text = "Dni";
            //
            // isbnLabel
            //
            this.isbnLabel.AutoSize = true;
            this.isbnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.isbnLabel.Location = new System.Drawing.Point(109, 34);
            this.isbnLabel.Name = "isbnLabel";
            this.isbnLabel.Size = new System.Drawing.Size(47, 20);
            this.isbnLabel.TabIndex = 18;
            this.isbnLabel.Text = "ISBN";
            //
            // authorsLabel
            //
            this.authorsLabel.AutoSize = true;
            this.authorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.authorsLabel.Location = new System.Drawing.Point(109, 74);
            this.authorsLabel.Name = "authorsLabel";
            this.authorsLabel.Size = new System.Drawing.Size(63, 20);
            this.authorsLabel.TabIndex = 16;
            this.authorsLabel.Text = "Autorzy";
            //
            // dateLabel
            //
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateLabel.Location = new System.Drawing.Point(420, 34);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(44, 20);
            this.dateLabel.TabIndex = 14;
            this.dateLabel.Text = "Data";
            //
            // publisherLabel
            //
            this.publisherLabel.AutoSize = true;
            this.publisherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.publisherLabel.Location = new System.Drawing.Point(109, 54);
            this.publisherLabel.Name = "publisherLabel";
            this.publisherLabel.Size = new System.Drawing.Size(105, 20);
            this.publisherLabel.TabIndex = 12;
            this.publisherLabel.Text = "Wydawnictwo";
            //
            // titleLabel
            //
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel.Location = new System.Drawing.Point(109, 14);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(43, 20);
            this.titleLabel.TabIndex = 10;
            this.titleLabel.Text = "Tytuł";
            //
            // availabilityPage
            //
            this.availabilityPage.Controls.Add(this.electronicCopyGroup);
            this.availabilityPage.Controls.Add(this.availabilityLabel);
            this.availabilityPage.Controls.Add(this.bookingButton);
            this.availabilityPage.Controls.Add(this.refreshAvailabilityButton);
            this.availabilityPage.Location = new System.Drawing.Point(4, 29);
            this.availabilityPage.Name = "availabilityPage";
            this.availabilityPage.Padding = new System.Windows.Forms.Padding(3);
            this.availabilityPage.Size = new System.Drawing.Size(676, 410);
            this.availabilityPage.TabIndex = 1;
            this.availabilityPage.Text = "Dostępność";
            this.availabilityPage.UseVisualStyleBackColor = true;
            //
            // electronicCopyGroup
            //
            this.electronicCopyGroup.Controls.Add(this.lendBookButton);
            this.electronicCopyGroup.Controls.Add(label8);
            this.electronicCopyGroup.Location = new System.Drawing.Point(198, 189);
            this.electronicCopyGroup.Name = "electronicCopyGroup";
            this.electronicCopyGroup.Size = new System.Drawing.Size(282, 143);
            this.electronicCopyGroup.TabIndex = 3;
            this.electronicCopyGroup.TabStop = false;
            this.electronicCopyGroup.Text = "Wypożyczenie elektroniczne";
            this.electronicCopyGroup.Visible = false;
            //
            // lendBookButton
            //
            this.lendBookButton.Location = new System.Drawing.Point(91, 79);
            this.lendBookButton.Name = "lendBookButton";
            this.lendBookButton.Size = new System.Drawing.Size(97, 37);
            this.lendBookButton.TabIndex = 1;
            this.lendBookButton.Text = "Wypożycz";
            this.lendBookButton.UseVisualStyleBackColor = true;
            //
            // availabilityLabel
            //
            this.availabilityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.availabilityLabel.Location = new System.Drawing.Point(0, 46);
            this.availabilityLabel.Name = "availabilityLabel";
            this.availabilityLabel.Size = new System.Drawing.Size(676, 23);
            this.availabilityLabel.TabIndex = 2;
            this.availabilityLabel.Text = "Informacje";
            this.availabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // bookingButton
            //
            this.bookingButton.Location = new System.Drawing.Point(284, 115);
            this.bookingButton.Name = "bookingButton";
            this.bookingButton.Size = new System.Drawing.Size(110, 41);
            this.bookingButton.TabIndex = 1;
            this.bookingButton.Text = "Zarezerwuj";
            this.bookingButton.UseVisualStyleBackColor = true;
            this.bookingButton.Click += new System.EventHandler(this.bookingButton_Click);
            //
            // refreshAvailabilityButton
            //
            this.refreshAvailabilityButton.Location = new System.Drawing.Point(297, 72);
            this.refreshAvailabilityButton.Name = "refreshAvailabilityButton";
            this.refreshAvailabilityButton.Size = new System.Drawing.Size(80, 37);
            this.refreshAvailabilityButton.TabIndex = 0;
            this.refreshAvailabilityButton.Text = "Odśwież";
            this.refreshAvailabilityButton.UseVisualStyleBackColor = true;
            this.refreshAvailabilityButton.Click += new System.EventHandler(this.refreshAvailabilityButton_Click);
            //
            // copyPage
            //
            this.copyPage.Controls.Add(this.refreshCopyButton);
            this.copyPage.Controls.Add(this.copyList);
            this.copyPage.Location = new System.Drawing.Point(4, 29);
            this.copyPage.Name = "copyPage";
            this.copyPage.Size = new System.Drawing.Size(676, 410);
            this.copyPage.TabIndex = 2;
            this.copyPage.Text = "Egzemplarze";
            this.copyPage.UseVisualStyleBackColor = true;
            //
            // refreshCopyButton
            //
            this.refreshCopyButton.Location = new System.Drawing.Point(8, 3);
            this.refreshCopyButton.Name = "refreshCopyButton";
            this.refreshCopyButton.Size = new System.Drawing.Size(663, 31);
            this.refreshCopyButton.TabIndex = 1;
            this.refreshCopyButton.Text = "Odśwież";
            this.refreshCopyButton.UseVisualStyleBackColor = true;
            this.refreshCopyButton.Click += new System.EventHandler(this.refreshCopyButton_Click);
            //
            // copyList
            //
            this.copyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.inventory,
            this.date,
            this.availability});
            this.copyList.HideSelection = false;
            this.copyList.Location = new System.Drawing.Point(8, 40);
            this.copyList.Name = "copyList";
            this.copyList.Size = new System.Drawing.Size(663, 352);
            this.copyList.TabIndex = 0;
            this.copyList.UseCompatibleStateImageBehavior = false;
            this.copyList.View = System.Windows.Forms.View.Details;
            this.copyList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.copyList_ColumnClick);
            //
            // inventory
            //
            this.inventory.Text = "Numer inwentarza";
            this.inventory.Width = 221;
            //
            // availability
            //
            this.availability.Text = "Dostępność";
            this.availability.Width = 419;
            //
            // date
            //
            this.date.Text = "Data wydruku";
            this.date.Width = 136;
            //
            // BookDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 449);
            this.Controls.Add(this.tabControl);
            this.Name = "BookDetails";
            this.Text = "BookDetails";
            this.Load += new System.EventHandler(this.BookDetails_Load);
            this.tabControl.ResumeLayout(false);
            this.informationPage.ResumeLayout(false);
            this.informationPage.PerformLayout();
            this.availabilityPage.ResumeLayout(false);
            this.electronicCopyGroup.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox electronicCopyGroup;
        private System.Windows.Forms.Button lendBookButton;
        private System.Windows.Forms.ColumnHeader date;
    }
}
