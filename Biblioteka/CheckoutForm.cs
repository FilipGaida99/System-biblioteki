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
    /// Formularz umożliwiający wypożyczanie i zwracanie książek bibliotekarzowi oraz przeglądanie rezerwacji
    /// </summary>
    public partial class CheckoutForm : Form
    {

        /// <summary>
        /// Konstruktor formularza do przeglądania użytkowników i rezerwacji, wypożyczania i zwracania książek
        /// </summary>
        public CheckoutForm()
        {
            InitializeComponent();
            readerSearch.onSearch = OnChangedReadersPanel;
            reservationSearch1.onSearch = OnChangedReservationPanel;
            tabControl1.TabPages[0].Text = "Czytelnicy";
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
                reservationsLayoutPanel.Controls.Add(new ReservationManagementRecord(reservation, OnChangedReservationPanel, reservationSearch1.reservations));
            }
        }
    }
}
