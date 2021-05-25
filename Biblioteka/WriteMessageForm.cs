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
    public partial class WriteMessageForm : Form
    {

        List<object> availableList;

        List<object> chosenList;

        Czytelnik reader; //raczej do zmiany gdy ogarniemy jak chcemy przechowywać zalogowanego użytkownika

        Bibliotekarz librarian; //tu tak samo

        bool isReader = true; //to pewnie też

        public WriteMessageForm()
        {
            InitializeComponent();
        }

        private void addAddresseeButton_Click(object sender, EventArgs e)
        {
            AddresseeSelectionForm adSelFrom = new AddresseeSelectionForm(availableList.Cast<Bibliotekarz>().ToList(),
                chosenList.Cast<Bibliotekarz>().ToList());
            adSelFrom.Show();

            availableList = adSelFrom.GetAvailableList();
            chosenList = adSelFrom.GetChosenList();

            UpdateAddresseeLabel();
        }

        private void UpdateAddresseeLabel()
        {
            if (isReader)
            {
                addresseeLabel.Text = "";
                foreach (var elem in chosenList.Cast<Bibliotekarz>())
                    addresseeLabel.Text += elem.Imię + " " + elem.Nazwisko + ", ";
                addresseeLabel.Text.Remove(addresseeLabel.Text.Length - 2);
            }
        }

        private void WriteMessageForm_Load(object sender, EventArgs e)
        {
            
            using (var db = new BibliotekaDB())
            {
                if (isReader)
                {
                    chosenList = new List<Bibliotekarz>().Cast<object>().ToList();
                    availableList = db.Bibliotekarz.OrderBy(librarian => librarian.Nazwisko).ToList()
                        .Cast<object>()
                        .ToList();
                    Bibliotekarz allLibrarians = new Bibliotekarz();
                    allLibrarians.Imię = "Wszyscy";
                    allLibrarians.Nazwisko = "bibliotekarze";
                    allLibrarians.BibliotekarzID = 0;
                    availableList.Insert(0, (object)allLibrarians);
                }
                else
                {
                    chosenList = new List<Czytelnik>().Cast<object>().ToList();

                    availableList = db.Czytelnik.OrderBy(librarian => librarian.Nazwisko).ToList()
                        .Cast<object>()
                        .ToList();
                }
            }
        }

        private void sendMsgButton_Click(object sender, EventArgs e)
        {
            if(msgTitleTextBox.TextLength != 0)
            {
                if (msgContentTextBox.TextLength != 0)
                {
                    Wiadomość msg = new Wiadomość();
                    //msg.Tytuł = msgTitleTextBox.Text; //Brakuje tytułu w encji wiadomości
                    msg.Treść = msgContentTextBox.Text;
                    //TO DO: nie wiem jak się te entity obsługuje lmao
                }
                else
                {
                    MessageBox.Show("Nie można wysłać wiadomości!\n Treść wiadomości jest pusta!",
                          "Pusta treść wiadomości",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie można wysłać wiadomości!\n Tytuł jest pusty!",
                           "Pusty tytuł",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
            }
        }

        private void cancelMsgButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
