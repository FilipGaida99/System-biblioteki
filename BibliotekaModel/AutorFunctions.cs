using System.Linq;

namespace Biblioteka
{
    public partial class Autor
    {
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