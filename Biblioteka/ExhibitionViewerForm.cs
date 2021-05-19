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

        private void showButton_Click(object sender, EventArgs e)
        {
            exhibitionDetails1.Update(exhibitions.FirstOrDefault());
            // TODO: show active exhibition from ListBox
        }
    }
}
