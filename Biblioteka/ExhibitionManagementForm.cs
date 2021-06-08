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
    public partial class ExhibitionManagementForm : Form
    {
        List<Wystawa> exhibitions;

        public ExhibitionManagementForm()
        {
            InitializeComponent();
            exhibitions = new List<Wystawa>();
        }

        private void UpdateExhibitionList()
        {
            exhibitionList.BeginUpdate();
            exhibitionList.Items.Clear();
            foreach (var ex in exhibitions)
                exhibitionList.Items.Add(ex.Nazwa);
            exhibitionList.EndUpdate();
        }

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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                int exhibitionIndex = exhibitionList.SelectedIndex;
                if (exhibitionIndex >= 0)
                    DeleteExhibition(exhibitionIndex);
            }
        }

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
