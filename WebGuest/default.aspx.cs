using System;

namespace WebGuest
{
    /// <summary>
    /// Strona domyślna.
    /// </summary>
    public partial class _default : System.Web.UI.Page
    {
        /// <summary>
        /// Procedura ładowania strony.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Obsługa przejścia do strony wyszukiwania.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BrowseButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Browse.aspx");
        }

        /// <summary>
        /// Obsługa przejścia do strony z informacjami o wypożyczeniach.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UserButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User.aspx");
        }
    }
}