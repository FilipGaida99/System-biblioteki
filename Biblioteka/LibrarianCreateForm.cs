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
    /// <summary>
    /// Formularz dodawania bibliotekarzy.
    /// </summary>
    public partial class LibrarianCreateForm : Form
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public LibrarianCreateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Zamknięcie okna.
        /// </summary>
        /// /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Obsługa utowrzenia użytkownika.
        /// </summary>
        /// /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
