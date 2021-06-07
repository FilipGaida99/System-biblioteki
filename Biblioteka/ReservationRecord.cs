﻿using System;
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
    public partial class ReservationRecord : UserControl
    {
        /// <summary>
        /// Lista wyszukanych rezerwacji
        /// </summary>
        public static List<Rezerwacje> reservations;

        /// <summary>
        /// Obiekt przechowujący informacje o rezerwacji prezentowanej na kontrolce
        /// </summary>
        private Rezerwacje reservation;

        /// <summary>
        /// Metoda wywoływana, po wypożyczeniu i usunięciu rezerwacji
        /// </summary>
        public Action onClick;


        /// <summary>
        /// Konstruktor jednoargumentowy 
        /// </summary>
        /// <param name="_reservation"></param>
        public ReservationRecord(Rezerwacje _reservation, Action _onClick, List<Rezerwacje> _reservations)
        {
            InitializeComponent();
            reservation = _reservation;

            reservations = _reservations;
            //jesli zalogowany użytkownik
            //if()
            // widocznośc buttonów + podpięcie odpowiedniego przycisku
            onClick = _onClick;

        }

        private void ReservationRecord_Load(object sender, EventArgs e)
        {
            bookTitle.Text = reservation.Książka.Tytuł;
            var bookAuthors = reservation.Książka.Autor;
            authors.Text = $"{bookAuthors.ElementAt(0).Imię} {bookAuthors.ElementAt(0).Nazwisko}";
            for (int i = 1; i <bookAuthors.Count; i++ )
            {
                authors.Text += $", {bookAuthors.ElementAt(i).Imię} {bookAuthors.ElementAt(i).Nazwisko}";
            }
            
            readerId.Text = reservation.Czytelnik.CzytelnikID.ToString();
            readerName.Text = reservation.Czytelnik.Imię;
            readerSurname.Text = reservation.Czytelnik.Nazwisko;
            reservationDate.Text = $"{reservation.Data_rezerwacji:g}";
            //TO DO:
            // jesli zalogowany użytkownik to zablokuj przycisk wypożycz, odblokuj usuń rezerwację
            // jeśli zalogowany bibliotekarz to odwrotnie
            checkoutButton.Visible = true;
            deleteButton.Visible = true;
            

        }

        private void button_Click(object sender, EventArgs e)
        {
            using(new AppWaitCursor(ParentForm, e))
            {
                using(var db = new BibliotekaDB())
                {
                    //TO DO: Po zalogowaniu usunąć i wpisać zalogowanego użytkownika
                    var user = db.Czytelnik.Find(10003);

                    //sprawdź czy nie ma rezerwacji tej książki na wcześniejszy termin // sprawdzenie ile egzemplarzy wolnych poinno być więc wcześniej, żeby mieć ich liczbę
                    var resQuery = db.Rezerwacje.AsNoTracking().Where(res => res.KsiążkaID == reservation.KsiążkaID).OrderBy(res => res.Data_rezerwacji);
                    //ile książek jest w lisćie rezerwacji przed tą rezerwacją
                    int resCount = resQuery.Where(res => res.Data_rezerwacji < reservation.Data_rezerwacji).Count();

                    //znajdź wszystie egzemplarze (fizyczne) tej książki
                    var book = db.Książka.Find(reservation.KsiążkaID);
                    var query = db.Egzemplarz.Where(copy => copy.KsiążkaID == book.KsiążkaID);
                    query = query.Where(copy => copy.Egzemplarz_elektroniczny == null);
                    query = query.OrderBy(copy => copy.Nr_inwentarza);
                    

                    List<Egzemplarz> copies = query.ToList();

                    //sprawdź który/które egzemplarz nie jest wypożyczony
                    List<Egzemplarz> copiesNotInUse = new List<Egzemplarz>();
                    foreach (var copy in copies)
                    {
                        if(copy.Available)
                        {
                            copiesNotInUse.Add(copy);
                        }
                    }
                    if(!copiesNotInUse.Any())
                    {
                        MessageBox.Show("Ta książka nie ma już wolnych egzemplarzy!\nWszystie są wypożyczone!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if(copiesNotInUse.Count > resCount)
                    {

                        //TO DO: Uzupełnić po zalogowaniu
                        db.Wypożyczenie.Add(new Wypożyczenie { Data_wypożyczenia = DateTime.Now, Data_zwrotu = null,
                                                                Egzemplarz = copiesNotInUse.ElementAt(0), Nr_inwentarza = copiesNotInUse.ElementAt(0).Nr_inwentarza,
                                                                Czytelnik = user, CzytelnikID = user.CzytelnikID });
                        var toCheckout = db.Rezerwacje.Where(res => res.CzytelnikID == reservation.CzytelnikID);
                        toCheckout = toCheckout.Where(res => res.KsiążkaID == reservation.KsiążkaID);
                    
                        var resToDelete = toCheckout.First();
                        db.Rezerwacje.Remove(resToDelete);
                        reservations.Remove(reservation);
                        db.SaveChanges();

                        onClick.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Błąd", "Ta książka została zarezerwowana wcześniej przez kogoś innego!\n Brak wolnych egzemplarzy!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                
                
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
            using(new AppWaitCursor(ParentForm, e))
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
