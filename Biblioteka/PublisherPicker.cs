using System;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Kontrolka wyboru wydawcy.
    /// </summary>
    public partial class PublisherPicker : UserControl
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public PublisherPicker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nazwa wydawcy w polu tekstowym.
        /// </summary>
        public string PublisherName
        {
            get => publisherText.Text;
            set => publisherText.Text = value;
        }

        /// <summary>
        /// Obsługa wyboru wydawcy.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void choosePublisherButton_Click(object sender, EventArgs e)
        {
            using(new AppWaitCursor(ParentForm, sender))
            {
                PublisherForm form = new PublisherForm();
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    publisherText.Text = form.choosedPublisherName;
                }
            }
        }
    }
}
