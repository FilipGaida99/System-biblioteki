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
    public partial class ReservationForm : Form
    {
        /// <summary>
        /// Rezerwowana książka
        /// </summary>
        Książka book;
        /// <summary>
        /// Rezerwacja
        /// </summary>
        Rezerwacje reservation;
        /// <summary>
        /// Aktualna data
        /// </summary>
        System.DateTime currentDate = System.DateTime.Now;


        public ReservationForm(Książka _book)
        {
            InitializeComponent();
            book = _book;
            authorsLabel.Text = "";
            dateLabel.Text = $"{System.DateTime.Now:D}";
            bookNameLabel.Text = book.Tytuł;
            using (var db = new BibliotekaDB())
            {
                book = db.Książka.Find(book.KsiążkaID);
                foreach (var i in book.Autor)
                {
                    authorsLabel.Text += i.Imię +" "+ i.Nazwisko + " ";
                }
                publisherLabel.Text = book.Wydawnictwo.Nazwa;
            }

            
            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using(var db = new BibliotekaDB())
            {
                try
                {
                    reservation = new Rezerwacje();
                    reservation.Książka = book;
                    reservation.KsiążkaID = book.KsiążkaID;
                    reservation.Data_rezerwacji = currentDate;
                    // TO DO: Uzupełnić po zrobieniu użytkowników bo inaczej nie będzie dodawać
                    // TO DO: reservation.CzytelnikID = ;
                    // TO DO: reservation.Czytelnik = ;
                    db.Rezerwacje.Add(reservation);
                    db.SaveChanges();
                }
                catch(System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    MessageBox.Show("Nie udało się dodać rezerwacji!\n Użytkownik niezalogowany!",
                        "Nie zalogowany",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}
