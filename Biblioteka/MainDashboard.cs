using System;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();
            panelReader.Visible = true;
            panelLibrarian.Visible = false;
        }

        private void exhibitionButton_Click(object sender, EventArgs e)
        {

        }

        private void rentButton_Click(object sender, EventArgs e)
        {

        }

        //Tymczasowy przycisk logowania
        /// <summary>
        /// Obsługa logowania w nowym oknie.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void signButton_Click(object sender, EventArgs e)
        {
            panelReader.Visible = !panelReader.Visible;
            panelLibrarian.Visible = !panelLibrarian.Visible;
        }

        //Niepełny przycisk logowania - brak użytkowników w bazie danych i identyfikacji ich uprawnien
        /*   /// <summary>
        /// Obsługa logowania w nowym oknie.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void signButton_Click(object sender, EventArgs e)
        {
            if (!panelReader.Visible && !panelLibrarian.Visible)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                if (loginForm.accessGranded() == true)
                {
                    signButton.Text = "Wyloguj";
                    if (loginForm.accessUser() == false)
                        panelReader.Visible = true;
                    else
                        panelLibrarian.Visible = true;
                }
            }
            else
            {
                //rozłączenie użytkownika & ?zamknięcie innych otwartych okien?
                panelReader.Visible = false;
                panelLibrarian.Visible = false;
                //sprawdzenie czy superbibliotekarz
                signButton.Text = "Zaloguj";
            }
        }*/

        private void booksManagementButton_Click(object sender, EventArgs e)
        {
            BookManagementForm bookManagement = new BookManagementForm();
            bookManagement.Show();
        }

        private void booksButton_Click(object sender, EventArgs e)
        {
            BookBrowse bookBrowse = new BookBrowse();
            bookBrowse.Show();
        }

        /// <summary>
        /// Otwarcie okna zarządzania czytelnikami.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void readersManagementButton_Click(object sender, EventArgs e)
        {
            ReadersManagmentForm readers = new ReadersManagmentForm();
            readers.Show();
        }

        /// <summary>
        /// Otwarcie okna zarządzania bibliotekarzami.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void librariansManagementButton_Click(object sender, EventArgs e)
        {
            LibrarianManagmentForm librarian = new LibrarianManagmentForm();
            librarian.Show();
        }
    }
}