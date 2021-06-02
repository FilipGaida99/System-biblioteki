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
    public partial class MessageForm : Form
    {

        Czytelnik reader; //raczej do zmiany gdy ogarniemy jak chcemy przechowywać zalogowanego użytkownika

        Bibliotekarz librarian; //tu tak samo

        bool IsReader = true; //to pewnie też

        bool isSentMsgView = true;

        public MessageForm()
        {
            InitializeComponent();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            LoadSentMessages();
        }

        private void sendMsgLabel_Click(object sender, EventArgs e)
        {
            WriteMessageForm writeMsgForm = new WriteMessageForm();
            writeMsgForm.ShowDialog();
            updateMsgListFlowPanel();
        }

        private void updateMsgListFlowPanel()
        {
            if (!isSentMsgView)
            {
                using (var db = new BibliotekaDB())
                {
                    reader = db.Czytelnik.Find(1);
                    Wiadomość msg = reader.Czytelnik_Wiadomość
                        .OrderByDescending(readerMsg => readerMsg.Wiadomość.Data_wysłania)
                        .FirstOrDefault()
                        .Wiadomość;
                    if (msg != (Wiadomość)msgListFlowPanel.Controls[0].Tag)
                    {
                        CustomMessageButton msgButton = new CustomMessageButton(DeleteButton_Click, msg);
                        msgButton.Tag = msg;
                        msgListFlowPanel.SuspendLayout();
                        msgListFlowPanel.Controls.Add(msgButton);
                        msgListFlowPanel.Controls.SetChildIndex(msgButton, 0);
                        msgListFlowPanel.ResumeLayout();
                    }
                }
            }
        }

        private void receivedMsgButton_Click(object sender, EventArgs e)
        {
            //if (isSentMsgView)
            //    return;
            isSentMsgView = true;
            LoadRecievedMessages();
        }

        private void sentMsgButton_Click(object sender, EventArgs e)
        {
            //if (!isSentMsgView)
            //    return;
            isSentMsgView = false;
            LoadSentMessages();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Wiadomość msg = (Wiadomość)((CustomMessageButton)sender).Tag;
            using (var db = new BibliotekaDB())
            {
                if (IsReader)
                {
                    reader = db.Czytelnik.Find(1);
                    reader.Czytelnik_Wiadomość
                        .Remove(reader.Czytelnik_Wiadomość
                            .Where(readerMsg => readerMsg.WiadomośćID == msg.WiadomośćID)
                            .FirstOrDefault());
                }
                else
                {
                    librarian = db.Bibliotekarz.Find(1);
                    librarian.Bibliotekarz_Wiadomość
                        .Remove(librarian.Bibliotekarz_Wiadomość
                            .Where(librarianMsg => librarianMsg.WiadomośćID == librarianMsg.WiadomośćID)
                            .FirstOrDefault());
                }
                db.SaveChanges();
            }
            msgListFlowPanel.SuspendLayout();
            msgListFlowPanel.Controls.Remove((CustomMessageButton)sender);
            msgListFlowPanel.ResumeLayout();

            DeleteLonelyMessage(msg);
        }

        private void DeleteLonelyMessage(Wiadomość msg)
        {
            using (var db = new BibliotekaDB())
            {
                msg = db.Wiadomość.Find(msg);
                if (msg.Bibliotekarz_Wiadomość.Count == 0 && msg.Czytelnik_Wiadomość.Count == 0)
                    db.Wiadomość.Remove(msg);
                db.SaveChanges();
            }
        }

        private void MsgButton_Click(object sender, EventArgs e)
        {
            ReadMessageForm readMsgForm;
            if (IsReader)
            {
                using (var db = new BibliotekaDB())
                {
                    reader = db.Czytelnik.Find(1);
                    Czytelnik_Wiadomość readerMsg = reader.Czytelnik_Wiadomość
                        .Where(readerMsgTemp => readerMsgTemp.Wiadomość == (Wiadomość)((CustomMessageButton)sender).Tag)
                        .FirstOrDefault();
                    readMsgForm = new ReadMessageForm(readerMsg);
                }
            }
            else
            {
                using (var db = new BibliotekaDB())
                {
                    librarian = db.Bibliotekarz.Find(1);
                    Bibliotekarz_Wiadomość librarianMsg = librarian.Bibliotekarz_Wiadomość
                        .Where(librarianMsgTemp => librarianMsgTemp.Wiadomość == (Wiadomość)((CustomMessageButton)sender).Tag)
                        .FirstOrDefault();
                    readMsgForm = new ReadMessageForm(librarianMsg);
                }
            }
            readMsgForm.ShowDialog();
        }

        private void LoadSentMessages()
        {
            using (var db = new BibliotekaDB())
            {
                List<Wiadomość> msgList;
                if (IsReader)
                {
                    reader = db.Czytelnik.Find(1);
                    msgList = reader
                        .Czytelnik_Wiadomość
                        .OrderBy(readerMsg => readerMsg.Wiadomość.Data_wysłania)
                        .Where(readerMsg => readerMsg.Nadawca == true)
                        .Select(readerMsg => readerMsg.Wiadomość)
                        .ToList();
                }
                else
                {
                    librarian = db.Bibliotekarz.Find(1);
                    msgList = librarian
                        .Bibliotekarz_Wiadomość
                        .OrderBy(librarianMsg => librarianMsg.Wiadomość.Data_wysłania)
                        .Where(librarianMsg => librarianMsg.Nadawca == true)
                        .Select(librarianMsg => librarianMsg.Wiadomość)
                        .ToList();
                }
                msgListFlowPanel.SuspendLayout();
                msgListFlowPanel.Controls.Clear();
                foreach (var elem in msgList)
                {
                    CustomMessageButton msg = new CustomMessageButton(DeleteButton_Click, elem);
                    msg.Tag = elem;
                    msgListFlowPanel.Controls.Add(msg);
                }
                msgListFlowPanel.ResumeLayout();
            }
        }

        private void LoadRecievedMessages()
        {
            using (var db = new BibliotekaDB())
            {
                List<Wiadomość> msgList;
                if (IsReader)
                {
                    reader = db.Czytelnik.Find(1);
                    msgList = reader
                        .Czytelnik_Wiadomość
                        .OrderBy(readerMsg => readerMsg.Wiadomość.Data_wysłania)
                        .Where(readerMsg => readerMsg.Nadawca == false)
                        .Select(readerMsg => readerMsg.Wiadomość)
                        .ToList();
                }
                else
                {
                    librarian = db.Bibliotekarz.Find(1);

                    List<Wiadomość> allLibrariansMsgList = db.Bibliotekarz_Wiadomość
                        .Where(librarianMsg => librarianMsg.BibliotekarzID == 0)
                        .Select(librarianMsg => librarianMsg.Wiadomość)
                        .ToList();

                    msgList = librarian
                        .Bibliotekarz_Wiadomość
                        .Where(librarianMsg => librarianMsg.Nadawca == false)
                        .Select(librarianMsg => librarianMsg.Wiadomość)
                        .ToList();

                    msgList.AddRange(allLibrariansMsgList);
                    msgList.OrderBy(librarianMsg => librarianMsg.Data_wysłania);
                }
                msgListFlowPanel.SuspendLayout();
                msgListFlowPanel.Controls.Clear();
                foreach (var elem in msgList)
                {
                    CustomMessageButton msg = new CustomMessageButton(DeleteButton_Click, elem);
                    msg.Tag = elem;
                    msgListFlowPanel.Controls.Add(msg);
                }
                msgListFlowPanel.ResumeLayout();
            }
        }
    }
}
