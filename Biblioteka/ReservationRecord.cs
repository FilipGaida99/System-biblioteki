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
    /// Kontorlka użytkownika wyświetlająca rezerwacje
    /// </summary>
    public partial class ReservationRecord : UserControl
    {
        /// <summary>
        /// Lista wyszukanych rezerwacji
        /// </summary>
        protected static List<Rezerwacje> reservations;

        /// <summary>
        /// Obiekt przechowujący informacje o rezerwacji prezentowanej na kontrolce
        /// </summary>
        protected Rezerwacje reservation;

        /// <summary>
        /// Metoda wywoływana, po wypożyczeniu i usunięciu rezerwacji
        /// </summary>
        public Action onClick;

        /// <summary>
        /// Konstruktor trojargumentowy 
        /// </summary>
        /// <param name="_reservation"></param>
        /// <param name="_onClick"></param> Metoda wywoływana po usunięciu rezerwacji
        /// <param name="_reservations"></param> Lista rezerwacji
        public ReservationRecord(Rezerwacje _reservation, Action _onClick, List<Rezerwacje> _reservations)
        {
            InitializeComponent();
            reservation = _reservation;
            reservations = _reservations;
            onClick = _onClick;
        }

        /// <summary>
        /// Metoda wywoływana w tracie ładowania kontrolki
        /// </summary>
        /// <param name="sender"></param> Kontrolka
        /// <param name="e"></param> Argumenty
        private void ReservationRecord_Load(object sender, EventArgs e)
        {
            if(reservation != null)
            {
                bookTitle.Text = reservation.Książka.Tytuł;
                var bookAuthors = reservation.Książka.Autor;
                authors.Text = $"{bookAuthors.ElementAt(0).Imię} {bookAuthors.ElementAt(0).Nazwisko}";
                for (int i = 1; i < bookAuthors.Count; i++)
                {
                    authors.Text += $", {bookAuthors.ElementAt(i).Imię} {bookAuthors.ElementAt(i).Nazwisko}";
                }

                readerId.Text = reservation.Czytelnik.CzytelnikID.ToString();
                readerName.Text = reservation.Czytelnik.Imię;
                readerSurname.Text = reservation.Czytelnik.Nazwisko;
                reservationDate.Text = $"{reservation.Data_rezerwacji:g}";
                using(var db = new BibliotekaDB())
                {
                    var book = db.Książka.Find(reservation.KsiążkaID);
                    var bookings = book.Rezerwacje.OrderBy(booking => booking.Data_rezerwacji).ToList();
                    var user = UserSingleton.Instance.GetLoggedUser() as Czytelnik;
                    if (user != null)
                        user = db.Czytelnik.Find(user.CzytelnikID);

                    reservation = db.Rezerwacje.Where(reservation => reservation.KsiążkaID == book.KsiążkaID 
                                                        && reservation.CzytelnikID == user.CzytelnikID)
                                                        .FirstOrDefault();
                    numberInQueue.Text = $"Rezerwacja jest {bookings.IndexOf(reservation) + 1} w kolejce.";
                }                
            }
        }

        /// <summary>
        /// Metoda przycisku do usuwania rezerwacji
        /// </summary>
        /// <param name="sender"></param> Kontrolka WinForms
        /// <param name="e"></param> Argumenty
        private void deleteButton_Click(object sender, EventArgs e)
        {
            using(new AppWaitCursor(ParentForm, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    var query = db.Rezerwacje.Where(res => res.CzytelnikID == reservation.CzytelnikID);
                    query = query.Where(res => res.KsiążkaID == reservation.KsiążkaID);
                    var toDelete = query.ToList();
                    if (toDelete.Count == 1)
                    {
                        db.Rezerwacje.Remove(toDelete.ElementAt(0));
                        db.SaveChanges();
                        reservations.Remove(reservation);
                        onClick.Invoke();
                    }
                }
            }
        }
    }
}
