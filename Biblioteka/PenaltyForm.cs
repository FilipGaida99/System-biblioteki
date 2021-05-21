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
    /// Formularz zdejmowania kar.
    /// </summary>
    public partial class PenaltyForm : Form
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="user">ID użytkownika którego dotyczy okno.</param>
        public PenaltyForm(int user)
        {
            InitializeComponent();
            Text = "Kary użytkownika ID:"+user.ToString();
        }

        /// <summary>
        /// Obsługa zdejmowania kar.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
