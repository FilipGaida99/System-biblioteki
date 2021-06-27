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
    /// <summary>
    /// Formularz Z inforacjami o wypożyczeniach
    /// </summary>
    public partial class UserCheckoutsForm : Form
    {
        /// <summary>
        /// Lista wypożyczeń użytkownika
        /// </summary>
        protected List<Wypożyczenie> userCheckouts;

        /// <summary>
        /// ID czytelnika
        /// </summary>
        protected long userID;

        /// <summary>
        /// Obiet sortujący kolumny w kontrolce ListView
        /// </summary>
        ListViewColumnSorter sorter;

        /// <summary>
        /// Konstruktor bezargumentowy dla formu dziedziczącego
        /// </summary>
        public UserCheckoutsForm(): this(long.MinValue)
        {}

        /// <summary>
        /// Konstruktor jednoargumentowy
        /// </summary>
        /// <param name="_userID"></param> ID czytelnika, którego wypozyczenia są otwarte na ekranie
        public UserCheckoutsForm(long _userID)
        {
            InitializeComponent();
            sorter = new ListViewColumnSorter(checkoutsList.Columns.Count);
            sorter.Order = SortOrder.Ascending;
            sorter.SortColumn = checkoutsList.Columns.IndexOf(checkoutDate);
            checkoutsList.ListViewItemSorter = sorter;
            userID = _userID;
        }

        /// <summary>
        /// Metoda odświeżająca listę aktualnych wypozyczeń czytelnika
        /// </summary>
        protected virtual void RefreshCheckoutList()
        {
            using (var db = new BibliotekaDB())
            {
                //TO DO:
                var query = db.Wypożyczenie.AsNoTracking().Where(checkout => checkout.CzytelnikID == userID   /*logged user ID*/);

                if (!returnedCheckBox.Checked)
                {
                    query = query.Where(checkout => checkout.Data_zwrotu == null);
                }

                query = query.OrderBy(checkout => checkout.Data_wypożyczenia);
                query = query.OrderBy(checkout => checkout.Data_zwrotu);

                userCheckouts = query.ToList();

                UpdateListView();
            }
        }

        /// <summary>
        /// Metoda wywoływana w trakcie ładowania formularza.
        /// </summary>
        /// <param name="sender"></param> Kontrolka
        /// <param name="e"></param> Argumenty
        private void UserCheckoutsForm_Load(object sender, EventArgs e)
        {
            if (userID != long.MinValue)
            {
                using (new AppWaitCursor(ParentForm, e))
                {
                    using (var db = new BibliotekaDB())
                    {
                        refreshButton_Click(sender, e);
                    }
                }
            }
        }

        /// <summary>
        /// Metoda odświeżająca informacje na panelu z listą wypożyczeń
        /// </summary>
        private void UpdateListView()
        {
            checkoutsList.BeginUpdate();
            checkoutsList.Items.Clear();
            foreach (var checkout in userCheckouts)
            {
                var returnDate = checkout.Data_zwrotu;
                string returnDateInString = $"{returnDate:g}";
                if (returnDate == null)
                {
                    var lastExtension = checkout.Prolongata.LastOrDefault();
                    if (lastExtension != null && lastExtension.Status == null)
                        returnDateInString = "Oczekująca prolongata";
                    else
                        returnDateInString = "Wypożyczona";
                }
                
                string copyInfo = checkout.Egzemplarz.Nr_inwentarza.ToString();
                if(checkout.LendedElectronicCopy)
                {
                    copyInfo += " (E)";
                }

                DateTime excpectedReturnDate = checkout.Przewidywany_zwrot;
                var daysToReturn = checkout.Egzemplarz.Książka.Maksymalny_okres_wypożyczenia;
                excpectedReturnDate = excpectedReturnDate.AddDays((double)daysToReturn);

                string[] row = { checkout.Egzemplarz.Książka.Tytuł,
                                $"{checkout.Data_wypożyczenia:g}",
                                $"{excpectedReturnDate:g}",
                                returnDateInString,
                                copyInfo };

                checkoutsList.Items.Add(new ListViewItem(row));
            }
            checkoutsList.Sort();
            checkoutsList.EndUpdate();
        }

        /// <summary>
        /// Metoda sortująca ustawiająca sortowanie i sortujaca po klinięciu na kolumnę panelu listy wypożyczeń
        /// </summary>
        /// <param name="sender"></param> Kontrolka
        /// <param name="e"></param> Argumenty
        private void CheckoutsList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sorter.SortColumn)
            {
                if (sorter.Order == SortOrder.Ascending)
                {
                    sorter.Order = SortOrder.Descending;
                }
                else
                {
                    sorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                sorter.SortColumn = e.Column;
                sorter.Order = SortOrder.Ascending;
            }

            checkoutsList.Sort();
        }

        /// <summary>
        /// Metoda wywoływana po kliknięciu przyciksu odświeżającego
        /// </summary>
        /// <param name="sender"></param> Kontrolka
        /// <param name="e"></param> Argumenty
        private void refreshButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                RefreshCheckoutList();
            }
        }

        /// <summary>
        /// Metoda otwiera odnośnik do wypożyczonego egzemplarza elektronicznego, jezeli zostanie on klikniety dwa razy
        /// </summary>
        /// <param name="sender"></param> Kontrolka
        /// <param name="e"></param> Odnośnik
        public void OpenElectronicCopy_DoubleClick(object sender, EventArgs e)
        {
            var selected = checkoutsList.SelectedItems;
            if (selected.Count > 1)
                return;
            var item = selected[0];
            var copyNumber = item.SubItems[checkoutsList.Columns.Count - 1].Text;
            if (!copyNumber.Contains("(E)"))
                return;
            copyNumber = copyNumber.Replace("(E)", "");
            copyNumber = copyNumber.Trim();
            var copyNumberInLong = Convert.ToInt64(copyNumber);
            using (new AppWaitCursor(ParentForm, e))
            {
                using (var db = new BibliotekaDB())
                {
                    var query2 = db.Wypożyczenie.Where(lend => lend.CzytelnikID == userID);
                    query2 = query2.Where(lend => lend.Data_zwrotu != null);
                    query2 = query2.Where(lend => lend.Nr_inwentarza == copyNumberInLong);

                    if (query2.ToList().Count == 1)
                    {
                        var query = db.Egzemplarz_elektroniczny.Where(elCopy => elCopy.Nr_inwentarza == copyNumberInLong);
                        var electronicCopy = query.FirstOrDefault();
                        System.Diagnostics.Process.Start($"{electronicCopy.Odnośnik}");

                    }
                }
            }
        }

    }
}
