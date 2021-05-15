using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Formularz wyboru wydawnictwa.
    /// </summary>
    public partial class PublisherForm : Form
    {
        /// <summary>
        /// Nazwa wybranego wydawnictwa. Wartość zwracana z formularza.
        /// </summary>
        public string choosedPublisherName;
        /// <summary>
        /// Lista znalezionych wydawców.
        /// </summary>
        List<Wydawnictwo> publishers;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public PublisherForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void WydawnictwoForm_Load(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                publishers = db.Wydawnictwo.OrderBy(publisher => publisher.Nazwa).ToList();
                UpdateComboBox();
            }
        }

        /// <summary>
        /// Obsługa wybrania wydawnictwa.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void chooseButton_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex >= 0)
            {
                choosedPublisherName = (string)comboBox.SelectedItem;
                this.Return();
            }
        }

        /// <summary>
        /// Obsługa dodania nowej nazwy wydawnictwa.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void addButton_Click(object sender, EventArgs e)
        {
            choosedPublisherName = publisherNameText.Text;
            this.Return();
        }

        /// <summary>
        /// Obsługa filtrowania wydawnictw.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void filterButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    publishers = db.Wydawnictwo.Where(publisher => publisher.Nazwa.Contains(publisherNameText.Text)).OrderBy(wyd => wyd.Nazwa).ToList();

                    UpdateComboBox();
                }
            }
        }

        /// <summary>
        /// Aktualizacja wyboru wydawnictw.
        /// </summary>
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
