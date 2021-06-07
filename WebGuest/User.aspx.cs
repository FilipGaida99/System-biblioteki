using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGuest
{
    /// <summary>
    /// Strona z informacjami o użytkowniku po wprowadzeniu jego numeru.
    /// </summary>
    public partial class User : System.Web.UI.Page
    {
        /// <summary>
        /// Ścieżka do kontrolki z informacjami o użytkowniku.
        /// </summary>
        const string userDetailsControlPath = "~/UserDetails.ascx";

        /// <summary>
        /// Procedura ładowania strony.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Obsługa naciśnięcia przycisku wprowadzenia numeru użytkownika.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            long readerID;
            if(long.TryParse(IDTextBox.Text, out readerID))
            {
                var details = (UserDetails)Page.LoadControl(userDetailsControlPath);
                details.ReaderID = readerID;
                Controls.Add(details);
            }
            else
            {
                Controls.Add(new Label { Text = "Niepoprawny numer użytkownika", ForeColor = Color.Red });
            }
        }
    }
}