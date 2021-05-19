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

                if (form.managedExhibition == null)
                    return;

                exhibitions.Add(form.managedExhibition);
                UpdateExhibitionList();
            }
        }
    }
}
