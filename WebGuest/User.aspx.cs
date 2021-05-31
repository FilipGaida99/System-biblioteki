using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGuest
{
    public partial class User : System.Web.UI.Page
    {
        const string userDetailsControlPath = "~/UserDetails.ascx";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

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