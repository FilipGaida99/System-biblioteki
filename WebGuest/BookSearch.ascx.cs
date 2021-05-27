using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteka;

namespace WebGuest
{

    public partial class BookSearch : System.Web.UI.UserControl
    {
        public Action onSearch;

        public List<long> booksID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

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