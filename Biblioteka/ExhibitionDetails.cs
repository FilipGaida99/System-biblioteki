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
    /// Control przedstawiający informacje o wystawie do wyświetlenia podczas przeglądania.
    /// </summary>
    public partial class ExhibitionDetails : UserControl
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ExhibitionDetails()
        {
            InitializeComponent();
            nameLabel.Text = "";
            startLabel.Text = "";
            endLabel.Text = "";
            descriptionText.Text = "";
            authorLabel.Text = "";
        }

        /// <summary>
        /// Wyświetlanie konkretnej wystawy.
        /// </summary>
        /// <param name="exhibition">Wystawa do wyświetlenia</param>
        public void Update(Wystawa exhibition)
        {
            if (exhibition == null)
                return;

            nameLabel.Text = exhibition.Nazwa;
            startLabel.Text = exhibition.Data_rozpoczęcia.ToString("dd/MM/yyyy");
            endLabel.Text = exhibition.Data_zakończenia.ToString("dd/MM/yyyy");
            descriptionText.Text = exhibition.Opis;
            Bibliotekarz author = exhibition.Bibliotekarz;
            authorLabel.Text = $"{author.Imię} {author.Nazwisko}";
        }
    }
}
