using System;

namespace Biblioteka
{
    public partial class Wypożyczenie
    {
        public DateTime Przewidywany_zwrot => Data_wypożyczenia.Value.AddDays(Egzemplarz.Książka.Maksymalny_okres_wypożyczenia);

        public bool Ended => Data_zwrotu != null;
    }
}