
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
            this.readerSearch = new Biblioteka.ReaderSearch();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reservationsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
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
            // readerSearch
            // 
            this.readerSearch.Location = new System.Drawing.Point(6, 15);
            this.readerSearch.Name = "readerSearch";
            this.readerSearch.Size = new System.Drawing.Size(346, 205);
            this.readerSearch.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(665, 583);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.readerSearch);
            this.tabPage1.Controls.Add(this.readersLayoutPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(657, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reservationsLayoutPanel);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(657, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reservationsLayoutPanel
            // 
            this.reservationsLayoutPanel.Location = new System.Drawing.Point(6, 227);
            this.reservationsLayoutPanel.Name = "reservationsLayoutPanel";
            this.reservationsLayoutPanel.Size = new System.Drawing.Size(645, 324);
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
            // CheckoutForm
            // 
            this.ClientSize = new System.Drawing.Size(680, 597);
            this.Controls.Add(this.tabControl1);
            this.Name = "CheckoutForm";
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
    }
}