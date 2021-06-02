using System;
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
            UserCheckoutsForm userCheckouts = new UserCheckoutsForm();
            userCheckouts.Show();
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

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            CheckoutForm checkoutWindow = new CheckoutForm();
            checkoutWindow.Show();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {

        }

        private void bookingButton_Click(object sender, EventArgs e)
        {
            UserReservationsForm reservations = new UserReservationsForm();
            reservations.Show();
        }
    }
}
