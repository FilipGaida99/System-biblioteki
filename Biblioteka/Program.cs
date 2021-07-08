using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var db = new BibliotekaDB())
                if (db.Database.CreateIfNotExists()) {
                    db.Czytelnik.Add(new Czytelnik
                    {
                        Imię = "Leonardo",
                        Nazwisko = "Da Vinky",
                        Numer_telefonu = 111111111,
                        Adres_email = "leonardo.vinky@gmail.com",
                        Data_utworzenia = DateTime.Now
                    });
                    db.SaveChanges();
                }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainDashboard());
        }
    }
}
