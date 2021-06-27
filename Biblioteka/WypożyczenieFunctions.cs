using System;

namespace Biblioteka
{
    public partial class Wypożyczenie
    {
        /// <summary>
        /// Data przewidywanego zwrotu.
        /// </summary>
        public DateTime Przewidywany_zwrot => Data_wypożyczenia.Value.AddDays(Egzemplarz.Książka.Maksymalny_okres_wypożyczenia);

        /// <summary>
        /// Informacja, czy wypożyczenie zostało zakończone.
        /// </summary>
        public bool Ended => Data_zwrotu != null;

        /// <summary>
        /// Informacja czy wypożyczenie dotyczy egzemplarza elektronicznego
        /// </summary>
        public bool LendedElectronicCopy => Egzemplarz.Egzemplarz_elektroniczny != null;
    }
}