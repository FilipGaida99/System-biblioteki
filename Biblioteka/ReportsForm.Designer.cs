
namespace Biblioteka
{
    partial class ReportsForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.KsiążkaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LibDataSet = new Biblioteka.LibDataSet();
            this.CzytelnikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KsiążkaTableAdapter = new Biblioteka.LibDataSetTableAdapters.KsiążkaTableAdapter();
            this.CzytelnikTableAdapter = new Biblioteka.LibDataSetTableAdapters.CzytelnikTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.reportsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.KsiążkaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LibDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CzytelnikBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // KsiążkaBindingSource
            // 
            this.KsiążkaBindingSource.DataMember = "Książka";
            this.KsiążkaBindingSource.DataSource = this.LibDataSet;
            // 
            // LibDataSet
            // 
            this.LibDataSet.DataSetName = "LibDataSet";
            this.LibDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CzytelnikBindingSource
            // 
            this.CzytelnikBindingSource.DataMember = "Czytelnik";
            this.CzytelnikBindingSource.DataSource = this.LibDataSet;
            // 
            // KsiążkaTableAdapter
            // 
            this.KsiążkaTableAdapter.ClearBeforeFill = true;
            // 
            // CzytelnikTableAdapter
            // 
            this.CzytelnikTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.KsiążkaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Biblioteka.BorrowsReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 52);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(633, 541);
            this.reportViewer1.TabIndex = 0;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(193, 26);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startDateTimePicker.TabIndex = 1;
            this.startDateTimePicker.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(445, 26);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 2;
            this.endDateTimePicker.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.endDateTimePicker_ValueChanged);
            // 
            // reportsComboBox
            // 
            this.reportsComboBox.FormattingEnabled = true;
            this.reportsComboBox.Items.AddRange(new object[] {
            "Wypożyczenia",
            "Czytelnicy"});
            this.reportsComboBox.Location = new System.Drawing.Point(15, 25);
            this.reportsComboBox.Name = "reportsComboBox";
            this.reportsComboBox.Size = new System.Drawing.Size(121, 21);
            this.reportsComboBox.TabIndex = 3;
            this.reportsComboBox.SelectedIndexChanged += new System.EventHandler(this.reportsComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Raport";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data końcowa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data początkowa";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 605);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportsComboBox);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KsiążkaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LibDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CzytelnikBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource KsiążkaBindingSource;
        private LibDataSet LibDataSet;
        private LibDataSetTableAdapters.KsiążkaTableAdapter KsiążkaTableAdapter;
        private System.Windows.Forms.BindingSource CzytelnikBindingSource;
        private LibDataSetTableAdapters.CzytelnikTableAdapter CzytelnikTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.ComboBox reportsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}