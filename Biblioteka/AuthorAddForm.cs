using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using BibliotekaModel;

namespace Biblioteka
{
    /// <summary>
    /// Formularz wybierania autora.
    /// </summary>
    public partial class AuthorAddForm : Form
    {
        /// <summary>
        /// Wybrany autor. Wartość zwracana.
        /// </summary>
        public Autor choosedAuthor;


        /// <summary>
        /// Konstruktor dodawania.
        /// </summary>
        public AuthorAddForm() : this(null)
        {
        }

        /// <summary>
        /// Konstruktor modyfikowania
        /// </summary>
        /// <param name="author">Autor do modyfikacji.</param>
        public AuthorAddForm(Autor author)
        {
            choosedAuthor = author;
            InitializeComponent();
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void AutorForm_Load(object sender, EventArgs e)
        {
            if (choosedAuthor != null)
            {
                firstNameText.Text = choosedAuthor.Imię;
                surnameText.Text = choosedAuthor.Nazwisko;
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
                if (firstNameText.Text.Trim() == "" && surnameText.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Nie można dodać pustego autora. Zamknij okno lub wpisz imię i nazwisko.",
                        "Błąd w formularzu",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var db = new BibliotekaDB())
                {
                    Autor author = new Autor { Imię = firstNameText.Text.Trim(), Nazwisko = surnameText.Text.Trim() };
                    if (db.Autor.AsEnumerable().Where(a => a.MatchNameWith(author)).Any())
                    {
                        MessageBox.Show("Autor jest już znany. Wybierz autora o podanym imieniu i nazwisku z listy w poprzednim formularzu",
                                "Znany autor",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (choosedAuthor != null)
                    {
                        choosedAuthor = db.Autor.Find(choosedAuthor.AutorID);
                        choosedAuthor.Imię = author.Imię;
                        choosedAuthor.Nazwisko = author.Nazwisko;
                        db.Entry(choosedAuthor).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        choosedAuthor = db.Autor.Add(author);
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
