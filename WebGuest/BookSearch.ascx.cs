using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using BibliotekaModel;

namespace WebGuest
{
    /// <summary>
    /// Kontrolka pozwalająca na wyszukiwanie książek.
    /// </summary>
    public partial class BookSearch : System.Web.UI.UserControl
    {
        /// <summary>
        /// Callback wywoływany po zakończeniu wyszukiwania.
        /// </summary>
        public Action onSearch;

        /// <summary>
        /// Lista identyfikatorów pasujących do warunków wyszukiwania.
        /// </summary>
        public List<long> booksID;

        /// <summary>
        /// Procedura ładowania kontrolki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            DateErrorLabel.Text = "";
        }

        /// <summary>
        /// Obsługa naciśnięcia przycisku wyszukiwania. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SerachButton_Click(object sender, EventArgs e)
        {
            DateTime? startDate = StartDatePicker.Date;
            DateTime? endDate = EndDatePicker.Date;
            if (ValidateDateForm(startDate, endDate))
            {
                using (var db = new BibliotekaDB())
                {
                    var query = db.Książka.AsNoTracking().Where(
                            //Książka lub opis zawiera frazę.
                            book => (book.Tytuł.Contains(SearchTextBox.Text) || (DescriptionCheckBox.Checked && book.Opis.Contains(SearchTextBox.Text))) &&
                            //Podany fragemnt isbn występuje w książce.
                            book.ISBN.Contains(ISBNTextBox.Text) &&
                            //Wydawnictwo zawiera frazę.
                            book.Wydawnictwo.Nazwa.Contains(PublisherTextBox.Text) &&
                            //Imię i nazwisko autora zawiera frazę.
                            book.Autor.Any(author => (author.Imię + " " + author.Nazwisko).Contains(AuthorTextBox.Text)) &&
                            //Jeżeli niezaznaczona lub data początkowa starsza od podanej.
                            (!StartDatePicker.Checked || book.Rok_wydania > startDate.Value) &&
                            //Jeżeli niezaznaczona lub data końcowa młodsza od podanej.
                            (!EndDatePicker.Checked || book.Rok_wydania < endDate.Value) &&
                            //Jeżeli tylko elektroniczne.
                            (!OnlyElectronicCheckBox.Checked || book.Egzemplarz.Any(copy => copy.Egzemplarz_elektroniczny != null))
                        );

                    booksID = query.Select(book => book.KsiążkaID).ToList();
                }
            }
            else
            {
                booksID = new List<long>();
            }
            onSearch.Invoke();
        }

        /// <summary>
        /// Sprawdzenie poprawności przedziału dat.
        /// </summary>
        /// <param name="startDate">Data początkowa.</param>
        /// <param name="endDate">Data końcowa.</param>
        /// <returns>True, gdy nie wykryto błędu w wprowadzonym przedziale.</returns>
        private bool ValidateDateForm(DateTime? startDate, DateTime? endDate)
        {
            if (StartDatePicker.Checked && !startDate.HasValue)
            {
                return false;
            }

            if (EndDatePicker.Checked && !endDate.HasValue)
            {
                return false;
            }

            if (startDate.HasValue && endDate.HasValue && endDate.Value < startDate.Value)
            {
                DateErrorLabel.Text = "Wybrano pusty przedział dat";
                return false;
            }

            return true;
        }
    }
}