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
    public partial class BookModificationForm : Form
    {
        bool isNewBook;
        protected Książka managedBook;
        List<Autor> autors;

        public BookModificationForm()
        {
            InitializeComponent();
            autors = new List<Autor>();
            isNewBook = true;
            managedBook = new Książka();
        }

        public BookModificationForm(Książka _managedBook)
        {
            InitializeComponent();
            autors = new List<Autor>();
            isNewBook = false;
            managedBook = _managedBook;
        }

        protected virtual bool Accept(BibliotekaDB db)
        {
            if(!isNewBook)
            {
                managedBook = db.Książka.Find(managedBook.KsiążkaID);
            }

            managedBook.ISBN = isbnText.Text;
            managedBook.Tytuł = titleText.Text;
            managedBook.Opis = descriptionText.Text;
            managedBook.Rok_wydania = datePicker.Value;
            managedBook.Maksymalny_okres_wypożyczenia = (long)daySpanPicker.Value;

            if(publisherText.Text.Trim() == "")
            {
                return false;
            }

            managedBook.Wydawnictwo = db.Wydawnictwo.Where(wyd => wyd.Nazwa == publisherText.Text).FirstOrDefault();
            if(managedBook.Wydawnictwo == null)
            {
                managedBook.Wydawnictwo = db.Wydawnictwo.Add(new Wydawnictwo { Nazwa = publisherText.Text });
            }
            managedBook.WydawnictwoID = managedBook.Wydawnictwo.WydawnictwoID;
            
            if(autors.Count <= 0)
            {
                return false;
            }

            var currentAutors = managedBook.Autor.ToList();
            managedBook.Autor.Clear();
            foreach(var autor in autors)
            {
                Autor autorToAdd = db.Autor.Where(_autor => _autor.Imię == autor.Imię).FirstOrDefault();
                if (autorToAdd == null)
                {
                    autorToAdd = db.Autor.Add(autor);
                }
                managedBook.Autor.Add(autorToAdd);

            }

            if (isNewBook)
            {
                db.Książka.Add(managedBook);
            }
            else
            {
                db.Entry(managedBook).State = EntityState.Modified;
            }
            
            return true;
        }

        private void BookModificationForm_Load(object sender, EventArgs e)
        {
            if (!isNewBook)
            {
                using (var db = new BibliotekaDB())
                {
                    managedBook = db.Książka.Find(managedBook.KsiążkaID);
                    isbnText.Text = managedBook.ISBN;
                    datePicker.Value = managedBook.Rok_wydania;
                    titleText.Text = managedBook.Tytuł;
                    descriptionText.Text = managedBook.Opis;
                    publisherText.Text = managedBook.Wydawnictwo.Nazwa;
                    daySpanPicker.Value = managedBook.Maksymalny_okres_wypożyczenia;

                    var list = managedBook.Autor.OrderBy(autor => autor.Nazwisko).ToList();
                    foreach (var autor in list)
                    {
                        AddAutor(autor);
                    }
                }
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                if (Accept(db)) 
                {
                    db.SaveChanges();
                }
                else
                {
                    return;
                }
            }
            this.Return();
        }

        private void choosePublisherButton_Click(object sender, EventArgs e)
        {
            PublisherForm form = new PublisherForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                publisherText.Text = form.choosedPublisherName;
            }
        }

        private void addAutorButton_Click(object sender, EventArgs e)
        {
            AutorForm form = new AutorForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                AddAutor(form.choosedAutor);
            }
        }

        private void deleteAutorButton_Click(object sender, EventArgs e)
        {
            if(autorsList.SelectedIndex >= 0)
            {
                autors.RemoveAt(autorsList.SelectedIndex);
                autorsList.Items.RemoveAt(autorsList.SelectedIndex);
                autorsList.SelectedIndex = -1;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Return();
        }

        private void AddAutor(Autor autor)
        {
            if (!autors.Exists(_autor => _autor.Imię == autor.Imię && _autor.Nazwisko == autor.Nazwisko))
            { 
                autorsList.Items.Add($"{autor.Imię} {autor.Nazwisko}");
                autors.Add(autor);
            }
        }

    }
}
