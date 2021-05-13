using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class BookSearch : UserControl
    {
        public Action onSearch;
        public List<Książka> resultBooks;

        public BookSearch()
        {
            InitializeComponent();
        }

        private void authorChooseButton_Click(object sender, EventArgs e)
        {
            AuthorForm form = new AuthorForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                authorText.Text = $"{form.choosedAutor.Imię} {form.choosedAutor.Nazwisko}"; 
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            using(var db = new BibliotekaDB())
            {
                var query = db.Książka.AsNoTracking().Where(book => book.Tytuł.Contains(searchText.Text) ||
                    (descriptionSearchCheckBox.Checked && book.Opis.Contains(searchText.Text)));
                query = query.Where(book => book.ISBN.Contains(isbnText.Text));
                query = query.Where(book => book.Wydawnictwo.Nazwa.Contains(publisherPicker.PublisherName));
                query = query.Where(book => book.Autor.Any(author => (author.Imię + " " + author.Nazwisko).Contains(authorText.Text)));
                
                if (startDatePicker.Checked)
                {
                    query = query.Where(book => book.Rok_wydania > startDatePicker.Value);
                }
                if (endDatePicker.Checked)
                {
                    query = query.Where(book => book.Rok_wydania < endDatePicker.Value);
                }

                resultBooks = query.ToList();
                onSearch.Invoke();
            }
        }


    }
}
