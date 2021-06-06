using System.Linq;

namespace Biblioteka
{
    /// <summary>
    /// Formularz dodawania książki. Dodaje kontrolkę z pierwszym numerem inwentarza.
    /// </summary>
    public partial class BookAddForm : Biblioteka.BookModificationForm
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public BookAddForm() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funkcja wprowadzająca dane z formularza do modelu.
        /// </summary>
        /// <param name="db">Kontekst bazy danych.</param>
        /// <param name="errorText">Opis powstałego błędu, jeśli zwrócono false.</param>
        /// <returns>True, gdy udało się wprowadzić wszystkie dane.</returns>
        protected override bool Accept(BibliotekaDB db, out string errorText)
        {
            if (base.Accept(db, out errorText))
            {
                long id = (long)firstCopyInventoryNumber.Value;

                //Sprawdzenie czy numer inwentarza jest unikalny.
                var _copy = db.Egzemplarz.FirstOrDefault(copy => copy.Nr_inwentarza == id);
                if (_copy != null)
                {
                    errorText = "Wprowadzony numer inwenatarza jest już używany przez: " +
                        $" \"{_copy.Książka.Tytuł}\" (ISBN:{_copy.Książka.ISBN.Trim()}).";
                    return false;
                }

                managedBook.Egzemplarz.Add(new Egzemplarz { Nr_inwentarza = id, Rok_wydruku = managedBook.Rok_wydania });

                return true;
            }
            return false;
        }

        /// <summary>
        /// Obsługa generowania numeru inwentarza z pierwszej niewystępującej wartości klucza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void identityInventoryButton_Click(object sender, System.EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    long key = 0;
                    for (key = 0; key < long.MaxValue; key++)
                    {
                        if (db.Egzemplarz.Find(key) == null)
                        {
                            break;
                        }
                    }
                    firstCopyInventoryNumber.Value = key;
                }
            }

        }
    }
}
