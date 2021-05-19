﻿using System;
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
    public partial class ExhibitionAddForm : Form
    {
        public Wystawa managedExhibition;

        public ExhibitionAddForm(): this(null)
        {
        }

        public ExhibitionAddForm(Wystawa exhibition)
        {
            InitializeComponent();
            managedExhibition = exhibition;
        }

        private bool confirm(BibliotekaDB db)
        {
            bool newExhibition;
            if (managedExhibition != null)
            {
                managedExhibition = db.Wystawa.Find(managedExhibition.WystawaID);
                newExhibition = false;
            }
            else
            {
                managedExhibition = new Wystawa();
                newExhibition = true;
            }

            string trimmedName = nameText.Text.Trim();
            if (trimmedName == "")
                return false;

            DateTime start = startDatePicker.Value;
            DateTime end = endDatePicker.Value;
            if (start > end)
                return false;

            managedExhibition.Nazwa = trimmedName;
            managedExhibition.Opis = descriptionText.Text.Trim();
            managedExhibition.Data_rozpoczęcia = start;
            managedExhibition.Data_zakończenia = end;
            //managedExhibition.
            // jak przypisac bibliotekarza do wystawy
            // musze czekac az beda zrobieni bibliotekarze

            if (newExhibition)
                db.Wystawa.Add(managedExhibition);
            else
                db.Entry(managedExhibition).State = EntityState.Modified;

            return true;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    bool result = confirm(db);
                    if (result)
                    {
                        //db.SaveChanges();
                        // nie ma bibliotekarzy
                    }
                    else
                    {
                        MessageBox.Show(
                            "Brak tytułu lub data zakończenia jest wcześniej niż rozpoczęcia.",
                            "Błędne dane w formularzu.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                this.Return();
            }
        }
    }
}
