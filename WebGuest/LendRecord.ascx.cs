using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Biblioteka;

namespace WebGuest
{
    public partial class LendRecord : System.Web.UI.UserControl
    {
        public long LendId;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                Wypożyczenie lend = db.Wypożyczenie.Find(LendId);
                if(lend == null)
                {
                    LendNumber.ForeColor = Color.Red;
                    LendNumber.Text = "Błąd odczytu. Spróbuj ponownie.";
                    return;
                }

                LendNumber.Text = lend.WypożyczenieID.ToString();
                Egzemplarz copy = lend.Egzemplarz;
                CopyNumber.Text = copy.Nr_inwentarza.ToString();
                BookLink.Text = copy.Książka.Tytuł;
                BookLink.NavigateUrl = $"~/BookDetails.aspx?id={copy.Książka.KsiążkaID}";

                LendDate.Text = lend.Data_wypożyczenia.Value.ToShortDateString();
                ExpectedReturnDate.Text = lend.Przewidywany_zwrot.ToShortDateString();
                ReturnDate.Text = lend.Data_zwrotu.HasValue ? lend.Data_zwrotu.Value.ToShortDateString() : "Aktywne wypożyczenie";
                if (lend.Kara.Any())
                {
                    Penalties.Text = "";
                }
                foreach(var penalty in lend.Kara)
                {
                    Penalties.Text += $"<br />Nałożono: {penalty.Data_nałożenia} " +
                        $"Zdjęto: {(penalty.Data_amnestii.HasValue ? penalty.Data_amnestii.Value.ToShortDateString(): "Aktwyna kara")}";
                }
            }
        }
    }
}