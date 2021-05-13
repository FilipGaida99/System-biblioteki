using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class BookRecord : UserControl
    {
        Książka book;

        public BookRecord(Książka presentedBook)
        {
            InitializeComponent();
            book = presentedBook;
        }

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

        private void showButton_Click(object sender, EventArgs e)
        {
            BookDetails form = new BookDetails(book);
            form.Show();
        }
    }
}
