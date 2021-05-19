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
    public partial class ExhibitionDetails : UserControl
    {
        Wystawa exhibition;

        public ExhibitionDetails()
        {
            InitializeComponent();
            exhibition = null;
            nameLabel.Text = "";
            startLabel.Text = "";
            endLabel.Text = "";
            descriptionText.Text = "";
        }

        public void Update(Wystawa _exhibition)
        {
            if (_exhibition == null)
                return;

            exhibition = _exhibition;
            nameLabel.Text = exhibition.Nazwa;
            startLabel.Text = exhibition.Data_rozpoczęcia.ToString();
            endLabel.Text = exhibition.Data_zakończenia.ToString();
            descriptionText.Text = exhibition.Opis;
        }
    }
}
