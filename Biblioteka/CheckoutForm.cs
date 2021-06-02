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
    public partial class CheckoutForm : Form
    {

        public CheckoutForm()
        {
            InitializeComponent();
            readerSearch.onSearch = OnChangedReadersPanel;
            
            reservationSearch1.onSearch = OnChangedReservationPanel;
            tabControl1.TabPages[0].Text = "Ręczne wypożyczanie";
            tabControl1.TabPages[1].Text = "Rezerwacje";
            
        }

        /// <summary>
        /// Metoda wywoływana po wyszukaniu użytkowników
        /// </summary>
        public void OnChangedReadersPanel()
        {
            
             readersLayoutPanel.Controls.Clear();
             foreach (var reader in readerSearch.readers)
             {
                 readersLayoutPanel.Controls.Add(new ReaderRecord(reader));
             }

        }

        /// <summary>
        /// Metoda wywoływana po wyszuaniu rezerwacji
        /// </summary>
        public void OnChangedReservationPanel()
        {
            reservationsLayoutPanel.Controls.Clear();
            foreach(var reservation in reservationSearch1.reservations)
            {
                reservationsLayoutPanel.Controls.Add(new ReservationRecord(reservation, OnChangedReservationPanel, reservationSearch1.reservations));
            }
        }



    }
}
