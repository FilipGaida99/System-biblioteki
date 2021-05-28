using System.Linq;

namespace Biblioteka
{
    public partial class Egzemplarz
    {
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