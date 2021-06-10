using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Kontrolka wyszukiwania książek.
    /// </summary>
    public partial class BookSearch : UserControl
    {
        /// <summary>
        /// Callback wywoływany po zakończeniu wyszukiwania.
        /// </summary>
        public Action onSearch;
        public List<Książka> resultBooks;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public BookSearch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obsługa wybierania autora.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void authorChooseButton_Click(object sender, EventArgs e)
        {
            using(new AppWaitCursor(ParentForm, sender))
            {
                AuthorForm form = new AuthorForm();
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    authorText.Text = $"{form.choosedAutor.Imię} {form.choosedAutor.Nazwisko}";
                }
            }
        }

        /// <summary>
        /// Obsługa wyszukiwania na podstawie ustawionych argumentów.
        /// </summary>
        /// <param name = "sender" > Kontrolka.</ param >
        /// <param name="e">Argumenty.</param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            if(startDatePicker.Checked && endDatePicker.Checked)
            {
                if(endDatePicker.Value < startDatePicker.Value)
                {
                    MessageBox.Show("Wprowadzono pusty przedział dat. Nic nie zostanie znalezione.", "Niepoprawna data",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            using (new AppWaitCursor(ParentForm, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    var query = db.Książka.AsNoTracking().Where(
                        //Książka lub opis zawiera frazę.
                        book => (book.Tytuł.Contains(searchText.Text) || (descriptionSearchCheckBox.Checked && book.Opis.Contains(searchText.Text))) &&
                        //Podany fragemnt isbn występuje w książce.
                        book.ISBN.Contains(isbnText.Text) &&
                        //Wydawnictwo zawiera frazę.
                        book.Wydawnictwo.Nazwa.Contains(publisherPicker.PublisherName) &&
                        //Imię i nazwisko autora zawiera frazę.
                        book.Autor.Any(author => (author.Imię + " " + author.Nazwisko).Contains(authorText.Text)) &&
                        //Jeżeli niezaznaczona lub data początkowa starsza od podanej.
                        (!startDatePicker.Checked || book.Rok_wydania > startDatePicker.Value) &&
                        //Jeżeli niezaznaczona lub data końcowa młodsza od podanej.
                        (!endDatePicker.Checked || book.Rok_wydania < endDatePicker.Value)
                        );

                    resultBooks = query.ToList();
                    onSearch.Invoke();
                }
            }
        }


    }
}
