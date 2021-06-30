using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Formularz zarządzania książkami.
    /// </summary>
    public partial class BookManagementForm : Form
    {
        /// <summary>
        /// Lista znalezionych książek.
        /// </summary>
        List<Książka> books;
        /// <summary>
        /// Lista egzemplarzy wybranej książki.
        /// </summary>
        List<Egzemplarz> copies;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public BookManagementForm()
        {
            InitializeComponent();
            books = new List<Książka>();
            copies = new List<Egzemplarz>();
        }

        /// <summary>
        /// Obsługa modyfikacji wybranej książki/egzemplarza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
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

        /// <summary>
        /// Obsługa usunięcia wybranej książki/egzemplarza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                if (bookList.SelectedIndex >= 0)
                {
                    if (copyList.SelectedIndex >= 0)
                    {
                        DeleteCopy(bookList.SelectedIndex, copyList.SelectedIndex);
                    }
                    else
                    {
                        DeleteBook(bookList.SelectedIndex);
                    }
                }
            }
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void BookManagementForm_Load(object sender, EventArgs e)
        {
            bookSearch.onSearch += OnSearch;
        }

        /// <summary>
        /// Aktualizacja listy książek w formularzu na podstawie zapisanej listy książek.
        /// </summary>
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

        /// <summary>
        /// Aktualizacja listy egzemplarzy wybranej książki na podstawie bazy danych.
        /// </summary>
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

        /// <summary>
        /// Obsługa zmiany wybranej książki.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void bookList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCopyList();
        }

        /// <summary>
        /// Obsługa dodania egzemplarza książki.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
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

        /// <summary>
        /// Callback po zakończeniu wyszukiwania.
        /// </summary>
        private void OnSearch()
        {
            books = bookSearch.resultBooks;
            UpdateBookList();
        }

        /// <summary>
        /// Dodawanie książki
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
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

        /// <summary>
        /// Przejście do zarządzania wydawnictwami.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void publishersButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                PublisherManagementForm form = new PublisherManagementForm();
                form.ShowDialog(this);
            }
        }

        /// <summary>
        /// Przejście do zarządzania wydawnictwami
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void authorsButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                AuthorManagementForm form = new AuthorManagementForm();
                form.ShowDialog(this);
            }
        }

        /// <summary>
        /// Procedura usuwania egzemplarza.
        /// </summary>
        /// <param name="bookIndex">Indeks książki na liście.</param>
        /// <param name="copyIndex">Indeks egzemplarza na liście.</param>
        private void DeleteCopy(int bookIndex, int copyIndex)
        {
            long bookID = books[bookIndex].KsiążkaID;
            var copyID = copies[copyIndex].Nr_inwentarza;

            using (var db = new BibliotekaDB())
            {
                var copyToDelete = db.Egzemplarz.Find(copyID);
                var bookOfCopy = db.Książka.Find(bookID);
                if (!copyToDelete.Available)
                {
                    MessageBox.Show("Nie można usunąć wypożyczonego egzemplarza",
                         "Niedozwolona operacja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show(
                        $"Na pewno chcesz usunąć egzemplarz {copyID}?",
                        "Jesteś pewny?", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (bookOfCopy.Egzemplarz.Count <= 1)
                {
                    DialogResult dialogResult = MessageBox.Show(
                        "Usunięcie ostatniego egzemplarza nie usunie książki. Czy chcesz by została usunięta natychmiast?",
                        "Ostatni egzemplarz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DeleteBook(bookIndex);
                        return;
                    }
                }
                db.Egzemplarz.Remove(copyToDelete);
                db.SaveChanges();
            }

            UpdateCopyList();
        }

        /// <summary>
        /// Procedura usuwania ksiązki.
        /// </summary>
        /// <param name="bookIndex">Indeks książki na liście.</param>
        private void DeleteBook(int bookIndex)
        {
            long bookID = books[bookIndex].KsiążkaID;
            using (var db = new BibliotekaDB())
            {
                var bookToRemove = db.Książka.Find(bookID);
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

                    if(bookToRemove.Rezerwacje.Count > 0)
                    {
                        if (MessageBox.Show(
                        $"Książka ma aktywne rezerwacje. Usunięcie spowoduje anulowanie wszystkich rezerwacji i rozesłanie powiadomień. Kontynnuować?",
                        "Jesteś pewny?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return;
                        }

                        foreach(var reservation in bookToRemove.Rezerwacje)
                        {
                            SendCancelationNotification(reservation);
                        }
                    }

                    db.Książka.Remove(bookToRemove);
                }
                bookList.Items.RemoveAt(bookIndex);
                books.RemoveAt(bookIndex);
                db.SaveChanges();
            }
            copyList.SelectedIndex = -1;
        }

        void SendCancelationNotification(Rezerwacje reservations)
        {
            Wiadomość.SystemNotification("Usunięto rezerwację",
                        $"Książka {reservations.Książka.Tytuł} została usunięta z biblioteki." +
                        $"Twoja rezerwacja tej książki została usunięta. Przepraszamy za zaistniałą sytuację.",
                        reservations.Czytelnik);
        }
    }
}
