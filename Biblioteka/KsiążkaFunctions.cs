using System.Collections.Generic;
using System.Linq;

namespace Biblioteka
{
    public partial class Książka
    {
        public bool SetPublisher(BibliotekaDB db, string publisher)
        {
            if (publisher.Trim() == "")
            {
                return false;
            }

            var newPublisher = db.Wydawnictwo.Where(wyd => wyd.Nazwa == publisher).FirstOrDefault();
            if (newPublisher == null)
            {
                newPublisher = db.Wydawnictwo.Add(new Wydawnictwo { Nazwa = publisher });
            }

            Wydawnictwo = newPublisher;

            return true;
        }

        public bool SetAuthors(BibliotekaDB db, List<Autor> authors)
        {
            if (authors.Count <= 0)
            {
                return false;
            }

            Autor.Clear();
            foreach (var author in authors)
            {
                Autor authorToAdd = db.Autor.Where(author.MatchNameWith).FirstOrDefault();
                if (authorToAdd == null)
                {
                    authorToAdd = db.Autor.Add(author);
                }
                Autor.Add(authorToAdd);
            }

            return true;
        }

        public bool AvailableCopy => Egzemplarz.Any(copy => copy.Wypożyczenie.Count == 0 || copy.Wypożyczenie.All(lend => lend.Data_zwrotu != null));
        public bool AvailableElectronicCopy => Egzemplarz.Any(copy => copy.Egzemplarz_elektroniczny != null);

    }

}
