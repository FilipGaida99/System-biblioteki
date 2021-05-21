using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Biblioteka
{
    /// <summary>
    /// Formularz logowania.
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Status zalogowania.
        /// </summary>
        private bool access = false;
        /// <summary>
        /// Typ użytkownika.
        /// </summary>
        private bool user = true;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obsługa logowania do systemu.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = "data source=127.0.0.1;initial catalog=Biblioteka;user id=" + boxLogin.Text.ToString() + ";password=" + boxPassword.Text.ToString();
                connection.Open();
                access = true;
            }
#pragma warning disable CS0168 // Zmienna jest zadeklarowana, ale nie jest nigdy używana
            catch (Exception ex)
#pragma warning restore CS0168 // Zmienna jest zadeklarowana, ale nie jest nigdy używana
            {
                MessageBox.Show("Wystąpił błąd podczas logowania");
            }
            Close();
        }

        /// <summary>
        /// Sprawdzenie typu użytkownika.
        /// </summary>
        /// <returns>
        /// Typ użytkownika.
        /// </returns>
        public bool accessUser()
        {
            //check user type - reader/librarian
            return user;
        }

        /// <summary>
        /// Sprawdzenie pomyślnego zalogowania.
        /// </summary>
        /// <returns>
        /// Prawda jeśli zalogowano.
        /// </returns>
        public bool accessGranded()
        {
            return access;
        }
    }
}