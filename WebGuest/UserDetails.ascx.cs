using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotekaModel;

namespace WebGuest
{
    /// <summary>
    /// Kontrolka z informacjami o użytkowniku.
    /// </summary>
    public partial class UserDetails : System.Web.UI.UserControl
    {
        /// <summary>
        /// Ścieżka do kontrolki z informacjami o wypożyczeniu.
        /// </summary>
        const string lendRecordControlPath = "~/LendRecord.ascx";
        /// <summary>
        /// Ścieżka do kontrolki z informacjami o rezerwacji.
        /// </summary>
        const string reservationRecordControlPath = "~/ReservationRecord.ascx";

        /// <summary>
        /// Identyfikator użytkownika, którego infomracje będą wyświetlane.
        /// </summary>
        public long ReaderID;

        /// <summary>
        /// Procedura ładowania strony.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            using(var db = new BibliotekaDB())
            {
                Czytelnik reader = db.Czytelnik.Find(ReaderID);
                if(reader == null)
                {
                    Controls.Clear();
                    Controls.Add(new Label { Text = "Nie znaleziono użytkownika" });
                    return;
                }

                Forename.Text = reader.Imię;
                Surname.Text = reader.Nazwisko;

                foreach(Wypożyczenie lend in reader.Wypożyczenie)
                {
                    if (!lend.Ended || lend.HasActivePenalty())
                    {
                        AddLend(lend.WypożyczenieID);
                    }
                }

                foreach(Rezerwacje reservation in reader.Rezerwacje)
                {
                    AddReservation(reservation.CzytelnikID, reservation.KsiążkaID);
                }
            }
        }

        /// <summary>
        /// Dodawanie wypożyczenia do listy na stronie.
        /// </summary>
        /// <param name="lendId">Identyfikator wypożyczenia zawierającego wyświetlane informacje.</param>
        private void AddLend(long lendId)
        {
            var rec = (LendRecord)Page.LoadControl(lendRecordControlPath);
            rec.ID = $"Lend{lendId}";
            rec.LendId = lendId;
            LendsPanel.Controls.Add(rec);
        }

        /// <summary>
        /// Dodawanie rezerwacji do listy na stronie.
        /// </summary>
        /// <param name="readerId">Identyfikator czytelnika.</param>
        /// <param name="bookID">Identyfikator książki.</param>
        private void AddReservation(long readerId, long bookID)
        {
            var rec = (ReservationRecord)Page.LoadControl(reservationRecordControlPath);
            rec.ID = $"Lend{bookID}";
            rec.ReaderId = readerId;
            rec.BookId = bookID;
            ReservationsPanel.Controls.Add(rec);
        }
    }


}