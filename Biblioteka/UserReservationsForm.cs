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
    /// <summary>
    /// Formularz pozwalający na przeglądanie rezerwacji czytelnikowi
    /// </summary>
    public partial class UserReservationsForm : Form
    {
        /// <summary>
        /// Lista rezerwacji czytelnika
        /// </summary>
        List<Rezerwacje> userReservations;

        /// <summary>
        /// Kontruktor domyślny
        /// </summary>
        public UserReservationsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ładowanie formlarza
        /// </summary>
        /// <param name="sender"></param> Kontrolka
        /// <param name="e"></param> Argumenty
        private void UserReservationsForm_Load(object sender, EventArgs e)
        {
            using(var db = new BibliotekaDB())
            {
                // TO DO: wpisać zalogowanego użytkownika i usunąć liniję podspodem
                var user = UserSingleton.Instance.GetLoggedUser() as Czytelnik;
                var query = db.Rezerwacje.AsNoTracking().Where(res => res.CzytelnikID == user.CzytelnikID /*loggedUser*/);
                query = query.OrderByDescending(res => res.Data_rezerwacji);
                userReservations = query.ToList();
                UpdateLayoutPanel();
                
            }
        }

        /// <summary>
        /// Aktualizacja panelu na którym wyświetlane są rezerwacje
        /// </summary>
        private void UpdateLayoutPanel()
        {
            using(new AppWaitCursor(ParentForm, null))
            {
                reservationsLayoutPanel.Controls.Clear();
                foreach (var res in userReservations)
                {
                    reservationsLayoutPanel.Controls.Add(new ReservationRecord(res, UpdateLayoutPanel, userReservations));
                }
            }

        }

    }
}
