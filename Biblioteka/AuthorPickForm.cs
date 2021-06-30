using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Formularz rozszerzający zarządzanie autorami o możliwość wyboru jednego z nich.
    /// </summary>
    public partial class AuthorPickForm : Biblioteka.AuthorManagementForm
    {
        /// <summary>
        /// Wybrany autor.
        /// </summary>
        public Autor author;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public AuthorPickForm() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obsługa wybrania zaznaczonego autora.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void pickButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                author = GetSelectedAuthor();
                if (author != null)
                {
                    this.Return();
                }
            }
        }
    }
}
