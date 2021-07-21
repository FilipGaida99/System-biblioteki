using System;
using System.Linq;
using System.Web.UI.WebControls;
using BibliotekaModel;

namespace WebGuest
{
    /// <summary>
    /// Kontrolka grupująca informacje o książce.
    /// </summary>
    public partial class BookRecord : System.Web.UI.UserControl
    {
        /// <summary>
        /// Identyfikator książki zawierającej wyświetlane informacje.
        /// </summary>
        public long managedBookID;

        /// <summary>
        /// Procedura ładowania kontrolki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                Książka managedBook = db.Książka.Find(managedBookID);
                Title.Text = managedBook.Tytuł;
                ISBN.Text = managedBook.ISBN;
                Year.Text = managedBook.Rok_wydania.Year.ToString();
                Publisher.Text = managedBook.Wydawnictwo.Nazwa;
                var authorsList = managedBook.Autor.ToList();
                Authors.Text = authorsList[0].Imię + " " + authorsList[0].Nazwisko;
                for (int i = 1; i < authorsList.Count; i++)
                {
                    Authors.Text += ", ";
                    Authors.Text += authorsList[i].Imię + " " + authorsList[i].Nazwisko;
                }
            }
            ShowLink.NavigateUrl = $"~/BookDetails.aspx?id={managedBookID}";
        }
    }
}