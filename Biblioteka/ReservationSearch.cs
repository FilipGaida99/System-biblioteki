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

        /// <summary>
        /// Metdoa wywoływana po wciśnięciu przycisku szukającego. Wyszukuje w bazie rezerwacje o danych 
        /// zawartych w polach tesktowych
        /// </summary>
        /// <param name="sender"></param> Kontrolka
        /// <param name="e"></param> Argumenty
        private void button1_Click(object sender, EventArgs e)
        {
            using(var db = new BibliotekaDB())
            {
                using(new AppWaitCursor(ParentForm, sender))
                {
                    try
                    {
                        var query = db.Rezerwacje.AsNoTracking().Where(reservation => reservation.Książka.Tytuł.Contains(bookTitleBox.Text));
                        query = query.Where(reservation => reservation.Czytelnik.Nazwisko.Contains(surnameBox.Text));
                        query = query.Where(reservation => reservation.Czytelnik.Imię.Contains(nameBox.Text));
                        if (readerIdBox.Text != "")
                        {
                            long id = IDConverter.IdToLong(readerIdBox.Text);
                            query = query.Where(reservation => reservation.CzytelnikID == id);
                        }


                        if (dateTimePicker1.Checked)
                            query = query.Where(reservation => reservation.Data_rezerwacji > dateTimePicker1.Value);
                        if (dateTimePicker2.Checked)
                            query = query.Where(reservation => reservation.Data_rezerwacji < dateTimePicker2.Value);

                        query = query.OrderBy(reservation => reservation.Data_rezerwacji);

                        reservations = query.ToList();
                        if (onSearch != null)
                            onSearch.Invoke();
                    }
                    catch(ArgumentException)
                    {
                        MessageBox.Show("Id nie może zawierać niczego innego niż cyfry!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }
    }
}
