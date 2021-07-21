using System;
using System.Linq;
using System.Web.UI.WebControls;
using BibliotekaModel;

namespace WebGuest
{
    /// <summary>
    /// Strona z opisanymi szczegółami książki.
    /// </summary>
    public partial class BookDetails : System.Web.UI.Page
    {
        /// <summary>
        /// Identyfikator książki zawierającej wyświetlane informacje.
        /// </summary>
        long bookID;

        /// <summary>
        /// Procedura ładowania strony.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                bookID = long.Parse(Request.QueryString["id"]);
                LoadBook();
            }
        }

        /// <summary>
        /// Procedura ładowania książki do kontrolek znajdzujących się na stronie.
        /// </summary>
        private void LoadBook()
        {
            using (var db = new BibliotekaDB())
            {
                Książka managedBook = db.Książka.Find(bookID);
                if (managedBook == null)
                {
                    return;
                }

                SetBasicInformation(managedBook);
                SetAvailabilityInformation(managedBook);
                SetCopyInformation(managedBook);

            }
        }

        /// <summary>
        /// Ustawianie podstawowych informacji o książce, takich jak tytuł, isbn, data wydania, itd.
        /// </summary>
        /// <param name="managedBook">Książka zawierająca wyświetlane informacje</param>
        private void SetBasicInformation(Książka managedBook)
        {
            Title.Text = managedBook.Tytuł;
            ISBN.Text = managedBook.ISBN;
            Date.Text = managedBook.Rok_wydania.ToShortDateString();
            Publisher.Text = managedBook.Wydawnictwo.Nazwa;
            var authorsList = managedBook.Autor.ToList();
            Authors.Text = authorsList[0].Imię + " " + authorsList[0].Nazwisko;
            for (int i = 1; i < authorsList.Count; i++)
            {
                Authors.Text += ", ";
                Authors.Text += authorsList[i].Imię + " " + authorsList[i].Nazwisko;
            }
            MaxDays.Text = $"Maksymalny okres wypożyczenia: {managedBook.Maksymalny_okres_wypożyczenia} dni";
            Description.Text = managedBook.Opis.Replace("\r\n", "<br/>");
        }

        /// <summary>
        /// Ustawianie informacji o dostępności książki.
        /// </summary>
        /// <param name="managedBook">Książka zawierająca wyświetlane informacje</param>
        private void SetAvailabilityInformation(Książka managedBook)
        {
            using (var db = new BibliotekaDB())
            {
                var book = db.Książka.Find(managedBook.KsiążkaID);
                var bookings = managedBook.Rezerwacje.OrderBy(booking => booking.Data_rezerwacji).ToList();
                bool availableCopy = managedBook.AvailableCopy;
                var physicalCopy = db.Egzemplarz.Where(copy => copy.Egzemplarz_elektroniczny == null && copy.KsiążkaID == book.KsiążkaID);

                Availability.Text = "";
                if (!book.Egzemplarz.Any() || !physicalCopy.Any())
                {
                    Availability.Text = "Przepraszamy, książka nie posiada obecnie żadnego kartkowego egzemplarza :(";
                    Availability.Visible = false;
                }
                else if (bookings.Count == 0 && availableCopy)
                {
                    Availability.Text = "Dostępna od ręki";
                }
                else if (bookings.Count > 0)
                {
                    Availability.Text = $"Zarezerwowana. Ostatnia rezerwacja: {bookings[bookings.Count - 1].Data_rezerwacji}, Liczba rezerwacji: {bookings.Count}";
                }
                else if (bookings.Count == 0 && !availableCopy)
                {
                    Availability.Text = "Brak dostępnych kopii. Brak rezerwacji";
                }

                if (managedBook.AvailableElectronicCopy)
                {
                    Availability.Visible = true;
                }
            }
        }

        /// <summary>
        /// Ustawianie informacji o egzemplarzach książki.
        /// </summary>
        /// <param name="managedBook">Książka zawierająca wyświetlane informacje</param>
        private void SetCopyInformation(Książka managedBook)
        {
            const int numberColumnIndex = 0;
            const int dateColumnIndex = 1;
            const int availabilityColumnIndex = 2;
            int columnCount = CopyTable.Rows[0].Cells.Count;

            foreach (var copy in managedBook.Egzemplarz)
            {
                TableRow row = new TableRow();

                for(int i = 0; i < columnCount; i++)
                {
                    row.Cells.Add(new TableCell());
                    row.Cells[i].Style.Add("text-align", "center");
                    row.Cells[i].Style.Add("font-size", "25px");
                }
                row.Cells[numberColumnIndex].Text = copy.Nr_inwentarza.ToString();
                row.Cells[dateColumnIndex].Text = copy.Rok_wydruku.ToString("yyyy.MM.dd");
                row.Cells[availabilityColumnIndex].Text = "Dostępny";

                bool isElecrtionic = copy.Egzemplarz_elektroniczny != null;
                if (isElecrtionic)
                {
                    row.Cells[numberColumnIndex].Text += " (E)";
                    row.Cells[availabilityColumnIndex].Text = "Elektroniczny";
                }
                else
                {
                    var lastLend = copy.LastLend;
                    if (lastLend != null && lastLend.Data_zwrotu == null)
                    {
                        var endDate = lastLend.Przewidywany_zwrot;
                        row.Cells[availabilityColumnIndex].Text = $"Wypożyczony (do {endDate.ToShortDateString()})";
                    }
                }

                CopyTable.Rows.Add(row);
            }
        }
    }
}
