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
    public partial class CopyModificationForm : Form
    {
        Egzemplarz managedCopy;
        Książka bookCopy;

        public CopyModificationForm(Książka book)
        {
            InitializeComponent();
            managedCopy = null;
            bookCopy = book;
        }

        public CopyModificationForm(Egzemplarz copy, Książka book)
        {
            InitializeComponent();
            managedCopy = copy;
            bookCopy = book;
        }

        protected virtual bool Accept(BibliotekaDB db)
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
            }

            long newInventory = -1;
            if (!long.TryParse(copyInventoryText.Text, out newInventory))
            {
                MessageBox.Show($"Wprowadzony numer unwenatarza jest niepoprawny.",
                    "Niepoprawny numer",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var _copy = db.Egzemplarz.FirstOrDefault(copy => copy.Nr_inwentarza == newInventory);
            if (_copy != null && _copy.Nr_inwentarza != managedCopy.Nr_inwentarza)
            {
                MessageBox.Show($"Wprowadzony numer inwenatarza jest już używany przez: " +
                    $" \"{_copy.Książka.Tytuł}\" (ISBN:{_copy.Książka.ISBN.Trim()}).",
                    "Używany numer inwentarza",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            managedCopy.Nr_inwentarza = newInventory;

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

            bookCopy = db.Książka.Find(bookCopy.KsiążkaID);
            if(bookCopy == null)
            {
                return false;
            }
            managedCopy.Książka = bookCopy;

            if (isNew)
            {
                db.Egzemplarz.Add(managedCopy);
            }
            else
            {
                db.Entry(managedCopy).State = EntityState.Modified;
            }

            return true;
        }

        private void isElectronicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            linkText.Enabled = isElectronicCheckBox.Checked;
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Return();
        }

        private void CopyModificationForm_Load(object sender, EventArgs e)
        {
            if(managedCopy != null)
            {
                using(var db = new BibliotekaDB())
                {
                    managedCopy = db.Egzemplarz.Find(managedCopy.Nr_inwentarza);
                    copyInventoryText.Text = managedCopy.Nr_inwentarza.ToString();
                    var electrioncCopy = managedCopy.Egzemplarz_elektroniczny;
                    if(electrioncCopy != null)
                    {
                        isElectronicCheckBox.Checked = true;
                        linkText.Text = electrioncCopy.Odnośnik;
                    }
                }
            }
        }
    }
}
