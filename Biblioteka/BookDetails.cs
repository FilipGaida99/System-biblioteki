using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class BookDetails : Form
    {
        Książka book;
        ListViewColumnSorter lvwColumnSorter;
        const string ascArrow = " ▲";
        const string descArrow = " ▼";


        public BookDetails(Książka presentedBook)
        {
            InitializeComponent();
            book = presentedBook;
            lvwColumnSorter = new ListViewColumnSorter(2);
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = SortOrder.Ascending;
            copyList.ListViewItemSorter = lvwColumnSorter;
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

        private void refreshAvailabilityButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                UpdateAvailabilityTab();
            }
        }

        private void refreshCopyButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                UpdateCopyTab();
            }
        }

        private void UpdateAvailabilityTab()
        {
            using(var db = new BibliotekaDB())
            {
                book = db.Książka.Find(book.KsiążkaID);
                var bookings = book.Rezerwacje.OrderBy(booking => booking.Data_rezerwacji).ToList();
                bool availableCopy = book.AvailableCopy;
                
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

                if (book.AvailableElectronicCopy)
                {
                    electronicCopyGroup.Visible = true;
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

                    bool isElecrtionic = copy.Egzemplarz_elektroniczny != null;
                    if (isElecrtionic)
                    {
                        row[0] += " (E)";
                        row[1] = "Elektroniczny";
                    }
                    else
                    {
                        var lastLend = copy.LastLend;
                        if (lastLend != null && lastLend.Data_zwrotu == null)
                        {
                            var endDate = lastLend.Przewidywany_zwrot;
                            row[1] = $"Wypożyczony (do {endDate.ToShortDateString()})";
                        }
                    }

                    copyList.Items.Add(new ListViewItem(row));
                }
                SetSortIndicator();
                copyList.Sort();
                copyList.EndUpdate();
            }
        }

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

        private void DeleteArrow(ColumnHeader header)
        {
            if (header.Text.EndsWith(ascArrow) || header.Text.EndsWith(descArrow))
            {
                header.Text = header.Text.Substring(0, header.Text.Length - 2);
            }
                
        }
    }
}
