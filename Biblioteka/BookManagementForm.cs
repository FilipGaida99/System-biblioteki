using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class BookManagementForm : Form
    {
        List<Książka> books;
        List<Egzemplarz> copies;

        public BookManagementForm()
        {
            InitializeComponent();
        }

        private void modButton_Click(object sender, EventArgs e)
        {
            if (bookList.SelectedIndex >= 0)
            {
                if (copyList.SelectedIndex >= 0)
                {
                    CopyModificationForm form = new CopyModificationForm(copies[copyList.SelectedIndex],books[bookList.SelectedIndex]);
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        UpdateCopyList();
                    }
                }
                else 
                { 
                    BookModificationForm form = new BookModificationForm(books[bookList.SelectedIndex]);
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                       books[bookList.SelectedIndex] = form.managedBook;
                       UpdateBookList();
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (bookList.SelectedIndex >= 0)
            {
                var deletedBookID = books[bookList.SelectedIndex].KsiążkaID;
                if (copyList.SelectedIndex >= 0)
                {
                    var deletedCopyID = copies[copyList.SelectedIndex].Nr_inwentarza;
                    using (var db = new BibliotekaDB())
                    {
                        if(db.Książka.Find(deletedBookID).Egzemplarz.Count <= 1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Usunięcie ostatniego egzemplarza usunie także książkę. Czy chcesz kontynuować?", "Jesteś pewny?", MessageBoxButtons.YesNo);
                            if(dialogResult == DialogResult.Yes)
                            {
                                db.Książka.Remove(db.Książka.Find(deletedBookID));
                                bookList.Items.RemoveAt(bookList.SelectedIndex);
                                bookList.SelectedIndex = -1;
                            }
                            if(dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }
                        db.Egzemplarz.Remove(db.Egzemplarz.Find(deletedCopyID));
                        copyList.SelectedIndex = -1;
                        db.SaveChanges();
                    }

                    UpdateCopyList();
                }
                else
                {
                    using (var db = new BibliotekaDB())
                    {
                        db.Książka.Remove(db.Książka.Find(deletedBookID));
                        db.SaveChanges();
                    }
                    copyList.SelectedIndex = -1;
                    UpdateCopyList();
                    UpdateBookList();
                }
            }
        }

        private void BookManagementForm_Load(object sender, EventArgs e)
        {
            bookSearch.onSearch += OnSearch;
        }

        private void UpdateBookList()
        {
            bookList.BeginUpdate();
            bookList.Items.Clear();
            foreach (var book in books)
            {
                bookList.Items.Add(book.Tytuł);
            }
            bookList.EndUpdate();
        }

        private void UpdateCopyList()
        {
            copyList.BeginUpdate();
            copyList.Items.Clear();
            if (bookList.SelectedIndex >= 0)
            {
                using (var db = new BibliotekaDB())
                {
                    Książka book = db.Książka.Find(books[bookList.SelectedIndex].KsiążkaID);
                    if (book != null)
                    {
                        copies = book.Egzemplarz.ToList();
                        foreach (var copy in copies)
                        {
                            copyList.Items.Add(copy.Nr_inwentarza);
                        }
                    }
                }
            }
            copyList.EndUpdate();
        }

        private void bookList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCopyList();
        }

        private void addCopy_Click(object sender, EventArgs e)
        {
            if (bookList.SelectedIndex >= 0)
            {
                CopyModificationForm form = new CopyModificationForm(books[bookList.SelectedIndex]);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    UpdateCopyList();
                }
            }
        }

        private void OnSearch()
        {
            books = bookSearch.resultBooks;
            UpdateBookList();
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            BookAddForm form = new BookAddForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (form.managedBook != null)
                {
                    books.Add(form.managedBook);
                    UpdateBookList();
                }
            }
        }
    }
}
