using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Form tworzenia i modyfikowania wystawy.
    /// </summary>
    public partial class ExhibitionAddForm : Form
    {
        /// <summary>
        /// Aktualnie przetwarzana wystawa.
        /// </summary>
        private Wystawa managedExhibition;

        public Wystawa Wystawa
        {
            get { return managedExhibition; }
        }

        /// <summary>
        /// Konstruktor domyślny.
        /// </summary>
        public ExhibitionAddForm(): this(null)
        {
        }

        /// <summary>
        /// Konstruktor dla modyfikowanych wystaw.
        /// </summary>
        /// <param name="exhibition"></param>
        public ExhibitionAddForm(Wystawa exhibition)
        {
            InitializeComponent();
            managedExhibition = exhibition;
        }

        /// <summary>
        /// Funkcja wprowadzająca dane z formularza do modelu.
        /// </summary>
        /// <param name="db">Kontekst bazy danych.</param>
        /// <returns>True, gdy udało się wprowadzić wszystkie dane.</returns>
        private bool confirm(BibliotekaDB db)
        {
            string trimmedName = nameText.Text.Trim();
            if (trimmedName == "")
                return false;
            const int MAX_NAME_LENGTH = 50;
            if (trimmedName.Length > MAX_NAME_LENGTH)
                return false;

            DateTime start = startDatePicker.Value;
            DateTime end = endDatePicker.Value;
            if (start > end)
                return false;

            bool newExhibition;
            if (managedExhibition == null)
            {
                managedExhibition = new Wystawa();
                newExhibition = true;
            }
            else
            {
                managedExhibition = db.Wystawa.Find(managedExhibition.WystawaID);
                newExhibition = false;
            }

            managedExhibition.Nazwa = trimmedName;
            managedExhibition.Opis = descriptionText.Text.Trim();
            managedExhibition.Data_rozpoczęcia = start;
            managedExhibition.Data_zakończenia = end;
            UserSingleton user = UserSingleton.Instance;
            user.CreateLibrarianUnsafeMethodDeleteLater();
            Bibliotekarz librarian = (Bibliotekarz)user.GetLoggedUser();
            librarian = db.Bibliotekarz.Find(librarian.BibliotekarzID);
            managedExhibition.Bibliotekarz = librarian;
            managedExhibition.BibliotekarzID = librarian.BibliotekarzID;

            if (newExhibition)
                db.Wystawa.Add(managedExhibition);
            else
                db.Entry(managedExhibition).State = EntityState.Modified;

            return true;
        }

        /// <summary>
        /// Obsługa akceptacji podanych argumentów.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    bool result = confirm(db);
                    if (result)
                        db.SaveChanges();
                    else
                    {
                        MessageBox.Show(
                            "Brak tytułu lub data zakończenia jest wcześniej niż rozpoczęcia.",
                            "Błędne dane w formularzu.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                this.Return();
            }
        }

        private void ExhibitionAddForm_Load(object sender, EventArgs e)
        {
            if (managedExhibition == null) return;

            using (var db = new BibliotekaDB())
            {
                managedExhibition = db.Wystawa.Find(managedExhibition.WystawaID);
                nameText.Text = managedExhibition.Nazwa;
                descriptionText.Text = managedExhibition.Opis;
                startDatePicker.Value = managedExhibition.Data_rozpoczęcia;
                endDatePicker.Value = managedExhibition.Data_zakończenia;
            }
        }
    }
}
