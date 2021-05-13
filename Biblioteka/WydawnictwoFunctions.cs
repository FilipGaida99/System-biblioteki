using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka
{
    public partial class Wydawnictwo
    {
        public static void DeleteEmpty(BibliotekaDB db)
        {
            db.Wydawnictwo.RemoveRange(db.Wydawnictwo.Where(publisher => publisher.Książka.Count == 0));
        }
    }

}