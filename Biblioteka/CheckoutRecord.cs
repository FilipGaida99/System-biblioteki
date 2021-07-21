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
    /// ontrolka użytkownika wyświetlająca informacje o rezerwacji
    /// </summary>
    public partial class CheckoutRecord : UserControl
    {
        /// <summary>
        /// Prezentowana rezerwacja
        /// </summary>
        Rezerwacje reservation;
        public CheckoutRecord(Rezerwacje _reservation)
        {
            InitializeComponent();
            reservation = _reservation;
        }
    }
}
