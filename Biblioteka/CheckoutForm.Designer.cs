
using System.IO;

namespace Biblioteka
{
    partial class CheckoutForm
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
            this.readersLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.readerSearch = new Biblioteka.ReaderSearch();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reservationSearch1 = new Biblioteka.ReservationSearch();
            this.reservationsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // readersLayoutPanel
            // 
            this.readersLayoutPanel.AutoScroll = true;
            this.readersLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.readersLayoutPanel.Location = new System.Drawing.Point(15, 226);
            this.readersLayoutPanel.Name = "readersLayoutPanel";
            this.readersLayoutPanel.Size = new System.Drawing.Size(498, 317);
            this.readersLayoutPanel.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 583);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.readerSearch);
            this.tabPage1.Controls.Add(this.readersLayoutPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(520, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // readerSearch
            // 
            this.readerSearch.Location = new System.Drawing.Point(87, 15);
            this.readerSearch.Name = "readerSearch";
            this.readerSearch.Size = new System.Drawing.Size(346, 205);
            this.readerSearch.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reservationSearch1);
            this.tabPage2.Controls.Add(this.reservationsLayoutPanel);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(520, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reservationSearch1
            // 
            this.reservationSearch1.Location = new System.Drawing.Point(53, 8);
            this.reservationSearch1.Name = "reservationSearch1";
            this.reservationSearch1.Size = new System.Drawing.Size(422, 186);
            this.reservationSearch1.TabIndex = 2;
            // 
            // reservationsLayoutPanel
            // 
            this.reservationsLayoutPanel.AutoScroll = true;
            this.reservationsLayoutPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.reservationsLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reservationsLayoutPanel.Location = new System.Drawing.Point(6, 227);
            this.reservationsLayoutPanel.Name = "reservationsLayoutPanel";
            this.reservationsLayoutPanel.Size = new System.Drawing.Size(508, 324);
            this.reservationsLayoutPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(3, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rezerwacje:";
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = (new FileInfo(@"Help/help.chm")).FullName;
            // 
            // CheckoutForm
            // 
            this.ClientSize = new System.Drawing.Size(571, 597);
            this.Controls.Add(this.tabControl1);
            this.Name = "CheckoutForm";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Wypożyczanie";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion
        private System.Windows.Forms.FlowLayoutPanel readersLayoutPanel;
        private ReaderSearch readerSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel reservationsLayoutPanel;
        private ReservationSearch reservationSearch1;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}