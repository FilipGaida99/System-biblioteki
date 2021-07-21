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
    /// Kontrolka użytkownika do wyświetlania informacji o czytelnikach
    /// </summary>
    public partial class ReaderRecord : UserControl
    {
        /// <summary>
        /// Informacje wyswietlane o czytelniku
        /// </summary>
        Czytelnik reader;

        /// <summary>
        /// Konstruktor jednoargumentowy
        /// </summary>
        /// <param name="_reader"></param> Obiekt z informacjami o czytelniku
        public ReaderRecord(Czytelnik _reader)
        {
            InitializeComponent();
            reader = _reader;
        }

        /// <summary>
        /// Metoda wywoływana podczas ładowania kontrolki
        /// </summary>
        /// <param name="sender"></param> Kontrolka
        /// <param name="e"></param> Argumenty
        private void ReaderRecord_Load(object sender, EventArgs e)
        {
            nameLabel.Text = reader.Imię;
            surnameLabel.Text = reader.Nazwisko;
            phoneLabel.Text = reader.Numer_telefonu.ToString();
            mailLabel.Text = reader.Adres_email;
            idLabel.Text = reader.CzytelnikID.ToString();
        }

        /// <summary>
        /// Metoda służaca do otwarcia formularza pozwalającego na zarządzanie wypożyczeniami czytelnika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnButton_Click(object sender, EventArgs e)
        {
            UserCheckoutsManagementForm returnForm = new UserCheckoutsManagementForm(reader.CzytelnikID);
            returnForm.Show();
        }

        /// <summary>
        /// Metoda do pozwalająca wypożyczyć książkę danemu czytelnikowi
        /// </summary>
        /// <param name="sender"></param> Kontrolka
        /// <param name="e"></param> Argumenty
        private void checkoutButton_Click(object sender, EventArgs e)
        {
            BookBrowse booksBrowseForm = new BookBrowse(reader.CzytelnikID);
            booksBrowseForm.Show();
        }
    }
}
