using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class BookAddForm : Biblioteka.BookModificationForm
    {
        public BookAddForm() : base()
        {
            InitializeComponent();
        }

        protected override bool Accept(BibliotekaDB db)
        {
            long id;
            if(!long.TryParse(firstCopyInventoryText.Text, out id))
            {
                MessageBox.Show($"Wprowadzony numer unwenatarza jest niepoprawny.",
                    "Niepoprawny numer",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var _copy = db.Egzemplarz.FirstOrDefault(copy => copy.Nr_inwentarza == id);
            if (_copy != null)
            {
                MessageBox.Show($"Wprowadzony numer inwenatarza jest już używany przez: " +
                    $" \"{_copy.Książka.Tytuł}\" (ISBN:{_copy.Książka.ISBN.Trim()}).", 
                    "Używany numer inwentarza",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            managedBook.Egzemplarz.Add(new Egzemplarz { Nr_inwentarza = id });
            return base.Accept(db);
        }
    }
}
