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
    public partial class PublisherForm : Form
    {
        public string choosedPublisherName;

        public PublisherForm()
        {
            InitializeComponent();
        }

        private void WydawnictwoForm_Load(object sender, EventArgs e)
        {
            using(var db = new BibliotekaDB())
            {
                var publishers = db.Wydawnictwo.OrderBy(wyd => wyd.Nazwa).ToList();
                comboBox.BeginUpdate();
                foreach (var publisher in publishers)
                {
                    comboBox.Items.Add(publisher.Nazwa);
                }
                comboBox.EndUpdate();
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            choosedPublisherName = (string)comboBox.SelectedItem;
            Return();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            choosedPublisherName = nazwa.Text;
            Return();
        }

        private void Return()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                var publishers = db.Wydawnictwo.Where(wyd => wyd.Nazwa.Contains(nazwa.Text)).OrderBy(wyd => wyd.Nazwa).ToList();
                
                comboBox.BeginUpdate();
                comboBox.Items.Clear();
                foreach (var publisher in publishers)
                {
                    comboBox.Items.Add(publisher.Nazwa);
                }
                comboBox.EndUpdate();
            }
        }
    }
}
