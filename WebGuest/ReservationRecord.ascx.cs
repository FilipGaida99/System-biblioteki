using Biblioteka;
using System;
using System.Drawing;
using System.Linq;

namespace WebGuest
{
    /// <summary>
    /// Kontrolka z informacjami o rezerwacji.
    /// </summary>
    public partial class ReservationRecord : System.Web.UI.UserControl
    {
        /// <summary>
        /// Identyfikator czytelnika.
        /// </summary>
        public long ReaderId;
        /// <summary>
        /// Identyfikator książki.
        /// </summary>
        public long BookId;

        /// <summary>
        /// Procedura ładowania strony.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                Rezerwacje reservation = db.Rezerwacje.Find(ReaderId, BookId);
                if (reservation == null)
                {
                    BookLink.ForeColor = Color.Red;
                    BookLink.Text = "Błąd odczytu. Spróbuj ponownie.";
                    return;
                }

                BookLink.Text = reservation.Książka.Tytuł;
                BookLink.NavigateUrl = $"~/BookDetails.aspx?id={reservation.Książka.KsiążkaID}";

                ReservationDate.Text = reservation.Data_rezerwacji.ToShortDateString();
                var book = db.Książka.Find(reservation.KsiążkaID);
                var bookings = book.Rezerwacje.OrderBy(booking => booking.Data_rezerwacji).ToList();

                Queue.Text = $"{bookings.Count}";
                QueuePosition.Text = $"{bookings.IndexOf(reservation) + 1}";
            }
        }
    }
}