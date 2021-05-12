using System.Collections.Generic;
using System.Linq;

namespace Biblioteka
{
    public partial class Autor
    {
       
        public bool MatchNameWith(Autor author)
        {
            return Imię == author.Imię && Nazwisko == author.Nazwisko;
        }
    }

}