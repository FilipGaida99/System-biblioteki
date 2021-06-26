using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka
{
    public partial class Wiadomość
    {
        /// <summary>
        /// Wiadomość od systemu do czytelnika.
        /// </summary>
        /// <param name="title">Tytuł wiadomości.</param>
        /// <param name="content">Treść wiadomości.</param>
        /// <param name="addresseeID">ID czytelnika.</param>
        public static void SystemNotification(string title, string content, long addresseeID)
        {
            Wiadomość msg = new Wiadomość { Treść = content, Tytuł = title, Data_wysłania = DateTime.Now };
            using (var db = new BibliotekaDB())
            {
                db.Wiadomość.Add(msg);
                Bibliotekarz librarian = db.Bibliotekarz
                                        .Where(lib => lib.Imię == Bibliotekarz.specialLibrarianName)
                                        .First();
                db.Czytelnik_Wiadomość.Add(new Czytelnik_Wiadomość { CzytelnikID = addresseeID, Nadawca = false, Wiadomość = msg });
                db.Bibliotekarz_Wiadomość.Add(new Bibliotekarz_Wiadomość { BibliotekarzID = librarian.BibliotekarzID, Nadawca = true, Wiadomość = msg });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Wiadomość od systemu do czytelnika.
        /// </summary>
        /// <param name="title">Tytuł wiadomości.</param>
        /// <param name="content">Treść wiadomości.</param>
        /// <param name="addressee">Czytelnik.</param>
        public static void SystemNotification(string title, string content, Czytelnik addressee)
        {
            Wiadomość msg = new Wiadomość { Treść = content, Tytuł = title, Data_wysłania = DateTime.Now };
            using (var db = new BibliotekaDB())
            {
                db.Wiadomość.Add(msg);
                Bibliotekarz librarian = db.Bibliotekarz
                                        .Where(lib => lib.Imię == Bibliotekarz.specialLibrarianName)
                                        .First();
                db.Czytelnik_Wiadomość.Add(new Czytelnik_Wiadomość { CzytelnikID = addressee.CzytelnikID, Nadawca = false, Wiadomość = msg });
                db.Bibliotekarz_Wiadomość.Add(new Bibliotekarz_Wiadomość { BibliotekarzID = librarian.BibliotekarzID, Nadawca = true, Wiadomość = msg });
            }
        }
    }
}