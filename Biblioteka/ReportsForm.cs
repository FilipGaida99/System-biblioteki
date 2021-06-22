using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class ReportsForm : Form
    {
        private Microsoft.Reporting.WinForms.ReportDataSource readersReportDataSource;
        private Microsoft.Reporting.WinForms.ReportDataSource borrowsReportDataSource;
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            borrowsReportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", this.KsiążkaBindingSource);
            readersReportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", this.CzytelnikBindingSource);
            reportsComboBox.SelectedIndex = 0;

            this.KsiążkaTableAdapter.Fill(this.LibDataSet.Książka, new DateTime(2021, 1, 1), new DateTime(2022, 1, 1));
            this.reportViewer1.RefreshReport();
        }

        private void reportsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportsComboBox.SelectedIndex == 0)
            {
                reportViewer1.Reset();
                this.reportViewer1.LocalReport.DataSources.Add(this.borrowsReportDataSource);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Biblioteka.BorrowsReport.rdlc";
                RefillReport();
            }
            else if(reportsComboBox.SelectedIndex == 1)
            {
                reportViewer1.Reset();
                this.reportViewer1.LocalReport.DataSources.Add(this.readersReportDataSource);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Biblioteka.ReadersReport.rdlc";
                RefillReport();
            }
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            RefillReport();
        }

        private void endDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            RefillReport();
        }
        private void RefillReport()
        {
            if (reportsComboBox.SelectedIndex == 0)
            {
                this.KsiążkaTableAdapter.Fill(this.LibDataSet.Książka, startDateTimePicker.Value, endDateTimePicker.Value);
                this.reportViewer1.RefreshReport();
            }
            else if (reportsComboBox.SelectedIndex == 1)
            {
                this.CzytelnikTableAdapter.Fill(this.LibDataSet.Czytelnik, startDateTimePicker.Value, endDateTimePicker.Value);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
