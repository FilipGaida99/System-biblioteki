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
    public partial class ExhibitionViewerForm : Form
    {
        List<Wystawa> exhibitions;

        public ExhibitionViewerForm()
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
