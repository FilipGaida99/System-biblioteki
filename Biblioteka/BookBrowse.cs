using System;
using System.Windows.Forms;
using BibliotekaModel;

namespace Biblioteka
{
    /// <summary>
    /// Formularz przeglądania księgozbioru.
    /// </summary>
    public partial class BookBrowse : Form
    {
        /// <summary>
        /// ID czytelnika któremu wypożyczana jest książka
        /// </summary>
        long? readerID;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public BookBrowse(long? readerID)
        {
            InitializeComponent();
            this.readerID = readerID;
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void BookBrowse_Load(object sender, EventArgs e)
        {
            bookSearch.onSearch += OnSearch;
        }

        /// <summary>
        /// Akcja wywoływana po uzyskaniu wyników wyszukiwania.
        /// </summary>
        private void OnSearch()
        {
            bookLayout.Controls.Clear();
            foreach(var book in bookSearch.resultBooks)
            {
                bookLayout.Controls.Add(new BookRecord(book, readerID));
            }
        }
    }
}
