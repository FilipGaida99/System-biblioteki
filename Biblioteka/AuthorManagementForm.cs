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

namespace Biblioteka
{
    /// <summary>
    /// Formularz zarządzania autorami.
    /// </summary>
    public partial class AuthorManagementForm : Form
    {
        /// <summary>
        /// Lista autorów.
        /// </summary>
        List<Autor> authors;
        /// <summary>
        /// Przefiltrowana przez użytkownika lista autorów.
        /// </summary>
        IEnumerable<Autor> searchedAuthors;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public AuthorManagementForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Uzyskanie autora na podstawie wyboru z listy.
        /// </summary>
        /// <returns>Wybrany autor.</returns>
        protected Autor GetSelectedAuthor()
        {
            var index = authorsListBox.SelectedIndex;
            if (index >= 0 && index < searchedAuthors.Count())
            {
                var author = searchedAuthors.ElementAt(index);
                return author;
            }
            return null;
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void AuthorManagementForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            using (new AppWaitCursor(this, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    LoadAuthors(db);
                    authors.Sort((a, b) => a.Nazwisko.CompareTo(b.Nazwisko));
                    UpdateList();
                }
            }
        }

        /// <summary>
        /// Przejście do dodawania nowego autora.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void addButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                AuthorAddForm form = new AuthorAddForm();
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.choosedAuthor != null)
                    {
                        authors.Add(form.choosedAuthor);
                        authors.Sort(CompareAuthors);
                        UpdateList();
                    }
                }
            }
        }

        /// <summary>
        /// Zmiana wyszukiwanej frazy w imionach i nazwiskach autorów.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void search_TextChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        /// <summary>
        /// Zmiana warunków szukania autorów wszystkich i tylko nieużywanych.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void unusedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        /// <summary>
        /// Przejście do modyfikacji autora.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void modButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                var author = GetSelectedAuthor();
                if (author != null)
                {
                    AuthorAddForm form = new AuthorAddForm(author);
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        using (var db = new BibliotekaDB())
                        {
                            LoadAuthors(db);
                            authors.Sort(CompareAuthors);
                            UpdateList();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Usunięcie autora. Tylko nieużywani zostaną usunięci poprawnie.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                var author = GetSelectedAuthor();
                if (author != null)
                {
                    using (var db = new BibliotekaDB())
                    {
                        author = db.Autor.Find(author.AutorID);
                        if (author.Książka.Count > 0)
                        {
                            string books = "";
                            foreach (var book in author.Książka)
                            {
                                books += $"•{book.Tytuł} (ISBN: {book.ISBN})\n";
                            }
                            DialogResult result = MessageBox.Show($"Nie można usunąć autora/autorki: {author.Imię} {author.Nazwisko}. Jest on/ona przypisany do {author.Książka.Count} książek:\n" +
                                books,
                                "Używany autor",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        db.Autor.Remove(author);
                        db.SaveChanges();
                        LoadAuthors(db);
                        authors.Sort(CompareAuthors);
                        UpdateList();
                    }
                }
            }
        }

        /// <summary>
        /// Aktualizacja kontrolki listy na podstawie listy autorów i parametrów wyszukiwania.
        /// </summary>
        private void UpdateList()
        {
            searchedAuthors = authors.Where(a => (a.Imię + " " + a.Nazwisko).Contains(search.Text) && (!unusedCheckBox.Checked || a.Książka.Count <= 0));
            authorsListBox.BeginUpdate();
            authorsListBox.Items.Clear();
            foreach (var author in searchedAuthors)
            {
                string item = $"{author.Imię} {author.Nazwisko}";
                if (author.Książka.Count <= 0)
                {
                    item += " (Nieużywany)";
                }
                authorsListBox.Items.Add(item);
            }
            authorsListBox.EndUpdate();
        }

        /// <summary>
        /// Pobranie autorów z bazy danych.
        /// </summary>
        /// <param name="db">Kontekst bazy danych.</param>
        private void LoadAuthors(BibliotekaDB db)
        {
            authors = db.Autor.Include(p => p.Książka).ToList();
        }

        /// <summary>
        /// Porównywanie przy sortowaniu dwóch autorów.
        /// </summary>
        /// <param name="a">Pierwszy autor.</param>
        /// <param name="b">Drugi autor.</param>
        /// <returns>0, gdy równi. Większe od 0, gdy pierwszy powinien być wcześniej na liście.</returns>
        private int CompareAuthors(Autor a, Autor b)
        {
            var result = a.Nazwisko.CompareTo(b.Nazwisko);
            if (result == 0)
            {
                return a.Imię.CompareTo(b.Imię);
            }
            return result;
        }
    }
}
