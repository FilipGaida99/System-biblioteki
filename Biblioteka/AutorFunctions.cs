using System.Linq;

namespace Biblioteka
{
    public partial class Autor
    {
        /// <summary>
        /// Usunięcie autorów bez przypisanej książki.
        /// </summary>
        /// <param name="db">Kontekst bazy danych.</param>
        public static void DeleteEmpty(BibliotekaDB db)
        {
            db.Autor.RemoveRange(db.Autor.Where(author => author.Książka.Count == 0));
        }

        /// <summary>
        /// Sprawdzenie czy autorzy nazywają się tak samo.
        /// </summary>
        /// <param name="author">Argument porównania.</param>
        /// <returns>True, gdy imię i nazwisko autora jest takie samo.</returns>
        public bool MatchNameWith(Autor author)
        {
            return Imię == author.Imię && Nazwisko == author.Nazwisko;
        }
    }

}