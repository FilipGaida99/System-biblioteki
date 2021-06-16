﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Biblioteka
{
    /// <summary>
    /// Formularz do przeglądania wypozyczeń wykorzystywany przez bibliotekarza, umozlwiający zarządzanie.
    /// </summary>
    public partial class UserCheckoutsManagementForm : Biblioteka.UserCheckoutsForm
    {
        /// <summary>
        /// Konstruktor jednoargumentowy
        /// </summary>
        /// <param name="_userID"></param>
        public UserCheckoutsManagementForm(long _userID) : base(_userID)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda do odświeżania listy wypożyczeń, uniemożliwia też zwroty
        /// </summary>
        protected override void RefreshCheckoutList()
        {
            base.RefreshCheckoutList();
            returnButton.Enabled = false;
            if (!returnedCheckBox.Checked)
            {
                returnButton.Enabled = true;
            }
        }

        /// <summary>
        /// Metoda wywoływana po kliknięciu przycisku zwracającego wybraną książkę
        /// </summary>
        /// <param name="sender"></param> Kontrolka
        /// <param name="e"></param> Argumenty
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
