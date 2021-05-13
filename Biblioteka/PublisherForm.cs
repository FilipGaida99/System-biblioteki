using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class PublisherForm : Form
    {
        public string choosedPublisherName;
        List<Wydawnictwo> publishers;

        public PublisherForm()
        {
            InitializeComponent();
        }

        private void WydawnictwoForm_Load(object sender, EventArgs e)
        {
            using(var db = new BibliotekaDB())
            {
                publishers = db.Wydawnictwo.OrderBy(publisher => publisher.Nazwa).ToList();
                UpdateComboBox();
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex >= 0)
            {
                choosedPublisherName = (string)comboBox.SelectedItem;
                this.Return();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            choosedPublisherName = publisherNameText.Text;
            this.Return();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                publishers = db.Wydawnictwo.Where(publisher => publisher.Nazwa.Contains(publisherNameText.Text)).OrderBy(wyd => wyd.Nazwa).ToList();

                UpdateComboBox();
            }
        }

        private void UpdateComboBox()
        {
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
