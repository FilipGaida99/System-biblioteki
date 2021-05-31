using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteka;


namespace WebGuest
{
    /// <summary>
    /// Strona wyszukiwania książek. Zawiera kontrolkę do wyszukiwania oraz listę znalezionych wyników.
    /// </summary>
    public partial class Browse : System.Web.UI.Page
    {
        /// <summary>
        /// Ścieżka do kontrolki wyświetlającej dane o książce.
        /// </summary>
        const string bookRecordControlPath = "~/BookRecord.ascx";

        /// <summary>
        /// Procedura ładowania strony.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            BookSearch.onSearch += OnSearch;
        }

        /// <summary>
        /// Obsługa wyszukania zestawu książek.
        /// </summary>
        private void OnSearch()
        {
            var books = BookSearch.booksID;
            if (books != null)
            {
                foreach (var book in books)
                {
                    AddBook(book);
                }
            }
        }

        /// <summary>
        /// Dodawanie książki do listy na stronie.
        /// </summary>
        /// <param name="bookID">Identyfikator książki zawierającej wyświetlane informacje</param>
        private void AddBook(long bookID)
        {
            var rec = (BookRecord)Page.LoadControl(bookRecordControlPath);
            rec.ID = $"Book{bookID}";
            rec.managedBookID = bookID;
            BookRecordPanel.Controls.Add(rec);
        }
    }
}