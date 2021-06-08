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
    }
}
