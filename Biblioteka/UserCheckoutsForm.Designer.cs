
namespace Biblioteka
{
    partial class UserCheckoutsForm
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
            this.checkoutsList = new System.Windows.Forms.ListView();
            this.bookTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkoutDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.expectedReturnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inventory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.returnedChecBox = new System.Windows.Forms.CheckBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.returnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wypożyczenia:";
            // 
            // checkoutsList
            // 
            this.checkoutsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bookTitle,
            this.checkoutDate,
            this.expectedReturnDate,
            this.returnDate,
            this.inventory});
            this.checkoutsList.HideSelection = false;
            this.checkoutsList.Location = new System.Drawing.Point(12, 43);
            this.checkoutsList.Name = "checkoutsList";
            this.checkoutsList.Size = new System.Drawing.Size(640, 242);
            this.checkoutsList.TabIndex = 1;
            this.checkoutsList.UseCompatibleStateImageBehavior = false;
            this.checkoutsList.View = System.Windows.Forms.View.Details;
            this.checkoutsList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.CheckoutsList_ColumnClick);
            // 
            // bookTitle
            // 
            this.bookTitle.Text = "Tytuł";
            this.bookTitle.Width = 140;
            // 
            // checkoutDate
            // 
            this.checkoutDate.Text = "Data wypożyczenia";
            this.checkoutDate.Width = 139;
            // 
            // expectedReturnDate
            // 
            this.expectedReturnDate.Text = "Przewidywany zwrot";
            this.expectedReturnDate.Width = 140;
            // 
            // inventory
            // 
            this.inventory.Text = "Nr inwentarza";
            this.inventory.Width = 80;
            // 
            // returnedChecBox
            // 
            this.returnedChecBox.AutoSize = true;
            this.returnedChecBox.Location = new System.Drawing.Point(421, 13);
            this.returnedChecBox.Name = "returnedChecBox";
            this.returnedChecBox.Size = new System.Drawing.Size(105, 17);
            this.returnedChecBox.TabIndex = 2;
            this.returnedChecBox.Text = "Pokaż zwrócone";
            this.returnedChecBox.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(329, 9);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Odśwież";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(238, 9);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(75, 23);
            this.returnButton.TabIndex = 4;
            this.returnButton.Text = "Zwróć";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // returnDate
            // 
            this.returnDate.Text = "Data zwrotu";
            this.returnDate.Width = 132;
            // 
            // UserCheckoutsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 297);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.returnedChecBox);
            this.Controls.Add(this.checkoutsList);
            this.Controls.Add(this.label1);
            this.Name = "UserCheckoutsForm";
            this.Text = "UserCheckoutsForm";
            this.Load += new System.EventHandler(this.UserCheckoutsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView checkoutsList;
        private System.Windows.Forms.ColumnHeader bookTitle;
        private System.Windows.Forms.ColumnHeader checkoutDate;
        private System.Windows.Forms.ColumnHeader inventory;
        private System.Windows.Forms.ColumnHeader expectedReturnDate;
        private System.Windows.Forms.CheckBox returnedChecBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.ColumnHeader returnDate;
    }
}