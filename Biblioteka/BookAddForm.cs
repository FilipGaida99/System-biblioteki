using System.Linq;

namespace Biblioteka
{
    public partial class BookAddForm : Biblioteka.BookModificationForm
    {
        public BookAddForm() : base()
        {
            InitializeComponent();
        }

        protected override bool Accept(BibliotekaDB db, out string errorText)
        {
            long id = (long)firstCopyInventoryNumber.Value;
            var _copy = db.Egzemplarz.FirstOrDefault(copy => copy.Nr_inwentarza == id);
            if (_copy != null)
            {
                errorText = "Wprowadzony numer inwenatarza jest już używany przez: " +
                    $" \"{_copy.Książka.Tytuł}\" (ISBN:{_copy.Książka.ISBN.Trim()}).";
                return false;
            }
            managedBook.Egzemplarz.Add(new Egzemplarz { Nr_inwentarza = id });

            return base.Accept(db, out errorText);
        }
    }
}
