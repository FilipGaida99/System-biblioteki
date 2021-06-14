using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Form z wypożyczeniami w ListView dla czytelnika.
    /// </summary>
    public partial class UserCheckoutsViewForm : Biblioteka.UserCheckoutsForm
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="_userID">ID czytelnika</param>
        public UserCheckoutsViewForm(long _userID) : base(_userID)
        {
            InitializeComponent();
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
                    $"Na pewno chcesz prolongować te egzemplarze ({selected.Count})?",
                    "Na pewno?", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;

                Extensions(selected);
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
                        Status = null,
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
