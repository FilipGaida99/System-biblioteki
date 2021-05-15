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
            books = new List<Książka>();
            copies = new List<Egzemplarz>();
        }

        private void modButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                if (bookList.SelectedIndex >= 0)
                {
                    if (copyList.SelectedIndex >= 0)
                    {
                        CopyModificationForm form = new CopyModificationForm(copies[copyList.SelectedIndex], books[bookList.SelectedIndex]);
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
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                if (bookList.SelectedIndex >= 0)
                {
                    var deletedBookID = books[bookList.SelectedIndex].KsiążkaID;
                    if (copyList.SelectedIndex >= 0)
                    {
                        var deletedCopyID = copies[copyList.SelectedIndex].Nr_inwentarza;
                        using (var db = new BibliotekaDB())
                        {
                            var copyToDelete = db.Egzemplarz.Find(deletedCopyID);
                            var bookOfCopy = db.Książka.Find(deletedBookID);
                            if (!copyToDelete.Available)
                            {
                                MessageBox.Show("Nie można usunąć wypożyczonego egzemplarza",
                                     "Niedozwolona operacja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (MessageBox.Show(
                                    $"Na pewno chcesz usunąć egzemplarz {deletedCopyID}?",
                                    "Jesteś pewny?", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                return;
                            }

                            if (bookOfCopy.Egzemplarz.Count <= 1)
                            {
                                DialogResult dialogResult = MessageBox.Show(
                                    "Usunięcie ostatniego egzemplarza usunie także książkę. Czy chcesz kontynuować?",
                                    "Jesteś pewny?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    db.Książka.Remove(bookOfCopy);
                                    bookList.Items.RemoveAt(bookList.SelectedIndex);
                                    bookList.SelectedIndex = -1;
                                }
                                if (dialogResult == DialogResult.No)
                                {
                                    return;
                                }
                            }
                            db.Egzemplarz.Remove(copyToDelete);
                            copyList.SelectedIndex = -1;
                            db.SaveChanges();
                        }

                        UpdateCopyList();
                    }
                    else
                    {
                        using (var db = new BibliotekaDB())
                        {
                            var bookToRemove = db.Książka.Find(deletedBookID);
                            if (bookToRemove != null)
                            {
                                if (!bookToRemove.AllCopiesInLibrary)
                                {
                                    MessageBox.Show("Nie można usunąć wypożyczonej książki",
                                         "Niedozwolona operacja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                if (MessageBox.Show(
                                    $"Na pewno chcesz usunąć książkę {bookToRemove.Tytuł} (ISBN: {bookToRemove.ISBN.Trim()})?",
                                    "Jesteś pewny?", MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    return;
                                }
                                db.Książka.Remove(bookToRemove);
                            }
                            bookList.Items.RemoveAt(bookList.SelectedIndex);
                            db.SaveChanges();
                        }
                        copyList.SelectedIndex = -1;
                        UpdateBookList();
                    }
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
            UpdateCopyList();
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
                            string item = copy.Nr_inwentarza.ToString();
                            if (copy.Egzemplarz_elektroniczny != null)
                            {
                                item += " (E)";
                            }
                            copyList.Items.Add(item);
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
            using (new AppWaitCursor(this, sender))
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
        }

        private void OnSearch()
        {
            books = bookSearch.resultBooks;
            UpdateBookList();
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
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
}
