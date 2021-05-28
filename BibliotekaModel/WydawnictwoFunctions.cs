using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka
{
    public partial class Wydawnictwo
    {
        /// <summary>
        /// Usunięcie wydawnictw bez przypisanej książki.
        /// </summary>
        /// <param name="db">Kontekst bazy danych.</param>
        public static void DeleteEmpty(BibliotekaDB db)
        {
            db.Wydawnictwo.RemoveRange(db.Wydawnictwo.Where(publisher => publisher.Książka.Count == 0));
        }
    }

}