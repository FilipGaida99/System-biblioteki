using System;
using System.Linq;

namespace Biblioteka
{
    public partial class Kara
    {
        /// <summary>
        /// Odświeżenie kar za przetrzymanie książek.
        /// </summary>
        /// <param name="db">Kontekst bazy danych.</param>
        public static void Refresh(BibliotekaDB db)
        {
            var now = DateTime.Now;
            foreach(var reader in db.Czytelnik)
            {
                string penalties = "";
                foreach(var lend in reader.Wypożyczenie)
                {
                    if(!lend.Ended && lend.Przewidywany_zwrot < now && !lend.Kara.All(p => p.Data_amnestii.HasValue))
                    {
                        lend.Kara.Add(new Kara { Data_nałożenia = now });
                        penalties += $"•Książka {lend.Egzemplarz.Książka.Tytuł}\n";
                    }
                }

                if (penalties.Length > 0)
                {
                    Wiadomość.SystemNotification("Nałożono karę", 
                        "Nałożono kary na następujące wypożyczenia:\n" + penalties + "Skontaktuj się z biblioteką w celu zlikiwidowania należności.", 
                        reader);
                }
            }
            db.SaveChanges();
        }

    }

}