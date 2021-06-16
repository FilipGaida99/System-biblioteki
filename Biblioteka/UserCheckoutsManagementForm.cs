using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Biblioteka
{
    public partial class UserCheckoutsManagementForm : Biblioteka.UserCheckoutsForm
    {
        public UserCheckoutsManagementForm(long _userID) : base(_userID)
        {
            InitializeComponent();
        }

        protected override void RefreshCheckoutList()
        {
            base.RefreshCheckoutList();
            returnButton.Enabled = false;
            if (!returnedCheckBox.Checked)
            {
                returnButton.Enabled = true;
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            var selected = checkoutsList.SelectedItems;
            if (selected.Count == 0)
            {
                MessageBox.Show("Nie wybrano żadnej książki do zwrotu!",
                                "Błąd",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            using (new AppWaitCursor(this, sender))
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
                        RefreshCheckoutList();
                    }
                }
            }
        }

        /// <summary>
        /// Obsługa tworzenia prolongat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void extensionButton_Click(object sender, EventArgs e)
        {
            var selected = checkoutsList.SelectedIndices;

            if (selected.Count == 0) return;

            using (new AppWaitCursor(this, sender))
            {
                var result = MessageBox.Show(
                    $"Na pewno prolongować te egzemplarze ({selected.Count}) czytelnikowi {userID}?",
                    "Na pewno?", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;

                Extensions(selected);
                RefreshCheckoutList();
            }
        }

        /// <summary>
        /// Dodawanie prolongat.
        /// </summary>
        /// <param name="selected">Kolekcja indeksów wypożyczeń.</param>
        private void Extensions(ListView.SelectedIndexCollection selected)
        {
            using (var db = new BibliotekaDB())
            {
                for (int i = 0; i < selected.Count; ++i)
                {
                    int checkoutIndex = selected[i];
                    var checkoutID = userCheckouts[checkoutIndex].WypożyczenieID;

                    Wypożyczenie checkout = db.Wypożyczenie.Find(checkoutID);
                    if (checkout == null) return;
                    Prolongata extension = new Prolongata()
                    {
                        Status = 1,
                        Data_prolongaty = checkout.Przewidywany_zwrot.AddDays(
                                checkout.Egzemplarz.Książka.Maksymalny_okres_wypożyczenia),
                        Wypożyczenie = checkout,
                        WypożyczenieID = checkoutID
                    };
                    checkout.Prolongata.Add(extension);
                }
                db.SaveChanges();
            }
        }
    }
}
