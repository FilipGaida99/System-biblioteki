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

            Wydawnictwo = db.Wydawnictwo.Where(wyd => wyd.Nazwa == publisher).FirstOrDefault();
            if (Wydawnictwo == null)
            {
                Wydawnictwo = db.Wydawnictwo.Add(new Wydawnictwo { Nazwa = publisher });
            }
            WydawnictwoID = Wydawnictwo.WydawnictwoID;

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

    }

}
