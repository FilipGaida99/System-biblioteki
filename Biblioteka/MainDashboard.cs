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
            using (var db = new BibliotekaDB())
            {
                UserSingleton.Instance.SetReader(db.Czytelnik.Find(1));
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

        }

        private void rentButton_Click(object sender, EventArgs e)
        {

        }

        private void signButton_Click(object sender, EventArgs e)
        {
            panelReader.Visible = !panelReader.Visible;
            panelLibrarian.Visible = !panelLibrarian.Visible;
        }

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

        private void messagesButton_Click(object sender, EventArgs e)
        {
            MessageForm messageForm = new MessageForm();
            messageForm.Show();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }
    }
}
