using System.Linq;

namespace BibliotekaModel
{
    /// <summary>
    /// Encja egzemplarza.
    /// </summary>
    public partial class Egzemplarz
    {
        /// <summary>
        /// Znajdywanie pierwszego nie używanego numeru egzemplarza
        /// </summary>
        /// <param name="db">Kontekst bazy danych.</param>
        /// <returns>Nieużywany numer egzemplarza.</returns>
        public static long FindFirstUnused(BibliotekaDB db)
        {
            for (long key = 0; key < long.MaxValue; key++)
            {
                if (db.Egzemplarz.Find(key) == null)
                {
                    return key;
                }
            }
            return 0;
        }

        /// <summary>
        /// Ostatnie wypożyczenie egzemplarza.
        /// </summary>
        public Wypożyczenie LastLend => Wypożyczenie.FirstOrDefault(lend => lend.Data_wypożyczenia == Wypożyczenie.Max(x => x.Data_wypożyczenia));

        /// <summary>
        /// Sprawdzenie czy jest możliwa do wypożyczenia.
        /// </summary>
        public bool Available => Wypożyczenie.Count == 0 || Wypożyczenie.All(lend => lend.Ended);
    }

}