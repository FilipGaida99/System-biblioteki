using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using BibliotekaModel;

namespace Biblioteka
{
    /// <summary>
    /// Formularz zarządzania wydawnictwami.
    /// </summary>
    public partial class PublisherManagementForm : Form
    {
        /// <summary>
        /// Lista wydawnictw.
        /// </summary>
        List<Wydawnictwo> publishers;
        /// <summary>
        /// Przefiltrowana przez użytkownika lista wydawnictw.
        /// </summary>
        IEnumerable<Wydawnictwo> searchedPublishers;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public PublisherManagementForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Uzyskanie wydawnictwa na podstawie wyboru z listy.
        /// </summary>
        /// <returns>Wybrane wydawnictwo.</returns>
        protected Wydawnictwo GetSelectedPublisher()
        {
            var index = publishersListBox.SelectedIndex;
            if (index >= 0 && index < searchedPublishers.Count())
            {
                var publisher = searchedPublishers.ElementAt(index);
                return publisher;
            }
            return null;
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void PublisherManagementForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            using (new AppWaitCursor(this, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    LoadPublishers(db);
                    publishers.Sort((a, b) => a.Nazwa.CompareTo(b.Nazwa));
                    UpdateList();
                }
            }
        }

        /// <summary>
        /// Przejście do dodawania nowego wydawnictwa.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void addButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                PublisherAddForm form = new PublisherAddForm();
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.choosedPublisher != null)
                    {
                        publishers.Add(form.choosedPublisher);
                        publishers.Sort((a, b) => a.Nazwa.CompareTo(b.Nazwa));
                        UpdateList();
                    }
                }
            }
        }

        /// <summary>
        /// Zmiana wyszukiwanej frazy w nazwach wydawnictwa.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void search_TextChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        /// <summary>
        /// Zmiana warunków szukania wydawnictw wszystkich i tylko nieużywanych.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void unusedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        /// <summary>
        /// Przejście do modyfikacji wydawnictwa.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void modButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                var publisher = GetSelectedPublisher();
                if (publisher != null)
                {
                    PublisherAddForm form = new PublisherAddForm(publisher);
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        using (var db = new BibliotekaDB())
                        {
                            LoadPublishers(db);
                            publishers.Sort((a, b) => a.Nazwa.CompareTo(b.Nazwa));
                            UpdateList();
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Usunięcie wydawnictwa. Tylko nieużywane zostaną usunięte poprawnie.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                var publisher = GetSelectedPublisher();
                if (publisher != null)
                {
                    using (var db = new BibliotekaDB())
                    {
                        publisher = db.Wydawnictwo.Find(publisher.WydawnictwoID);
                        if (publisher.Książka.Count > 0)
                        {
                            string books = "";
                            foreach (var book in publisher.Książka)
                            {
                                books += $"•{book.Tytuł} (ISBN: {book.ISBN})\n";
                            }
                            DialogResult result = MessageBox.Show($"Nie można usunąć \"{publisher.Nazwa}\". Jest ono przypisane do {publisher.Książka.Count} książek:\n" +
                                books,
                                "Używane wydanictwo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        db.Wydawnictwo.Remove(publisher);
                        db.SaveChanges();
                        LoadPublishers(db);
                        publishers.Sort((a, b) => a.Nazwa.CompareTo(b.Nazwa));
                        UpdateList();
                    }
                }
            }
        }

        /// <summary>
        /// Aktualizacja kontrolki listy na podstawie listy wydawnictw i parametrów wyszukiwania.
        /// </summary>
        private void UpdateList()
        {
            searchedPublishers = publishers.Where(p => p.Nazwa.Contains(search.Text) && (!unusedCheckBox.Checked || p.Książka.Count <= 0));
            publishersListBox.BeginUpdate();
            publishersListBox.Items.Clear();
            foreach (var publisher in searchedPublishers)
            {
                string item = publisher.Nazwa;
                if (publisher.Książka.Count <= 0)
                {
                    item += " (Nieużywane)";
                }
                publishersListBox.Items.Add(item);
            }
            publishersListBox.EndUpdate();
        }

        /// <summary>
        /// Pobranie wydawnictw z bazy danych.
        /// </summary>
        /// <param name="db">Kontekst bazy danych.</param>
        private void LoadPublishers(BibliotekaDB db)
        {
            publishers = db.Wydawnictwo.Include(p => p.Książka).ToList();
        }
    }
}
