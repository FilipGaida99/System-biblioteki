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
    /// Formularz zarządzania czytelnikami.
    /// </summary>
    public partial class ReadersManagmentForm : Form
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ReadersManagmentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dodawania nowego użytkownika w nowym oknie.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void addUser_Click(object sender, EventArgs e)
        {
            ReaderCreateForm userCreateForm = new ReaderCreateForm();
            userCreateForm.Show();
        }

        /// <summary>
        /// Zarządzanie karami w nowym oknie.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void penaltyButton_Click(object sender, EventArgs e)
        {
            PenaltyForm penaltyForm = new PenaltyForm(int.Parse(labelID.Text));
            penaltyForm.Show();
        }
    }
}
