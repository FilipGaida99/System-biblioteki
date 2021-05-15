using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Kontrolka przedstawiająca podstawowe informacje o książce, do wyświetlenia podczas przeglądania.
    /// </summary>
    public partial class BookRecord : UserControl
    {
        /// <summary>
        /// Prezentowana ksiązka dostarczająca informacje.
        /// </summary>
        Książka book;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="presentedBook">Prezentowana ksiązka.</param>
        public BookRecord(Książka presentedBook)
        {
            InitializeComponent();
            book = presentedBook;
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void BookRecord_Load(object sender, EventArgs e)
        {
            titleLabel.Text = book.Tytuł;
            isbnLabel.Text = book.ISBN;
            yearLabel.Text = book.Rok_wydania.Year.ToString();
            publisherLabel.Text = book.Wydawnictwo.Nazwa;
            var authors = book.Autor.OrderBy(_author => _author.Nazwisko).ToList();

            authorsLabel.Text = $"{authors[0].Imię} {authors[0].Nazwisko}";
            for(int i = 1; i< authors.Count; i++)
            {
                authorsLabel.Text += $",{authors[i].Imię} {authors[i].Nazwisko}";
            }
        }

        /// <summary>
        /// Obsługa wyświetlenia szczegółów.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void showButton_Click(object sender, EventArgs e)
        {
            using(new AppWaitCursor(ParentForm, sender))
            {
                BookDetails form = new BookDetails(book);
                form.Show();
            }
        }
    }
}
