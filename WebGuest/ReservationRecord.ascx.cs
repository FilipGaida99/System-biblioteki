using Biblioteka;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGuest
{
    public partial class ReservationRecord : System.Web.UI.UserControl
    {
        public long ReaderId;
        public long BookId;

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
            }
        }
    }
}