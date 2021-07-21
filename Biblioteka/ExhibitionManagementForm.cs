using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotekaModel;

namespace Biblioteka
{
    /// <summary>
    /// Form zarządzania wystawami.
    /// </summary>
    public partial class ExhibitionManagementForm : Form
    {
        /// <summary>
        /// Lista wystaw.
        /// </summary>
        List<Wystawa> exhibitions;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ExhibitionManagementForm()
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
        /// Dodawanie wystawy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                ExhibitionAddForm form = new ExhibitionAddForm();
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                if (form.Wystawa == null)
                    return;

                exhibitions.Add(form.Wystawa);
                UpdateExhibitionList();
            }
        }

        private void ExhibitionManagementForm_Load(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                exhibitions = db.Wystawa.OrderBy(exhibition => exhibition.Data_rozpoczęcia).ToList();
                UpdateExhibitionList();
            }
        }

        /// <summary>
        /// Obsługa usunięcia wybranej wystawy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                int exhibitionIndex = exhibitionList.SelectedIndex;
                if (exhibitionIndex >= 0)
                    DeleteExhibition(exhibitionIndex);
            }
        }

        /// <summary>
        /// Usunięcie wystawy.
        /// </summary>
        /// <param name="exhibitionIndex">Indeks wystawy na liście.</param>
        private void DeleteExhibition(int exhibitionIndex)
        {
            var exhibitionID = exhibitions[exhibitionIndex].WystawaID;

            using (var db = new BibliotekaDB())
            {
                Wystawa exhibitionToRemove = db.Wystawa.Find(exhibitionID);

                if (exhibitionToRemove != null)
                {
                    var result = MessageBox.Show(
                        $"Na pewno chcesz usunąć {exhibitionToRemove.Nazwa}?",
                        "Na pewno?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) return;

                    db.Wystawa.Remove(exhibitionToRemove);
                }

                exhibitionList.Items.RemoveAt(exhibitionIndex);
                exhibitions.RemoveAt(exhibitionIndex);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Obsługa modyfikacji wybranej wystawy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifyButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                int exhibitionIndex = exhibitionList.SelectedIndex;
                if (exhibitionIndex < 0) return;

                var exhibitionID = exhibitions[exhibitionIndex].WystawaID;
                using (var db = new BibliotekaDB())
                {
                    Wystawa exhibitionToModify = db.Wystawa.Find(exhibitionID);

                    ExhibitionAddForm form = new ExhibitionAddForm(exhibitionToModify);
                    if (form.ShowDialog(this) == DialogResult.OK)
                        UpdateExhibitionList();
                }
            }
        }
    }
}
