﻿using System;
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
            managedBook = _managedBook;
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
                errorText = "Niepoprawny numer ISBN";
                return false;
            }
            managedBook.ISBN = ISBNValidator.NormalizeIsbn(isbnText.Text);
            if(titleText.Text.Trim() == "")
            {
                errorText = "Pusty tytuł.";
                return false;
            }
            managedBook.Tytuł = titleText.Text;
            managedBook.Opis = descriptionText.Text;
            managedBook.Rok_wydania = datePicker.Value;
            managedBook.Maksymalny_okres_wypożyczenia = (long)daySpanPicker.Value;

            if(!managedBook.SetPublisher(db, publisherPicker.PublisherName))
            {
                errorText = "Pusta nazwa wydawnictwa";
                return false;
            }
            
            if(!managedBook.SetAuthors(db, authors))
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
                    isbnText.Text = managedBook.ISBN;
                    datePicker.Value = managedBook.Rok_wydania;
                    titleText.Text = managedBook.Tytuł;
                    descriptionText.Text = managedBook.Opis;
                    publisherPicker.PublisherName = managedBook.Wydawnictwo.Nazwa;
                    daySpanPicker.Value = managedBook.Maksymalny_okres_wypożyczenia;

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
                            Autor.DeleteEmpty(db);
                            Wydawnictwo.DeleteEmpty(db);
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
                        MessageBox.Show(exception.ToString(),
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
                AuthorForm form = new AuthorForm();
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    AddAutor(form.choosedAutor);
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

    }
}
