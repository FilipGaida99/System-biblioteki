using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGuest
{
    /// <summary>
    /// Kontrolka wywołująca powrót do strony głównej.
    /// </summary>
    public partial class HomeButton : System.Web.UI.UserControl
    {
        /// <summary>
        /// Procedura ładowania kontrolki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Obsługa naciśnięcia przycisku kontrolki. Powrót do strony głównej (...default).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default");
        }
    }
}