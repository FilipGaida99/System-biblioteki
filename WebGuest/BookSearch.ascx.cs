using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

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

        }

        /// <summary>
        /// Obsługa naciśnięcia przycisku wyszukiwania. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SerachButton_Click(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                DateTime? startDate = StartDatePicker.Date;
                if(StartDatePicker.Checked && !startDate.HasValue)
                {
                    return;
                }

                DateTime? endDate = EndDatePicker.Date;
                if (EndDatePicker.Checked && !endDate.HasValue)
                {
                    return;
                }

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
                        (!EndDatePicker.Checked || book.Rok_wydania < endDate.Value));

                booksID = query.Select(book => book.KsiążkaID).ToList();
            }
            onSearch.Invoke();
        }
    }
}