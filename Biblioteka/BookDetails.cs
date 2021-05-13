using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class BookDetails : Form
    {
        Książka book;
        public BookDetails(Książka presentedBook)
        {
            InitializeComponent();
            book = presentedBook;
        }

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

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl.SelectedTab == availabilityPage)
            {
                UpdateAvailabilityTab();
            }
            if (tabControl.SelectedTab == copyPage)
            {
                UpdateCopyTab();
            }
        }

        private void refreshAvailabilityButton_Click(object sender, EventArgs e)
        {
            UpdateAvailabilityTab();
        }

        private void refreshCopyButton_Click(object sender, EventArgs e)
        {
            UpdateCopyTab();
        }

        private void UpdateAvailabilityTab()
        {
            using(var db = new BibliotekaDB())
            {
                book = db.Książka.Find(book.KsiążkaID);
                var bookings = book.Rezerwacje.OrderBy(booking => booking.Data_rezerwacji).ToList();
                bool availableCopy = book.Egzemplarz.Any(copy => copy.Wypożyczenie.Count == 0 || copy.Wypożyczenie.All(lend => lend.Data_zwrotu != null));
                availabilityLabel.Text = "";
                if(bookings.Count == 0 && availableCopy)
                {
                    availabilityLabel.Text = "Dostępna od ręki";
                }
                else if (bookings.Count > 0)
                {
                    availabilityLabel.Text = $"Zarezerwowana. Ostatnia rezerwacja: {bookings[bookings.Count - 1].Data_rezerwacji}";
                }
                else if(bookings.Count == 0 && !availableCopy)
                {
                    availabilityLabel.Text = "Brak dostępnych kopii. Brak rezerwacji";
                }
            }

        }

        private void UpdateCopyTab()
        {
            using (var db = new BibliotekaDB())
            {
                book = db.Książka.Find(book.KsiążkaID);
                copyList.BeginUpdate();
                copyList.Items.Clear();
                foreach(var copy in book.Egzemplarz)
                {
                    string[] row = { copy.Nr_inwentarza.ToString(), "Dostępny" };
                    var lastLend = copy.Wypożyczenie.FirstOrDefault(lend => lend.Data_wypożyczenia == copy.Wypożyczenie.Max(x => x.Data_wypożyczenia));
                    if (lastLend != null && lastLend.Data_zwrotu == null)
                    {
                        //Todo: do funkcji wypożyczenia.
                        var endDate = lastLend.Data_wypożyczenia.Value.AddDays(copy.Książka.Maksymalny_okres_wypożyczenia);
                        row[1] = $"Wypożyczony (do {endDate.ToShortDateString()})";
                    }
                    copyList.Items.Add(new ListViewItem(row));
                }
                copyList.EndUpdate();
            }
        }
    }
}
