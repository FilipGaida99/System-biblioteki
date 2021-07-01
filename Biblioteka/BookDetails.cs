using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Formularz z szczegółowymi informacjami o książce.
    /// </summary>
    public partial class BookDetails : Form
    {
        /// <summary>
        /// Znak oznaczający rosnącą kolejność sortowania.
        /// </summary>
        const string ascArrow = " ▲";
        /// <summary>
        /// nak oznaczający malejącą kolejność sortowania.
        /// </summary>
        const string descArrow = " ▼";
        /// <summary>
        /// Książka dostarczająca informacje.
        /// </summary>
        Książka book;
        /// <summary>
        /// Obiekt sortujący kolumny ListView.
        /// </summary>
        ListViewColumnSorter lvwColumnSorter;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="presentedBook">Książka dostarczająca informacje.</param>
        public BookDetails(Książka presentedBook)
        {
            InitializeComponent();
            book = presentedBook;
            lvwColumnSorter = new ListViewColumnSorter(2);
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = SortOrder.Ascending;
            copyList.ListViewItemSorter = lvwColumnSorter;
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void BookDetails_Load(object sender, EventArgs e)
        {
            Text = book.Tytuł;
            titleLabel.Text = book.Tytuł;
            isbnLabel.Text = book.ISBN;
            maxDaysLabel.Text = book.Maksymalny_okres_wypożyczenia.ToString();
            dateLabel.Text = book.Rok_wydania.ToShortDateString();
            publisherLabel.Text = book.Wydawnictwo.Nazwa;
            var authors = book.Autor.OrderBy(_author => _author.Nazwisko).ToList();

            authorsLabel.Text = $"{authors[0].Imię} {authors[0].Nazwisko}";
            for (int i = 1; i < authors.Count; i++)
            {
                authorsLabel.Text += $",{authors[i].Imię} {authors[i].Nazwisko}";
            }

            descriptionText.Text = book.Opis;
        }

        /// <summary>
        /// Obsługa zmiany wybranej karty.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this))
            {
                if (tabControl.SelectedTab == availabilityPage)
                {
                    UpdateAvailabilityTab();
                }
                if (tabControl.SelectedTab == copyPage)
                {
                    UpdateCopyTab();
                }
            }
        }

        /// <summary>
        /// Obsługa odświeżenia w karcie "Dostępność".
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void refreshAvailabilityButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                UpdateAvailabilityTab();
            }
        }

        /// <summary>
        /// Obsługa odświeżenia w karcie "Egzemplarze".
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void refreshCopyButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                UpdateCopyTab();
            }
        }

        /// <summary>
        /// Aktualizacja zawartości karty "Dostępność".
        /// </summary>
        private void UpdateAvailabilityTab()
        {
            using(var db = new BibliotekaDB())
            {
                //TO DO: Sprawdź czy użytkownik zalogowany!
                book = db.Książka.Find(book.KsiążkaID);
                var bookings = book.Rezerwacje.OrderBy(booking => booking.Data_rezerwacji).ToList();
                bool availableCopy = book.AvailableCopy;
                
                availabilityLabel.Text = "";
                //bookingButton.Enabled = false;
                if(!book.Egzemplarz.Any())
                {
                    bookingButton.Enabled = false;
                    availabilityLabel.Text = "Przepraszamy, książka nie posiada obecnie żadnego egzemplarza :(";
                }
                else if(bookings.Count == 0 && availableCopy)
                {
                    //bookingButton.Enabled = false;
                    availabilityLabel.Text = "Dostępna od ręki";

                }
                else if (bookings.Count > 0)
                {
                    availabilityLabel.Text = $"Zarezerwowana. Ostatnia rezerwacja: {bookings[bookings.Count - 1].Data_rezerwacji}, Liczba rezerwacji: {bookings.Count}";
                    //bookingButton.Enabled = true;
                }
                else if(bookings.Count == 0 && !availableCopy)
                {
                    availabilityLabel.Text = "Brak dostępnych kopii. Brak rezerwacji";
                    //bookingButton.Enabled = true;
                }

                if (book.AvailableElectronicCopy)
                {
                    electronicCopyGroup.Visible = true;
                }
            }

        }

        /// <summary>
        /// Aktualizacja zawartości karty "Egzemplarze".
        /// </summary>
        private void UpdateCopyTab()
        {
            const int numberColumnIndex = 0;
            const int availabilityColumnIndex = 2;

            using (var db = new BibliotekaDB())
            {
                book = db.Książka.Find(book.KsiążkaID);
                copyList.BeginUpdate();
                copyList.Items.Clear();
                foreach(var copy in book.Egzemplarz)
                {
                    string[] row = { copy.Nr_inwentarza.ToString(), copy.Rok_wydruku.ToString("yyyy.MM.dd"), "Dostępny" };

                    bool isElecrtionic = copy.Egzemplarz_elektroniczny != null;
                    if (isElecrtionic)
                    {
                        row[numberColumnIndex] += " (E)";
                        row[availabilityColumnIndex] = "Elektroniczny";
                    }
                    else
                    {
                        var lastLend = copy.LastLend;
                        if (lastLend != null && lastLend.Data_zwrotu == null)
                        {
                            var endDate = lastLend.Przewidywany_zwrot;
                            row[availabilityColumnIndex] = $"Wypożyczony (do {endDate.ToShortDateString()})";
                        }
                    }

                    copyList.Items.Add(new ListViewItem(row));
                }
                SetSortIndicator();
                copyList.Sort();
                copyList.EndUpdate();
            }
        }

        /// <summary>
        /// Obsługa naciśnięcia kolumny w ListView
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void copyList_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {

                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            SetSortIndicator();

            copyList.Sort();
        }

        /// <summary>
        /// Ustawienie znaku oznaczającego kolejność sortowania.
        /// </summary>
        private void SetSortIndicator()
        {
            // Usunięcie strzałki.
            foreach(ColumnHeader column in copyList.Columns)
            {
                DeleteArrow(column);
            }

            // Dodanie strzałki.
            switch (lvwColumnSorter.Order)
            {
                case SortOrder.Ascending: 
                    copyList.Columns[lvwColumnSorter.SortColumn].Text += ascArrow; 
                    break;
                case SortOrder.Descending: 
                    copyList.Columns[lvwColumnSorter.SortColumn].Text += descArrow; 
                    break;
            }
        }

        /// <summary>
        /// Usunięcie znaku oznaczającego kolejność sortowania.
        /// </summary>
        /// <param name="header">Wybrana kolumna.</param>
        private void DeleteArrow(ColumnHeader header)
        {
            if (header.Text.EndsWith(ascArrow) || header.Text.EndsWith(descArrow))
            {
                header.Text = header.Text.Substring(0, header.Text.Length - 2);
            }
                
        }

        /// <summary>
        /// Metoda otwiera formualrz z informacją o rezerwacji
        /// </summary>
        /// <param name="sender"></param> Kontrolka
        /// <param name="e"></param> Argumenty
        private void bookingButton_Click(object sender, EventArgs e)
        {
            var reservationForm = new ReservationForm(book);
            reservationForm.Show();
        }

        /// <summary>
        /// Wypozycza użytkownikowi egzemplarz elektroniczny książki
        /// </summary>
        /// <param name="sender"></param> Kontrolka
        /// <param name="e"></param> Argumenty
        private void lendBookButton_Click(object sender, EventArgs e)
        {

            using(var db = new BibliotekaDB())
            {
                var user = UserSingleton.Instance.GetLoggedUser() as Czytelnik;
                user = db.Czytelnik.Find(user.CzytelnikID);

                var query = db.Egzemplarz.Where(copy => copy.KsiążkaID == book.KsiążkaID);
                query = query.Where(copy => copy.Egzemplarz_elektroniczny != null);
                var electronicCopy = query.FirstOrDefault();
                var electronicCopyNumber = electronicCopy.Nr_inwentarza;

                var usersLendQuery = db.Wypożyczenie.Where(lend => lend.Egzemplarz.Egzemplarz_elektroniczny != null 
                                                                    && lend.CzytelnikID == user.CzytelnikID 
                                                                    && lend.Egzemplarz.KsiążkaID == electronicCopy.KsiążkaID);
             
                if(usersLendQuery.Count() >= 1)
                {
                    MessageBox.Show("Masz już aktualnie wypożyczony egzemplarz elektroniczny tej książki. Sprawdź wypożyczenia.",
                        "Uwaga",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                db.Wypożyczenie.Add(new Wypożyczenie
                {
                    Czytelnik = user,
                    CzytelnikID = user.CzytelnikID,
                    Data_wypożyczenia = DateTime.Now,
                    Egzemplarz = electronicCopy,
                    Data_zwrotu = null,
                    Nr_inwentarza = electronicCopy.Nr_inwentarza
                });
                db.SaveChanges();

                MessageBox.Show("Książka została wypożyczona, sprawdź swoje wypożyczenia.",
                      "Sukces",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                
            }
        }

        
    }
}
