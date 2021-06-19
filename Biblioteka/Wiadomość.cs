namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Spatial;

    public partial class Wiadomość
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wiadomość()
        {
            Bibliotekarz_Wiadomość = new HashSet<Bibliotekarz_Wiadomość>();
            Czytelnik_Wiadomość = new HashSet<Czytelnik_Wiadomość>();
        }

        public long WiadomośćID { get; set; }

        [Required]
        [StringLength(200)]
        public string Tytuł { get; set; }

        [Required]
        [StringLength(4000)]
        public string Treść { get; set; }


        [Column("Data wysłania")]
        public DateTime Data_wysłania { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bibliotekarz_Wiadomość> Bibliotekarz_Wiadomość { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Czytelnik_Wiadomość> Czytelnik_Wiadomość { get; set; }

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
    }
}
