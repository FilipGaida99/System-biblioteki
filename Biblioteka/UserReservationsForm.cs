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
    public partial class UserReservationsForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        List<Rezerwacje> userReservations;
        public UserReservationsForm()
        {
            InitializeComponent();
        }

        private void UserReservationsForm_Load(object sender, EventArgs e)
        {
            using(var db = new BibliotekaDB())
            {
                // TO DO: wpisać zalogowanego użytkownika i usunąć liniję podspodem
                var user = db.Czytelnik.Find(10003);
               var query = db.Rezerwacje.AsNoTracking().Where(res => res.CzytelnikID == user.CzytelnikID /*loggedUser*/);
               query = query.OrderByDescending(res => res.Data_rezerwacji);
                userReservations = query.ToList();
                UpdateLayoutPanel();
                
            }
        }

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
