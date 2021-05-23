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
    public partial class ReaderRecord : UserControl
    {
        /// <summary>
        /// Informacje wyswietlane o czytelniku
        /// </summary>
        Czytelnik reader;
        public ReaderRecord(Czytelnik _reader)
        {
            InitializeComponent();
            reader = _reader;
        }

        private void ReaderRecord_Load(object sender, EventArgs e)
        {
            nameLabel.Text = reader.Imię;
            surnameLabel.Text = reader.Nazwisko;
            phoneLabel.Text = reader.Numer_telefonu.ToString();
            mailLabel.Text = reader.Adres_email;

        }


    }
}
