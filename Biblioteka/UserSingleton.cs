using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class UserSingleton
    {
        private static readonly UserSingleton instance = new UserSingleton();
        private static object user = null;

        static UserSingleton()
        {
        }

        private UserSingleton()
        {
        }

        public static UserSingleton Instance
        {
            get
            {
                return instance;
            }
        }


        public void SetLibrarian(Bibliotekarz librarian)
        {
            user = librarian;
        }

        public void SetReader(Czytelnik reader)
        {
            user = reader;
        }

        public object GetLoggedUser()
        {
            return user;
        }

        public void Logout()
        {
            user = null;
        }

        [Obsolete]
        public void CreateLibrarianUnsafeMethodDeleteLater()
        {
            using (var db = new BibliotekaDB())
            {
                var librarian = db.Bibliotekarz.Find(2137);
                if (librarian == null)
                {
                    librarian = new Bibliotekarz() { BibliotekarzID = 2137, Imię = "Librarian", Nazwisko = "B", Adres_email = "C", Numer_telefonu = 2137 };
                    db.Bibliotekarz.Add(librarian);
                    db.SaveChanges();
                }

                SetLibrarian(librarian);
            }
        }

        [Obsolete]
        public void CreateReaderUnsafeMethodDeleteLater()
        {
            using (var db = new BibliotekaDB())
            {
                var reader = db.Czytelnik.Find(2137);
                if (reader == null)
                {
                    reader = new Czytelnik() { CzytelnikID = 2137, Imię = "Reader", Nazwisko = "Y", Adres_email = "X", Numer_telefonu = 420 };
                    db.Czytelnik.Add(reader);
                    db.SaveChanges();
                }

                SetReader(reader);
            }
        }

        [Obsolete]
        public void CreateNotLoggedUnsafeMethodDeleteLater()
        {
            Logout();
        }
    }
}
