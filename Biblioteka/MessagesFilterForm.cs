using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotekaModel;

namespace Biblioteka
{
    public partial class MessagesFilterForm : Form
    {
        public MessagesFilterForm()
        {
            InitializeComponent();
            fromDateTimePicker.Value = DateTime.Now;
            toDateTimePicker.Value = DateTime.Now;
        }

        private void MessagesFilterForm_Load(object sender, EventArgs e)
        {
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            fromDateTimePicker.Value = DateTime.Now;
            toDateTimePicker.Value = DateTime.Now;
            fromUserTextBox.Text = "";
            toUserTextBox.Text = "";
            titleTextBox.Text = "";
            conentTextBox.Text = "";
            fromCheckBox.Checked = false;
            toCheckBox.Checked = false;
        }

        private void fromCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fromCheckBox.Checked == true)
                fromDateTimePicker.Enabled = true;
            else
                fromDateTimePicker.Enabled = false;
        }

        private void toCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (toCheckBox.Checked == true)
                toDateTimePicker.Enabled = true;
            else
                toDateTimePicker.Enabled = false;
        }
    }
}
