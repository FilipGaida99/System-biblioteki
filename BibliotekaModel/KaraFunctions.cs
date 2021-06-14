using System;
using System.Linq;

namespace Biblioteka
{
    public partial class Kara
    {
        public static void Refresh(BibliotekaDB db)
        {
            var now = DateTime.Now;
            foreach(var reader in db.Czytelnik)
            {
                foreach(var lend in reader.Wypożyczenie)
                {
                    if(!lend.Ended && lend.Przewidywany_zwrot < now && !lend.Kara.All(p => p.Data_amnestii.HasValue))
                    {
                        lend.Kara.Add(new Kara { Data_nałożenia = now });
                        //TODO: powiadomienie.
                    }
                }
            }
            db.SaveChanges();
        }

    }

}