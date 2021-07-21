using System;
using System.Drawing;
using System.Linq;
using BibliotekaModel;

namespace WebGuest
{
    /// <summary>
    /// Kontrolka z informacjami o wypożyczeniu.
    /// </summary>
    public partial class LendRecord : System.Web.UI.UserControl
    {
        /// <summary>
        /// Identyfikator wypożyczenia.
        /// </summary>
        public long LendId;

        /// <summary>
        /// Procedura ładowania strony.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    bool isActive = !penalty.Data_amnestii.HasValue;
                    Penalties.Text += $"<br />•Nałożono: {penalty.Data_nałożenia.ToShortDateString()} " +
                        $"Zdjęto: {(isActive ? "Aktwyna kara" : penalty.Data_amnestii.Value.ToShortDateString())}";
                    if (isActive)
                    {
                        LendNumber.ForeColor = Color.Red;
                    }
                }
            }
        }
    }
}