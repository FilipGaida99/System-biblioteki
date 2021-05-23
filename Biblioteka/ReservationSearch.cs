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
    public partial class ReservationSearch : UserControl
    {
        /// <summary>
        /// Delegat wywoływany po wyszukaniu rezerwacji.
        /// </summary>
        public Action onSearch;

        /// <summary>
        /// Lista znalezionych rezerwacji
        /// </summary>
        public List<Rezerwacje> reservations;

        /// <summary>
        /// Konstrutor bezargumentowy kontrolki wyszukiwania rezerwacji
        /// </summary>
        public ReservationSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var db = new BibliotekaDB())
            {
                using(new AppWaitCursor(ParentForm, sender))
                {
                    var query = db.Rezerwacje.AsNoTracking().Where(reservation => reservation.Książka.Tytuł.Contains(bookTitleBox.Text));
                    query = db.Rezerwacje.Where(reservation => reservation.Czytelnik.Nazwisko.Contains(surnameBox.Text));
                    query = db.Rezerwacje.Where(reservation => reservation.Czytelnik.Imię.Contains(nameBox.Text));

                    if (dateTimePicker1.Checked)
                        query = db.Rezerwacje.Where(reservation => reservation.Data_rezerwacji > dateTimePicker1.Value);
                    if (dateTimePicker2.Checked)
                        query = db.Rezerwacje.Where(reservation => reservation.Data_rezerwacji < dateTimePicker2.Value);

                    reservations = query.ToList();
                    onSearch.Invoke();
                }

            }
        }
    }
}
