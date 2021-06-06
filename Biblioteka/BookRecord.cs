using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

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
        /// Klucz główny czytelnika, któremu można wypożyczyć daną książkę
        /// </summary>
        long? readerID;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="presentedBook">Prezentowana ksiązka.</param>
        /// <param name="readerID">ID czytelnika któremu bibliotekarz wypożycza książkę</param>
        public BookRecord(Książka presentedBook, long? readerID)
        {
            InitializeComponent();
            book = presentedBook;
            checkoutToReader.Visible = false;
            if(readerID != null)
            {
                this.readerID = readerID;
                checkoutToReader.Visible = true;
            }
            
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

        /// <summary>
        /// Wypożycza książkę wybranemu wcześniej 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkoutToReader_Click(object sender, EventArgs e)
        {
            using(new AppWaitCursor(ParentForm, e))
            {
                using(var db = new BibliotekaDB())
                {
                    var allCopiesQuery = db.Egzemplarz.Where(copy => copy.KsiążkaID == book.KsiążkaID);

                    List<Egzemplarz> availableCopies = new List<Egzemplarz>();
                    foreach(var copy in allCopiesQuery.ToList())
                    {
                        if(copy.Available)
                        {
                            availableCopies.Add(copy);
                        }
                    }

                    var reservationsCount = db.Rezerwacje.Where(res => res.KsiążkaID == book.KsiążkaID).Count();
                    if(!availableCopies.Any())
                    {
                        MessageBox.Show("Brak wolnych egzemplarzy tej książki!",
                                        "Błąd",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                    else if(reservationsCount >= availableCopies.Count)
                    {
                        MessageBox.Show("Książka jest zarezerwowana! Wszystkie egzemplarze są wypożyczone, bądź zarezerwowane!",
                                        "Błąd",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var reader = db.Czytelnik.Find(readerID);
                        db.Wypożyczenie.Add(new Wypożyczenie
                        {
                            Czytelnik = reader,
                            CzytelnikID = reader.CzytelnikID,
                            Data_wypożyczenia = DateTime.Now,
                            Data_zwrotu = null,
                            Egzemplarz = availableCopies.ElementAt(0)
                        });
                        db.SaveChanges();
                        MessageBox.Show("Pomyślnie wypożyczono!",
                                        "Błąd",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }
    }
}
