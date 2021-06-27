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
    /// <summary>
    /// Form zarządzający oczekującymi prolongatami.
    /// </summary>
    public partial class ExtensionForm : Form
    {
        /// <summary>
        /// Lista prolongat.
        /// </summary>
        List<Prolongata> extensions;

        /// <summary>
        /// Obiekt sortujący kolumny ListView.
        /// </summary>
        ListViewColumnSorter listViewColumnSorter;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ExtensionForm()
        {
            InitializeComponent();
            listViewColumnSorter = new ListViewColumnSorter(extensionList.Columns.Count);
            listViewColumnSorter.SortColumn = 3;
            listViewColumnSorter.Order = SortOrder.Ascending;
            extensionList.ListViewItemSorter = listViewColumnSorter;
            extensions = new List<Prolongata>();
        }

        /// <summary>
        /// Aktualizacja listy prolongat w formularzu.
        /// </summary>
        private void UpdateExtensionList()
        {
            using (var db = new BibliotekaDB())
            {
                extensionList.BeginUpdate();
                extensionList.Items.Clear();
                foreach (var ex in extensions)
                {
                    Wypożyczenie wypozyczenie = ex.Wypożyczenie;
                    Czytelnik reader = wypozyczenie.Czytelnik;
                    string[] row = {
                        reader.Imię, reader.Nazwisko, reader.CzytelnikID.ToString(),
                        wypozyczenie.Przewidywany_zwrot.ToString("yyyy.MM.dd"), wypozyczenie.Egzemplarz.Książka.Tytuł
                    };
                    extensionList.Items.Add(new ListViewItem(row));
                }
                extensionList.Sort();
                extensionList.EndUpdate();
            }
        }

        private void ExtensionForm_Load(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                extensions = db.Prolongata.Where(ex => ex.Status == null).OrderBy(ex => ex.Wypożyczenie.Data_wypożyczenia).ToList();
                UpdateExtensionList();
            }
        }

        /// <summary>
        /// Obsługa akceptacji prolongat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acceptButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                var selected = extensionList.SelectedIndices;
                if (selected.Count == 0) return;

                var result = MessageBox.Show(
                    $"Na pewno chcesz zaakceptować te prolongaty ({selected.Count})?",
                    "Na pewno?", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;

                AcceptExtensions(selected);
            }
        }

        /// <summary>
        /// Akceptacja prolongaty.
        /// </summary>
        /// <param name="selected">Kolekcja indeksów prolongat.</param>
        private void AcceptExtensions(ListView.SelectedIndexCollection selected)
        {
            using (var db = new BibliotekaDB())
            {
                for (int i = 0; i < selected.Count; ++i)
                {
                    int extensionIndex = selected[i];
                    var extensionID = extensions[extensionIndex].ProlongataID;

                    Prolongata extensionToAccept = db.Prolongata.Find(extensionID);

                    if (extensionToAccept != null)
                    {
                        extensionToAccept.Status = 1;
                        Wypożyczenie checkout = extensionToAccept.Wypożyczenie;
                        extensionToAccept.Data_prolongaty =
                            checkout.Przewidywany_zwrot.AddDays(
                                checkout.Egzemplarz.Książka.Maksymalny_okres_wypożyczenia);
                    }
                    extensionList.Items.RemoveAt(extensionIndex);
                    extensions.RemoveAt(extensionIndex);
                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Odrzucenie prolongaty.
        /// </summary>
        /// <param name="selected">Kolekcja indeksów prolongat.</param>
        private void DiscardExtensions(ListView.SelectedIndexCollection selected)
        {
            using (var db = new BibliotekaDB())
            {
                for(int i = 0; i < selected.Count; ++i)
                {
                    int extensionIndex = selected[i];
                    var extensionID = extensions[extensionIndex].ProlongataID;

                    Prolongata extensionToDiscard = db.Prolongata.Find(extensionID);

                    if (extensionToDiscard != null)
                        extensionToDiscard.Status = 0;
                    extensionList.Items.RemoveAt(extensionIndex);
                    extensions.RemoveAt(extensionIndex);
                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Obsługa odrzucenia prolongaty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void discardButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                var selected = extensionList.SelectedIndices;
                if (selected.Count == 0) return;
                    
                var result = MessageBox.Show(
                    $"Na pewno chcesz odrzucić te prolongaty ({selected.Count})?",
                    "Na pewno?", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;

                DiscardExtensions(selected);
            }
        }
    }
}
