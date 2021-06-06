
namespace Biblioteka
{
    partial class UserReservationsForm
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
            this.reservationsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Moje rezerwacje:";
            // 
            // reservationsLayoutPanel
            // 
            this.reservationsLayoutPanel.AutoScroll = true;
            this.reservationsLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reservationsLayoutPanel.Location = new System.Drawing.Point(12, 32);
            this.reservationsLayoutPanel.Name = "reservationsLayoutPanel";
            this.reservationsLayoutPanel.Size = new System.Drawing.Size(484, 295);
            this.reservationsLayoutPanel.TabIndex = 1;
            // 
            // UserReservationsForm
            // 
            this.ClientSize = new System.Drawing.Size(508, 339);
            this.Controls.Add(this.reservationsLayoutPanel);
            this.Controls.Add(this.label1);
            this.Name = "UserReservationsForm";
            this.Text = "Moje rezerwacje";
            this.Load += new System.EventHandler(this.UserReservationsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel reservationsLayoutPanel;
    }
}