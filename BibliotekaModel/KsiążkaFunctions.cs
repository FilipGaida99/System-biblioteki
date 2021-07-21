using System.Collections.Generic;
using System.Linq;

namespace BibliotekaModel
{
    /// <summary>
    /// Encja książki.
    /// </summary>
    public partial class Książka
    {
        /// <summary>
        /// Ustawienie wydawcy na podstawie nazwy.
        /// </summary>
        /// <param name="db">Kontekst bazy danych.</param>
        /// <param name="publisher">Nazwa wydawcy.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Ustawienie autorów na podstawie listy.
        /// </summary>
        /// <param name="db">Kontekst bazy danych.</param>
        /// <param name="authors">Lista autorów.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Sprawdzenie, czy jest dostępna kopia.
        /// </summary>
        public bool AvailableCopy => Egzemplarz.Any(copy => copy.Available);

        /// <summary>
        /// Sprawdzenie, czy jest dostępna wersja elektroniczna.
        /// </summary>
        public bool AvailableElectronicCopy => Egzemplarz.Any(copy => copy.Egzemplarz_elektroniczny != null);

        /// <summary>
        /// Sprawdzenie, czy wszystkie kopie znajdują się w bibliotece.
        /// </summary>
        public bool AllCopiesInLibrary => Egzemplarz.All(copy => copy.Available);
    }

}
