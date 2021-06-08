using System;
using System.Windows.Forms;

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
                //z jakiegoś powodu where tutaj nie działa
                //Sprawdzenie czy istnieje specjalny bibliotekarz i jeżeli nie to go dodaje do bazy
                //if (db.Bibliotekarz.Where(librarian => librarian.Imię == "Biblioteka")
                //    .First() == null)
                //    db.Bibliotekarz
                //        .Add(new Bibliotekarz { Imię = "Biblioteka" });
                //db.SaveChanges();
                Bibliotekarz librarian = null;
                foreach (var elem in db.Bibliotekarz)
                    if (elem.Imię == "Biblioteka")
                        librarian = elem;
                if(librarian == null)
                {
                    db.Bibliotekarz
                        .Add(new Bibliotekarz { Imię = "Biblioteka" });
                    db.SaveChanges();
                }
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
    }
}
