using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGuest
{
    public partial class DatePicker : System.Web.UI.UserControl
    {
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

        public bool Checked => CheckBox.Checked;

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
                    ErrorLabel.Text = "Niepoprawna data.";
                }
                return null;
            }
        }
    }
}