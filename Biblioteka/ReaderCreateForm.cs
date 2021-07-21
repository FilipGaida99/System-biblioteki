using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotekaModel;

namespace Biblioteka
{
    /// <summary>
    /// Formularz tworzenia użytkownika.
    /// </summary>
    public partial class ReaderCreateForm : Form
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ReaderCreateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Zamknięcie okna.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Obsługa utworzenia użytkownika.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
