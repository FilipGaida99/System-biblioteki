using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class ReaderSearch : UserControl
    {
        /// <summary>
        /// Callback wywoływany po wyszukaniu użytkowników
        /// </summary>
        public Action onSearch;
        /// <summary>
        /// Lista znalezionych czytelników
        /// </summary>
        public List<Czytelnik> readers;

        /// <summary>
        /// konstrutor bezargumentowy kontrolki do wyszukiwania użytkowników
        /// </summary>
        public ReaderSearch()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(ParentForm, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    try
                    {
                        var query = db.Czytelnik.AsNoTracking().Where(reader => reader.Imię.Contains(searchName.Text));
                        query = query.Where(reader => reader.Nazwisko.Contains(searchSurname.Text));
                        int phoneNumber;
                        if(searchPhone.Text != "")
                        {
                            if (searchPhone.Text.Length < 9)
                                throw new IndexOutOfRangeException();

                            phoneNumber = int.Parse(searchPhone.Text);
                            if ((int)(Math.Log10(phoneNumber) + 1) == 9) //czy numer ma 9 cyfr przy okazji sprawdza czy nie ma 0 na początku
                            {
                                query = query.Where(reader => reader.Numer_telefonu == phoneNumber);
                            }
                            else
                            {
                                throw new IndexOutOfRangeException(); //zrobic swoj wyjątek
                            }
                        }
                        query = query.Where(reader => reader.Adres_email.Contains(searchMail.Text)).OrderBy(reader => reader.Nazwisko);

                        readers = query.ToList();
                        onSearch.Invoke();
                    }
                    catch(IndexOutOfRangeException)
                    {
                        MessageBox.Show("Numer telefonu, który podano nie zawiera 9 cyfr!",
                            "Błąd",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }
    }
}
