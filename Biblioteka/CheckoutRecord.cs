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

        private void CheckoutRecord_Load(object sender, EventArgs e)
        {

        }
    }
}
