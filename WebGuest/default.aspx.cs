using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}