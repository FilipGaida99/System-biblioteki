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
        /// ID czytelnika
        /// </summary>
        private long userID;

        /// <summary>
        /// Obiet sortujący kolumny w kontrolce ListView
        /// </summary>
        ListViewColumnSorter sorter;

        public UserCheckoutsForm(long _userID)
        {
            InitializeComponent();
            sorter = new ListViewColumnSorter(checkoutsList.Columns.Count);
            sorter.Order = SortOrder.Ascending;
            sorter.SortColumn = checkoutsList.Columns.IndexOf(checkoutDate);
            checkoutsList.ListViewItemSorter = sorter;
            userID = _userID;
        }

        

        private void UserCheckoutsForm_Load(object sender, EventArgs e)
        {
            using(new AppWaitCursor(ParentForm, e))
            {
                using (var db = new BibliotekaDB())
                {
                    refreshButton_Click(sender, e);
                }
                // TO DO: jeśli zalogowany bibliotekarz to nie chowaj przycisu do zwrotu
                returnButton.Enabled = false;
                returnButton.Visible = false;
                //if (/*logged librarian*/)
                //{
                    returnButton.Enabled = true;
                    returnButton.Visible = true;
                //}
            }
        }

        private void UpdateListView()
        {
            checkoutsList.BeginUpdate();
            checkoutsList.Items.Clear();
            foreach (var checkout in userCheckouts)
            {
                var returnDate = checkout.Data_zwrotu;
                string returnDateInString;
                returnDateInString = $"{returnDate:g}";
                if (returnDate == null)
                {
                    returnDateInString = "Wypożyczona";
                }
                
                DateTime excpectedReturnDate = (DateTime)checkout.Data_wypożyczenia;
                var daysToReturn = checkout.Egzemplarz.Książka.Maksymalny_okres_wypożyczenia;
                excpectedReturnDate = excpectedReturnDate.AddDays((double)daysToReturn);
                
                string[] row = { checkout.Egzemplarz.Książka.Tytuł,
                                $"{checkout.Data_wypożyczenia:g}",
                                $"{excpectedReturnDate:g}",
                                returnDateInString,
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
                    var query = db.Wypożyczenie.AsNoTracking().Where(checkout => checkout.CzytelnikID == userID   /*logged user ID*/);

                    returnButton.Enabled = false;
                    if (!returnedChecBox.Checked)
                    {
                        query = query.Where(checkout => checkout.Data_zwrotu == null);
                        returnButton.Enabled = true;
                    }
                        
                    query = query.OrderBy(checkout => checkout.Data_wypożyczenia);
                    query = query.OrderBy(checkout => checkout.Data_zwrotu);
                    
                    userCheckouts = query.ToList();

                    UpdateListView();
                }

            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            var selected = checkoutsList.SelectedItems;
            if(selected.Count == 0)
            {
                MessageBox.Show("Nie wybrano żadnej książki do zwrotu!",
                                "Błąd",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            using(new AppWaitCursor(ParentForm, e))
            {
                using (var db = new BibliotekaDB())
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var item = selected[i];
                        var copyNumber = item.SubItems[checkoutsList.Columns.Count - 1].Text;

                        var query = db.Wypożyczenie.Where(checkout => checkout.Data_zwrotu == null);
                        query = query.Where(checkout => checkout.CzytelnikID == userID);
                        var copyNumberLong = Convert.ToInt64(copyNumber);
                        query = query.Where(checkout => checkout.Egzemplarz.Nr_inwentarza == copyNumberLong);

                        Wypożyczenie checkoutToReturn = query.First();
                        if (checkoutToReturn != null)
                        {
                            checkoutToReturn.Data_zwrotu = DateTime.Now;
                            db.SaveChanges();
                        }
                        refreshButton_Click(sender, e);
                    }
                }
            }
        }
    }
}
