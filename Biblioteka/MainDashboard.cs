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
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();
        }

        private void exhibitionButton_Click(object sender, EventArgs e)
        {

        }

        private void rentButton_Click(object sender, EventArgs e)
        {

        }

        private void signButton_Click(object sender, EventArgs e)
        {
            panelReader.Visible = !panelReader.Visible;
            panelLibrarian.Visible = !panelLibrarian.Visible;
        }
    }
}
