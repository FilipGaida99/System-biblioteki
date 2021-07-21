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
    /// Formularz z informacją o planowanej rezerwacji
    /// </summary>
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

        /// <summary>
        /// Konstruktor jednoargumentowy
        /// </summary>
        /// <param name="_book"></param> Obiekt z informacją o książce
        public ReservationForm(Książka _book)
        {
            InitializeComponent();
            book = _book;
            authorsLabel.Text = "";
            dateLabel.Text = $"{System.DateTime.Now:D}";
            bookNameLabel.Text = book.Tytuł;
            using(new AppWaitCursor(ParentForm, null))
            {
                using (var db = new BibliotekaDB())
                {
                    book = db.Książka.Find(book.KsiążkaID);
                    foreach (var i in book.Autor)
                    {
                        authorsLabel.Text += i.Imię + " " + i.Nazwisko + " ";
                    }
                    publisherLabel.Text = book.Wydawnictwo.Nazwa;
                }
            }
          
        }
        /// <summary>
        /// Metoda wywoływana po linięciu przycisku z potwierdzeniem rezerwacji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            using(var db = new BibliotekaDB())
            {
                using (new AppWaitCursor(this, sender))
                {
                    try
                    {
                        book = db.Książka.Find(book.KsiążkaID);
                        reservation = new Rezerwacje();
                        reservation.Książka = book;
                        reservation.KsiążkaID = book.KsiążkaID;
                        reservation.Data_rezerwacji = currentDate;
                        
                        var user = UserSingleton.Instance.GetLoggedUser() as Czytelnik;
                        user = db.Czytelnik.Find(user.CzytelnikID);

                        reservation.CzytelnikID = user.CzytelnikID;
                        reservation.Czytelnik = user;
                        db.Rezerwacje.Add(reservation);
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException exception)
                    {
                        switch (exception.HResult)
                        {
                            case -2146233087:
                                MessageBox.Show("Nie udało się dodać rezerwacji!\n Masz już zarezerwowaną tę książkę!",
                                                "Błąd rezerwacji",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                                break;
                        }
                    }
                    finally
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
