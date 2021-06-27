using System;
using System.Windows.Forms;
using System.Linq;

namespace Biblioteka
{
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();
            panelReader.Visible = true;
            panelLibrarian.Visible = false;
            using (var db = new BibliotekaDB())
            {
                UserSingleton.Instance.SetReader(db.Czytelnik.FirstOrDefault());
                //Sprawdzenie czy istnieje specjalny bibliotekarz i jeżeli nie to go dodaje do bazy
                if (db.Bibliotekarz.Where(librarian => librarian.Imię == "Biblioteka")
                    .FirstOrDefault() == null)
                    db.Bibliotekarz
                        .Add(new Bibliotekarz { Imię = "Biblioteka" });
                db.SaveChanges();
            }
        }

        private void exhibitionButton_Click(object sender, EventArgs e)
        {
            ExhibitionViewerForm exhibitionViewer = new ExhibitionViewerForm();
            exhibitionViewer.Show();
        }

        private void rentButton_Click(object sender, EventArgs e)
        {
            //TO DO: skasować to poniżej i wstawić id czytelnika
            Czytelnik user = UserSingleton.Instance.GetLoggedUser() as Czytelnik;
            UserCheckoutsViewForm userCheckouts = new UserCheckoutsViewForm(user.CzytelnikID);
            userCheckouts.Show();
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
            BookBrowse bookBrowse = new BookBrowse(null);
            bookBrowse.Show();
        }

        private void messagesButton_Click(object sender, EventArgs e)
        {
            MessageForm messageForm = new MessageForm();
            messageForm.Show();
        }

        private void exhibitionManagementButton_Click(object sender, EventArgs e)
        {
            ExhibitionManagementForm exhibitionManagement = new ExhibitionManagementForm();
            exhibitionManagement.Show();
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            CheckoutForm checkoutWindow = new CheckoutForm();
            checkoutWindow.Show();
        }

        private void bookingButton_Click(object sender, EventArgs e)
        {
            UserReservationsForm reservations = new UserReservationsForm();
            reservations.Show();
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

        private void prolognationButton_Click(object sender, EventArgs e)
        {
            ExtensionForm extension = new ExtensionForm();
            extension.Show();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }

        private void penaltiesButton_Click(object sender, EventArgs e)
        {
            using(var db = new BibliotekaDB())
            {
                Kara.Refresh(db);
            }
        }
    }
}
