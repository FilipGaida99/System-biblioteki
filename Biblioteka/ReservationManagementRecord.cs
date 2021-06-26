﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class ReservationManagementRecord : Biblioteka.ReservationRecord
    {
        public ReservationManagementRecord(Rezerwacje _reservation, Action _onClick, List<Rezerwacje> _reservations) 
            : base(_reservation, _onClick, _reservations)
        {
            InitializeComponent();
        }

        private void checkoutFromReservation_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(ParentForm, e))
            {
                using (var db = new BibliotekaDB())
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
                        if (copy.Available)
                        {
                            copiesNotInUse.Add(copy);
                        }
                    }
                    if (!copiesNotInUse.Any())
                    {
                        MessageBox.Show("Ta książka nie ma już wolnych egzemplarzy!\nWszystie są wypożyczone!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (copiesNotInUse.Count > resCount)
                    {

                        //TO DO: Uzupełnić po zalogowaniu
                        db.Wypożyczenie.Add(new Wypożyczenie
                        {
                            Data_wypożyczenia = DateTime.Now,
                            Data_zwrotu = null,
                            Egzemplarz = copiesNotInUse.ElementAt(0),
                            Nr_inwentarza = copiesNotInUse.ElementAt(0).Nr_inwentarza,
                            Czytelnik = user,
                            CzytelnikID = user.CzytelnikID
                        });
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
    }
}