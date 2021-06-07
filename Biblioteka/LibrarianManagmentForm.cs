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
    /// Formularz zarządzania bibliotekarzami.
    /// </summary>
    public partial class LibrarianManagmentForm : Form
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public LibrarianManagmentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dodawania użytkownika w nowym oknie.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void addUser_Click(object sender, EventArgs e)
        {
            LibrarianCreateForm librarian = new LibrarianCreateForm();
            librarian.Show();
        }
    }
}
