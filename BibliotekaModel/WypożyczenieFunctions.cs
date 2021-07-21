using System;
using System.Linq;

namespace BibliotekaModel
{
    /// <summary>
    /// Encja wypożyczenia.
    /// </summary>
    public partial class Wypożyczenie
    {
        /// <summary>
        /// Data przewidywanego zwrotu.
        /// </summary>
        public DateTime Przewidywany_zwrot { 
            get{
                var accepted = Prolongata.Where(p => p.Accepted);
                DateTime ? lastDate = accepted.Where(p => p.Data_prolongaty == accepted.Max(maxP => maxP.Data_prolongaty)).
                    Select(p => p.Data_prolongaty).
                    FirstOrDefault();

                if (lastDate.HasValue)
                {
                    return lastDate.Value.AddDays(Egzemplarz.Książka.Maksymalny_okres_wypożyczenia);
                }
                return Data_wypożyczenia.Value.AddDays(Egzemplarz.Książka.Maksymalny_okres_wypożyczenia);
            }
        }

        /// <summary>
        /// Informacja, czy wypożyczenie ma aktywną karę.
        /// </summary>
        /// <returns></returns>
        public bool HasActivePenalty() => Kara.Any(penalty => penalty.Data_amnestii == null);

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