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
    public partial class ReadMessageForm : Form
    {
        public ReadMessageForm(Czytelnik_Wiadomość readerMsg)
        {
            InitializeComponent();
            fromLabel.Text = readerMsg.Czytelnik.Imię + readerMsg.Czytelnik.Nazwisko;
            toLabel.Text = "";
            if (readerMsg.Wiadomość.Bibliotekarz_Wiadomość.First().Bibliotekarz.Imię == Bibliotekarz.specialLibrarianName) {
                if (readerMsg.Nadawca == true)
                    toLabel.Text += "Wszyscy Bibliotekarze, ";
                else
                    toLabel.Text += "System, ";
            }
            else
                foreach (var elem in readerMsg.Wiadomość.Bibliotekarz_Wiadomość)
                    toLabel.Text += elem.Bibliotekarz.Imię + " " + elem.Bibliotekarz.Nazwisko + ", ";
            if (toLabel.Text.Length != 0)
                toLabel.Text = toLabel.Text.Remove(toLabel.Text.Length - 2);
            dateLabel.Text = readerMsg.Wiadomość.Data_wysłania.ToString();
            titleLabel.Text = readerMsg.Wiadomość.Tytuł;
            msgTextBox.Text = readerMsg.Wiadomość.Treść;
        }

        public ReadMessageForm(Bibliotekarz_Wiadomość readerMsg)
        {
            InitializeComponent();

            fromLabel.Text = readerMsg.Bibliotekarz.Imię + readerMsg.Bibliotekarz.Nazwisko;
            toLabel.Text = "";
            if (readerMsg.Wiadomość.Bibliotekarz_Wiadomość.First().Bibliotekarz.Imię == Bibliotekarz.specialLibrarianName)
                toLabel.Text += "Wszyscy Bibliotekarze, ";
            else
                foreach (var elem in readerMsg.Wiadomość.Czytelnik_Wiadomość)
                    toLabel.Text += elem.Czytelnik.Imię + " " + elem.Czytelnik.Nazwisko + ", ";
            if (toLabel.Text.Length != 0)
                toLabel.Text = toLabel.Text.Remove(toLabel.Text.Length - 2);
            dateLabel.Text = readerMsg.Wiadomość.Data_wysłania.ToString();
            titleLabel.Text = readerMsg.Wiadomość.Tytuł;
            msgTextBox.Text = readerMsg.Wiadomość.Treść;
        }
    }
}
