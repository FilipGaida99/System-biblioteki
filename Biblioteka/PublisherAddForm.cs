using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Formularz dodawania/modyfikowania wydawnictwa.
    /// </summary>
    public partial class PublisherAddForm : Form
    {
        /// <summary>
        /// Nazwa wybranego wydawnictwa. Wartość zwracana z formularza.
        /// </summary>
        public Wydawnictwo choosedPublisher;

        /// <summary>
        /// Konstruktor dodawania.
        /// </summary>
        public PublisherAddForm(): this(null)
        {
        }

        /// <summary>
        /// Konstruktor modyfikowania
        /// </summary>
        /// <param name="publisher">Wydawnictwo do modyfikacji.</param>
        public PublisherAddForm(Wydawnictwo publisher)
        {
            choosedPublisher = publisher;
            InitializeComponent();
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void PublisherAddForm_Load(object sender, EventArgs e)
        {
            if (choosedPublisher != null) {
                publisherNameText.Text = choosedPublisher.Nazwa;
            }
        }

        /// <summary>
        /// Zaakceptowanie zmian.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void acceptButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                if (publisherNameText.Text.Trim() == "")
                {
                    MessageBox.Show("Nazwa jest pusta.\nJeżeli nazwa nie jest pusta wybierz je z listy w poprzednim formularzu",
                        "Błędna nazwa",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var db = new BibliotekaDB())
                {
                    if(db.Wydawnictwo.Any(p => p.Nazwa == publisherNameText.Text))
                    {
                        MessageBox.Show("Nazwa jest używana. Wybierz wydawnictwo o podanej nazwie z listy w poprzednim formularzu",
                            "Używana nazwa",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (choosedPublisher != null)
                    {
                        choosedPublisher = db.Wydawnictwo.Find(choosedPublisher.WydawnictwoID);
                        choosedPublisher.Nazwa = publisherNameText.Text;
                        db.Entry(choosedPublisher).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        choosedPublisher = db.Wydawnictwo.Add(new Wydawnictwo { Nazwa = publisherNameText.Text });
                        db.SaveChanges();
                    }
                }
            }
            this.Return();
        }

        /// <summary>
        /// Anulowanie zmian.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Return(DialogResult.Cancel);
        }
    }
}
