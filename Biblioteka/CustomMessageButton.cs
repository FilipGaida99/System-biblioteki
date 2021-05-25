using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class CustomMessageButton : System.Windows.Forms.Button
    {
        //TO DO: customowy label co świeci buttonem, któy jest za labelem
        System.Windows.Forms.Label dateLabel;
        public CustomMessageButton()
        {
            this.Width = 520;
            this.Height = 47;
            dateLabel = new System.Windows.Forms.Label();
            dateLabel.Location = new System.Drawing.Point(426, 30);
            dateLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            dateLabel.BackColor = System.Drawing.Color.Transparent;
            dateLabel.Width = 90;
            dateLabel.Height = 13;
            dateLabel.Click += (sender, args) => InvokeOnClick(this, args);
            dateLabel.Text = "Data wiadomości";
            this.Controls.Add(dateLabel);
        }
    }
}
