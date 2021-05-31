using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGuest
{
    public partial class UserDetails : System.Web.UI.UserControl
    {
        const string lendRecordControlPath = "~/LendRecord.ascx";
        const string reservationRecordControlPath = "~/ReservationRecord.ascx";

        public long ReaderID;

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
                    AddLend(lend.WypożyczenieID);
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