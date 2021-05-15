using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Formularz modyfikacji egzemplarza.
    /// </summary>
    public partial class CopyModificationForm : Form
    {
        /// <summary>
        /// Modyfikowany egzemplarz.
        /// </summary>
        Egzemplarz managedCopy;
        /// <summary>
        /// Książka, do której jest przypisany egzemplarz.
        /// </summary>
        Książka bookCopy;

        /// <summary>
        /// Konstruktor dla nowych egzemplarzy.
        /// </summary>
        /// <param name="book">Książka, do której jest przypisany egzemplarz.</param>
        public CopyModificationForm(Książka book): this(null, book)
        {
        }

        /// <summary>
        /// Konstruktor dla istniejących egzemplarzy.
        /// </summary>
        /// <param name="copy">Egzemplarz</param>
        /// <param name="book">Książka, do której jest przypisany egzemplarz.</param>
        public CopyModificationForm(Egzemplarz copy, Książka book)
        {
            InitializeComponent();
            managedCopy = copy;
            bookCopy = book;
        }

        /// <summary>
        /// Funkcja wprowadzająca dane z formularza do modelu.
        /// </summary>
        /// <param name="db">Kontekst bazy danych.</param>
        /// <param name="errorText">Opis powstałego błędu, jeśli zwrócono false.</param>
        /// <returns>True, gdy udało się wprowadzić wszystkie dane.</returns>
        protected virtual bool Accept(BibliotekaDB db, out string errorText)
        {
            if (managedCopy != null)
            {
                managedCopy = db.Egzemplarz.Find(managedCopy.Nr_inwentarza);
            }

            bool isNew = false;
            if(managedCopy == null)
            {
                managedCopy = new Egzemplarz();
                isNew = true;

                long newInventory = (long)copyInventoryNumber.Value;
                var _copy = db.Egzemplarz.FirstOrDefault(copy => copy.Nr_inwentarza == newInventory);
                if (_copy != null && _copy.Nr_inwentarza != managedCopy.Nr_inwentarza)
                {
                    errorText = "Wprowadzony numer inwenatarza jest już używany przez: " +
                    $" \"{_copy.Książka.Tytuł}\" (ISBN:{_copy.Książka.ISBN.Trim()}).";
                    return false;
                }

                managedCopy.Nr_inwentarza = newInventory;
            }



            if (isElectronicCheckBox.Checked)
            {
                var electrioncCopy = managedCopy.Egzemplarz_elektroniczny;
                if(electrioncCopy == null)
                {
                    electrioncCopy = new Egzemplarz_elektroniczny();
                    electrioncCopy.Egzemplarz = managedCopy;
                    electrioncCopy = db.Egzemplarz_elektroniczny.Add(electrioncCopy);
                    managedCopy.Egzemplarz_elektroniczny = electrioncCopy;
                }
                electrioncCopy.Odnośnik = linkText.Text;
            }
            else if(managedCopy.Egzemplarz_elektroniczny != null)
            {
                db.Egzemplarz_elektroniczny.Remove(managedCopy.Egzemplarz_elektroniczny);
            }

            if (isNew)
            {
                managedCopy = db.Egzemplarz.Add(managedCopy);
                managedCopy.Książka = db.Książka.Find(bookCopy.KsiążkaID);
            }
            else
            {
                db.Entry(managedCopy).State = EntityState.Modified;
            }
            errorText = "";
            return true;
        }

        /// <summary>
        /// Obsługa zmiany aktywności pola wyboru egzemplarza elektronicznego.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void isElectronicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            linkText.Enabled = isElectronicCheckBox.Checked;
        }

        /// <summary>
        /// Obsługa akceptacji podanych argumentów.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void acceptButton_Click(object sender, EventArgs e)
        {
            using(new AppWaitCursor(this, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    try
                    {
                        string errorText;
                        if (Accept(db, out errorText))
                        {
                            db.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show(errorText,
                            "Błąd w formularzu",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message,
                            "Wyjątek",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                this.Return();
            }
        }

        /// <summary>
        /// Anulowanie zmian.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Return(DialogResult.Cancel);
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void CopyModificationForm_Load(object sender, EventArgs e)
        {
            if(managedCopy != null)
            {
                using(var db = new BibliotekaDB())
                {
                    Text = "Modyfikowanie egzemplarza";
                    managedCopy = db.Egzemplarz.Find(managedCopy.Nr_inwentarza);
                    copyInventoryNumber.Value = managedCopy.Nr_inwentarza;
                    copyInventoryNumber.Enabled = false;

                    var electrioncCopy = managedCopy.Egzemplarz_elektroniczny;
                    if(electrioncCopy != null)
                    {
                        isElectronicCheckBox.Checked = true;
                        if (managedCopy.Wypożyczenie.Count != 0)
                        {
                            isElectronicCheckBox.Enabled = false;
                        }
                        linkText.Text = electrioncCopy.Odnośnik;
                    }
                }
            }
            else
            {
                Text = "Dodawanie egzemplarza";
            }
           
        }
    }
}
