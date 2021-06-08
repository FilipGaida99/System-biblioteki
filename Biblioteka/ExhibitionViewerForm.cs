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
    /// Form wyświetlający wystawy czytelnikowi.
    /// </summary>
    public partial class ExhibitionViewerForm : Form
    {
        /// <summary>
        /// Lista wystaw.
        /// </summary>
        List<Wystawa> exhibitions;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ExhibitionViewerForm()
        {
            InitializeComponent();
            exhibitions = new List<Wystawa>();
        }

        /// <summary>
        /// Aktualizacja listy wystaw w formularzu na podstawie zapisanej listy wystaw.
        /// </summary>
        private void UpdateExhibitionList()
        {
            exhibitionList.BeginUpdate();
            exhibitionList.Items.Clear();
            foreach (var ex in exhibitions)
                exhibitionList.Items.Add(ex.Nazwa);
            exhibitionList.EndUpdate();
        }

        /// <summary>
        /// Wyświetlenie wybranej wystawy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showButton_Click(object sender, EventArgs e)
        {
            int exhibitionIndex = exhibitionList.SelectedIndex;
            if (exhibitionIndex < 0) return;
            var exhibitionID = exhibitions[exhibitionIndex].WystawaID;
            using (new AppWaitCursor(this, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    Wystawa exhibition = db.Wystawa.Find(exhibitionID);
                    exhibitionDetails1.Update(exhibition);
                }
            }
        }

        private void ExhibitionViewerForm_Load(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    exhibitions = db.Wystawa.OrderBy(exhibition => exhibition.Data_rozpoczęcia).ToList();
                    UpdateExhibitionList();
                    exhibitionDetails1.Update(exhibitions.FirstOrDefault());
                }
            }
        }
    }
}
