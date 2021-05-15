using System.Linq;

namespace Biblioteka
{
    public partial class Egzemplarz
    {
        public Wypożyczenie LastLend => Wypożyczenie.FirstOrDefault(lend => lend.Data_wypożyczenia == Wypożyczenie.Max(x => x.Data_wypożyczenia));

        public bool Available => Wypożyczenie.Count == 0 || Wypożyczenie.All(lend => lend.Ended);
    }

}