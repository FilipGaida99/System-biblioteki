using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Formularz modyfikacji książki.
    /// </summary>
    public partial class BookModificationForm : Form
    {
        /// <summary>
        /// Zarządzana książka.
        /// </summary>
        public Książka managedBook;
        /// <summary>
        /// Wybrane wydawnictwo.
        /// </summary>
        Wydawnictwo publisher;
        /// <summary>
        /// Lista wybranych autorów.
        /// </summary>
        List<Autor> authors;

        /// <summary>
        /// Konstruktor dla nowych książek.
        /// </summary>
        public BookModificationForm(): this(null)
        {
        }

        /// <summary>
        /// Konstruktor dla modyfikowanych książek.
        /// </summary>
        public BookModificationForm(Książka _managedBook)
        {
            InitializeComponent();
            authors = new List<Autor>();
            publisher = null;
            managedBook = _managedBook;
            if(managedBook != null)
            {
                using(var db = new BibliotekaDB())
                {
                    publisher = db.Wydawnictwo.Find(managedBook.WydawnictwoID);
                }
            }
        }

        /// <summary>
        /// Funkcja wprowadzająca dane z formularza do modelu.
        /// </summary>
        /// <param name="db">Kontekst bazy danych.</param>
        /// <param name="errorText">Opis powstałego błędu, jeśli zwrócono false.</param>
        /// <returns>True, gdy udało się wprowadzić wszystkie dane.</returns>
        protected virtual bool Accept(BibliotekaDB db, out string errorText)
        {
            if(managedBook != null)
            {
                managedBook = db.Książka.Find(managedBook.KsiążkaID);
            }

            bool isNew = false;
            if (managedBook == null)
            {
                managedBook = new Książka();
                isNew = true;
            }

            ISBNValidator isbnValidator = new ISBNValidator(isbnText.Text);
            if (!isbnValidator.Validate())
            {
                errorText = "Niepoprawny numer ISBN.";
                return false;
            }
            managedBook.ISBN = isbnText.Text;

            if(titleText.Text.Trim() == "")
            {
                errorText = "Pusty tytuł.";
                return false;
            }
            managedBook.Tytuł = titleText.Text;
            managedBook.Opis = descriptionText.Text;

            var copiesWithErrorDate = managedBook.Egzemplarz.Where(copy => copy.Rok_wydruku < datePicker.Value).ToList();
            if (copiesWithErrorDate.Count > 0)
            {
                errorText = "Podane egzemplarze zawierają datę wydruku starszą niż wybrana data wydania:\n";
                foreach(var copy in copiesWithErrorDate)
                {
                    errorText += $"• {copy.Nr_inwentarza} ({copy.Rok_wydruku.ToShortDateString()})\n";
                }
                errorText += "Jeżeli zmiana jest wymagana, zmień najpierw daty wydruku.";
                return false;
            }
            managedBook.Rok_wydania = datePicker.Value;

            managedBook.Maksymalny_okres_wypożyczenia = (long)daySpanPicker.Value;

            if(publisher == null)
            {
                errorText = "Brak wydawnictwa";
                return false;
            }
            managedBook.Wydawnictwo = db.Wydawnictwo.Find(publisher.WydawnictwoID);

            if (!managedBook.SetAuthors(db, authors))
            {
                errorText = "Brak autorów";
                return false;
            }

            if (isNew)
            {
                db.Książka.Add(managedBook);
            }
            else
            {
                db.Entry(managedBook).State = EntityState.Modified;
            }

            errorText = "";
            return true;
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void BookModificationForm_Load(object sender, EventArgs e)
        {
            if (managedBook != null)
            {
                using (var db = new BibliotekaDB())
                {
                    managedBook = db.Książka.Find(managedBook.KsiążkaID);
                    isbnText.Text = managedBook.ISBN.Trim();
                    datePicker.Value = managedBook.Rok_wydania;
                    titleText.Text = managedBook.Tytuł;
                    descriptionText.Text = managedBook.Opis;
                    daySpanPicker.Value = managedBook.Maksymalny_okres_wypożyczenia;
                    publisherText.Text = managedBook.Wydawnictwo.Nazwa;

                    var list = managedBook.Autor.OrderBy(author => author.Nazwisko).ToList();
                    foreach (var author in list)
                    {
                        AddAutor(author);
                    }
                }
            }
        }

        /// <summary>
        /// Obsługa akceptacji podanych argumentów.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void acceptButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    string errorText;
                    try
                    {
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
                    catch (DbEntityValidationException exception)
                    {
                        string errors = "";

                        foreach(var enitityValidationError in exception.EntityValidationErrors)
                        {
                            errors += $"Encja \"{enitityValidationError.Entry.Entity.GetType().Name}\" wygenerowała następujące błędy:\n";
                            foreach (var validationError in enitityValidationError.ValidationErrors)
                            {
                                errors += $"- Właściwość: \"{validationError.PropertyName}\", Błąd: \"{validationError.ErrorMessage}\"\n";
                            }
                        }
                        MessageBox.Show(errors,
                            "Nie można zaaktualizować bazy danych",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message,
                            "Wyjątek",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    finally
                    {
                        db.Książka.Local.Clear();
                        db.Autor.Local.Clear();
                        db.Wydawnictwo.Local.Clear();
                    }
                }
                this.Return();
            }
        }

        /// <summary>
        /// Obsługa dodawania nowego autora.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void addAutorButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                AuthorPickForm form = new AuthorPickForm();
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    AddAutor(form.author);
                }
            }
        }

        /// <summary>
        /// Obsługa usuwania autora z listy.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void deleteAutorButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                if (authorsList.SelectedIndex >= 0)
                {
                    authors.RemoveAt(authorsList.SelectedIndex);
                    authorsList.Items.RemoveAt(authorsList.SelectedIndex);
                    authorsList.SelectedIndex = -1;
                }
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
        /// Dodawanie autora do listy.
        /// </summary>
        /// <param name="author">Autor do dodania.</param>
        private void AddAutor(Autor author)
        {
            if (!authors.Exists(_author => _author.MatchNameWith(author)))
            { 
                authorsList.Items.Add($"{author.Imię} {author.Nazwisko}");
                authors.Add(author);
            }
        }

        /// <summary>
        /// Przejście do zarządzania wydwanictwami.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void publisherButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                PublisherPickForm form = new PublisherPickForm();
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    publisher = form.publisher;
                    publisherText.Text = publisher.Nazwa;
                }
            }
        }
    }
}
