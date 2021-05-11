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
    public partial class BookManagementForm : Form
    {
        List<Książka> books;

        bool isNewBook = false;
        Książka managedBook;

        public BookManagementForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            managedBook = new Książka();
            isNewBook = true;
            mainPanel.Visible = false;
            modPanel.Visible = true;
            isbnText.Text = "";
            datePicker.Value = new DateTime(2000, 1, 1);
            titleText.Text = "";
            descriptionText.Text = "";
            publisherText.Text = "";
            autorsList.Items.Clear();
        }

        private void modButton_Click(object sender, EventArgs e)
        {
            isNewBook = false;
            mainPanel.Visible = false;
            modPanel.Visible = true;
            if (bookList.SelectedIndex >= 0)
            {
                using (var db = new BibliotekaDB()) {
                    managedBook = db.Książka.Find(books[bookList.SelectedIndex].KsiążkaID);
                    isbnText.Text = managedBook.ISBN;
                    datePicker.Value = managedBook.Rok_wydania;
                    titleText.Text = managedBook.Tytuł;
                    descriptionText.Text = managedBook.Opis;
                    publisherText.Text = managedBook.Wydawnictwo.Nazwa;
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (bookList.SelectedIndex >= 0)
            {
                managedBook = books[bookList.SelectedIndex];
                using (var db = new BibliotekaDB())
                {
                    var id = managedBook.KsiążkaID;
                    db.Książka.Remove(db.Książka.Find(id));
                    db.SaveChanges();
                }
                UpdateBookList();
            }
        }

        private void BookManagementForm_Load(object sender, EventArgs e)
        {
            UpdateBookList();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            managedBook = null;
            mainPanel.Visible = true;
            modPanel.Visible = false;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                managedBook.ISBN = isbnText.Text;
                managedBook.Tytuł = titleText.Text;
                managedBook.Opis = descriptionText.Text;
                managedBook.Rok_wydania = datePicker.Value;

                try
                {
                    managedBook.Wydawnictwo = db.Wydawnictwo.Where(wyd => wyd.Nazwa == publisherText.Text).First();
                    managedBook.WydawnictwoID = managedBook.Wydawnictwo.WydawnictwoID;
                }
                catch
                {
                    managedBook.Wydawnictwo = db.Wydawnictwo.Add(new Wydawnictwo { Nazwa = publisherText.Text });
                }

                //managedBook.Autor = (ICollection<Autor>)autorsList.Items;
                if (isNewBook)
                {
                    db.Książka.Add(managedBook);
                }
                else
                {
                    db.Entry(managedBook).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            managedBook = null;
            mainPanel.Visible = true;
            modPanel.Visible = false;
            UpdateBookList();
        }

        private void UpdateBookList()
        {
            using (var db = new BibliotekaDB())
            {
                bookList.BeginUpdate();
                books = db.Książka.ToList();
                bookList.Items.Clear();
                foreach (var book in books)
                {
                    bookList.Items.Add(book.Tytuł);
                }
                bookList.EndUpdate();
            }
        }

        private void choosePublisherButton_Click(object sender, EventArgs e)
        {
            PublisherForm form = new PublisherForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                publisherText.Text = form.choosedPublisherName;
            }
        }
    }
}
