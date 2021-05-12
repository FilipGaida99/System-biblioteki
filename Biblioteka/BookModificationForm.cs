using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class BookModificationForm : Form
    {
        bool isNewBook;
        public Książka managedBook;
        List<Autor> authors;

        public BookModificationForm()
        {
            InitializeComponent();
            authors = new List<Autor>();
            isNewBook = true;
            managedBook = new Książka();
        }

        public BookModificationForm(Książka _managedBook)
        {
            InitializeComponent();
            authors = new List<Autor>();
            isNewBook = false;
            managedBook = _managedBook;
        }

        protected virtual bool Accept(BibliotekaDB db)
        {
            if(!isNewBook)
            {
                managedBook = db.Książka.Find(managedBook.KsiążkaID);
            }

            managedBook.ISBN = isbnText.Text;
            managedBook.Tytuł = titleText.Text;
            managedBook.Opis = descriptionText.Text;
            managedBook.Rok_wydania = datePicker.Value;
            managedBook.Maksymalny_okres_wypożyczenia = (long)daySpanPicker.Value;

            if(!managedBook.SetPublisher(db, publisherPicker.PublisherName))
            {
                return false;
            }
            
            if(!managedBook.SetAuthors(db, authors))
            {
                return false;
            }

            if (isNewBook)
            {
                db.Książka.Add(managedBook);
            }
            else
            {
                db.Entry(managedBook).State = EntityState.Modified;
            }
            
            return true;
        }

        private void BookModificationForm_Load(object sender, EventArgs e)
        {
            if (!isNewBook)
            {
                using (var db = new BibliotekaDB())
                {
                    managedBook = db.Książka.Find(managedBook.KsiążkaID);
                    isbnText.Text = managedBook.ISBN;
                    datePicker.Value = managedBook.Rok_wydania;
                    titleText.Text = managedBook.Tytuł;
                    descriptionText.Text = managedBook.Opis;
                    publisherPicker.PublisherName = managedBook.Wydawnictwo.Nazwa;
                    daySpanPicker.Value = managedBook.Maksymalny_okres_wypożyczenia;

                    var list = managedBook.Autor.OrderBy(author => author.Nazwisko).ToList();
                    foreach (var author in list)
                    {
                        AddAutor(author);
                    }
                }
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                if (Accept(db)) 
                {
                    db.SaveChanges();
                }
                else
                {
                    return;
                }
            }
            this.Return();
        }

        private void addAutorButton_Click(object sender, EventArgs e)
        {
            AuthorForm form = new AuthorForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                AddAutor(form.choosedAutor);
            }
        }

        private void deleteAutorButton_Click(object sender, EventArgs e)
        {
            if(authorsList.SelectedIndex >= 0)
            {
                authors.RemoveAt(authorsList.SelectedIndex);
                authorsList.Items.RemoveAt(authorsList.SelectedIndex);
                authorsList.SelectedIndex = -1;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Return();
        }

        private void AddAutor(Autor author)
        {
            if (!authors.Exists(_author => _author.MatchNameWith(author)))
            { 
                authorsList.Items.Add($"{author.Imię} {author.Nazwisko}");
                authors.Add(author);
            }
        }

    }
}
