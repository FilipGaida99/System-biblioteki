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
    public partial class UserCheckoutsForm : Form
    {
        /// <summary>
        /// Lista wypożyczeń użytkownika
        /// </summary>
        private List<Wypożyczenie> userCheckouts;

        /// <summary>
        /// Obiekt przechowujący informację o czytelniku, którego wypożyczenia pojawiają się na ekranie
        /// </summary>
        private Czytelnik user;

        /// <summary>
        /// Obiet sortujący kolumny w kontrolce ListView
        /// </summary>
        ListViewColumnSorter sorter;

        public UserCheckoutsForm()
        {
            InitializeComponent();
            sorter = new ListViewColumnSorter(checkoutsList.Columns.Count);
            sorter.Order = SortOrder.Ascending;
            sorter.SortColumn = checkoutsList.Columns.IndexOf(checkoutDate);
            checkoutsList.ListViewItemSorter = sorter;
        }

        

        private void UserCheckoutsForm_Load(object sender, EventArgs e)
        {
            using(new AppWaitCursor(ParentForm, e))
            {
                using (var db = new BibliotekaDB())
                {
                    user = db.Czytelnik.Find(10003); // usunąć jak będą użytkownicy
                    refreshButton_Click(sender, e);
                }
            }
            

        }

        private void UpdateListView()
        {
            checkoutsList.BeginUpdate();
            checkoutsList.Items.Clear();
            foreach (var checkout in userCheckouts)
            {
                DateTime excpectedReturnDate = (DateTime)checkout.Data_wypożyczenia;
                var daysToReturn = checkout.Egzemplarz.Książka.Maksymalny_okres_wypożyczenia;
                excpectedReturnDate = excpectedReturnDate.AddDays((double)daysToReturn);
                
                string[] row = { checkout.Egzemplarz.Książka.Tytuł,
                                $"{checkout.Data_wypożyczenia:g}",
                                $"{excpectedReturnDate:g}",
                                checkout.Egzemplarz.Nr_inwentarza.ToString() };

                checkoutsList.Items.Add(new ListViewItem(row));
            }
            checkoutsList.Sort();
            checkoutsList.EndUpdate();
        }

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

        private void refreshButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(ParentForm, e))
            {
                using(var db = new BibliotekaDB())
                {
                    var query = db.Wypożyczenie.AsNoTracking().Where(checkout => checkout.CzytelnikID == user.CzytelnikID   /*logged user ID*/);
                    
                    if(!returnedChecBox.Checked)
                        query = query.Where(checkout => checkout.Data_zwrotu == null);

                    query = query.OrderBy(checkout => checkout.Data_wypożyczenia);
                    userCheckouts = query.ToList();

                    UpdateListView();
                }

            }
        }
    }
}
