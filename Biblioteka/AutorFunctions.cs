using System.Linq;

namespace Biblioteka
{
    public partial class Autor
    {
       
        public static void DeleteEmpty(BibliotekaDB db)
        {
            db.Autor.RemoveRange(db.Autor.Where(author => author.Książka.Count == 0));
        }

        public bool MatchNameWith(Autor author)
        {
            return Imię == author.Imię && Nazwisko == author.Nazwisko;
        }
    }

}