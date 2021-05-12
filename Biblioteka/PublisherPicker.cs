using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class PublisherPicker : UserControl
    {
        public PublisherPicker()
        {
            InitializeComponent();
        }

        public string PublisherName
        {
            get => publisherText.Text;
            set => publisherText.Text = value;
        }

        private void choosePublisherButton_Click(object sender, EventArgs e)
        {
            PublisherForm form = new PublisherForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                publisherText.Text = form.choosedPublisherName;
            }
        }
    }
}
