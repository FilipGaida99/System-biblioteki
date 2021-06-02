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
        System.Windows.Forms.Button deleteButton;
        public CustomMessageButton(Action<object, EventArgs> deleteButton_click, Wiadomość msg)
        {
            this.Width = 507;
            this.Height = 47;
            System.Windows.Forms.Padding temp = new System.Windows.Forms.Padding();
            temp.All = 0;
            this.Margin = temp;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Text = msg.Tytuł;

            dateLabel = new System.Windows.Forms.Label();
            dateLabel.Location = new System.Drawing.Point(this.Width - 94, this.Height - 17);
            dateLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            dateLabel.BackColor = System.Drawing.Color.Transparent;
            dateLabel.Width = 90;
            dateLabel.Height = 13;
            dateLabel.Click += (sender, args) => InvokeOnClick(this, args);
            dateLabel.Text = msg.Data_wysłania.ToString();
            this.Controls.Add(dateLabel);

            deleteButton = new System.Windows.Forms.Button();
            deleteButton.Location = new System.Drawing.Point(this.Width - 23, 2);
            deleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            deleteButton.Width = 21;
            deleteButton.Height = 21;
            deleteButton.Click += (sender, args) => deleteButton_click(sender, args);
            deleteButton.Text = "🗑";
            this.Controls.Add(deleteButton);
        }
    }
}
