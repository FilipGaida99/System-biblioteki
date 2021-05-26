using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Formularz wybierania autora.
    /// </summary>
    public partial class AuthorForm : Form
    {
        /// <summary>
        /// Wybrany autor. Wartość zwracana.
        /// </summary>
        public Autor choosedAutor;

        /// <summary>
        /// Lista znalezionych autorów.
        /// </summary>
        List<Autor> authors;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public AuthorForm()
        {
            InitializeComponent();
            authors = new List<Autor>();
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void AutorForm_Load(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                authors = db.Autor.OrderBy(author => author.Nazwisko).ToList();
                UpdateComboBox();
            }
        }

        /// <summary>
        /// Obsługa dodawania autora.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void addButton_Click(object sender, EventArgs e)
        {
            if(firstNameText.Text.Trim() == "" && surnameText.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Nie można dodać pustego autora. Zamknij okno lub wpisz imię i nazwisko.",
                    "Błąd w formularzu", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            choosedAutor = new Autor { Imię = firstNameText.Text, Nazwisko = surnameText.Text };
            this.Return();
        }

        /// <summary>
        /// Obsługa filtrowania wyników.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void filterButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    authors = db.Autor.Where(author =>
                        author.Imię.Contains(firstNameText.Text) && author.Nazwisko.Contains(surnameText.Text)
                        ).OrderBy(author => author.Nazwisko).ToList();

                    UpdateComboBox();
                }
            }
        }

        /// <summary>
        /// Obsługa wybierania autora z listy.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void chooseButton_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex < authors.Count && comboBox.SelectedIndex >= 0)
            {
                choosedAutor = authors[comboBox.SelectedIndex];
                this.Return();
            }
        }

        /// <summary>
        /// Aktualizacja listy autorów.
        /// </summary>
        private void UpdateComboBox()
        {
            comboBox.BeginUpdate();
            comboBox.Items.Clear();
            foreach (var author in authors)
            {
                comboBox.Items.Add($"{author.Imię} {author.Nazwisko}");
            }
            comboBox.EndUpdate();
        }
    }
}
