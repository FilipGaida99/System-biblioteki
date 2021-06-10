using System;
using System.Web.UI.WebControls;

namespace WebGuest
{
    /// <summary>
    /// Kontrolka pozwalająca na wybór daty.
    /// </summary>
    public partial class DatePicker : System.Web.UI.UserControl
    {
        /// <summary>
        /// Procedura ładowania kontrolki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Day.Text.Trim() == "")
            {
                DateTime now = DateTime.Now;
                Day.Text = now.Day.ToString();
                Month.Text = now.Month.ToString();
                Year.Text = now.Year.ToString();
            }
            ErrorLabel.Text = "";
        }

        /// <summary>
        /// Informacja, czy kontrolka jest zaznaczona.
        /// </summary>
        public bool Checked => CheckBox.Checked;

        /// <summary>
        /// Wartość wprowadzonej daty. W przypadku braku zaznaczenia zostanie ustawiona wartość null.
        /// W przypadku błędów wyświetlony zostanie odpowiedni tekst i wartość zostanie ustawiona na null.
        /// </summary>
        public DateTime? Date
        {
            get
            {
                try
                {
                    if (CheckBox.Checked)
                    {
                        return new DateTime(int.Parse(Year.Text), int.Parse(Month.Text), int.Parse(Day.Text));
                    }
                }
                catch(ArgumentOutOfRangeException)
                {
                    ErrorLabel.Text = "Niepoprawna data";
                }
                return null;
            }
        }
    }
}