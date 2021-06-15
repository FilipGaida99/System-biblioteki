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

        bool isSentMsgView = true;

        public MessageForm()
        {
            InitializeComponent();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            LoadRecievedMessages();
        }

        private void sendMsgButton_Click(object sender, EventArgs e)
        {
            WriteMessageForm writeMsgForm = new WriteMessageForm();
            writeMsgForm.ShowDialog();
            updateMsgListFlowPanel();
        }

        private void updateMsgListFlowPanel()
        {
            //Tylko przy wysłanych wiadomościach może się pojawić nowa
            if (isSentMsgView)
            {
                using (var db = new BibliotekaDB())
                {
                    Wiadomość msg;
                    if ((Czytelnik)UserSingleton.Instance.GetLoggedUser() != null)
                    {
                        Czytelnik reader = db.Czytelnik.Find(((Czytelnik)UserSingleton.Instance.GetLoggedUser()).CzytelnikID);
                        msg = reader
                            .Czytelnik_Wiadomość
                            .OrderByDescending(readerMsg => readerMsg.Wiadomość.Data_wysłania)
                            .FirstOrDefault()
                            .Wiadomość;
                    }
                    else
                    {
                        Bibliotekarz librarian = db.Bibliotekarz.Find(((Bibliotekarz)UserSingleton.Instance.GetLoggedUser()).BibliotekarzID);
                        msg = librarian
                            .Bibliotekarz_Wiadomość
                            .OrderByDescending(librarianMsg => librarianMsg.Wiadomość.Data_wysłania)
                            .FirstOrDefault()
                            .Wiadomość;
                    }
                    if (msg != (Wiadomość)msgListFlowPanel.Controls[0].Tag) //Jeżeli wiadomość została wysłana to znajduje się na pierwszym miejscu
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
            Wiadomość msg = (Wiadomość)((Button)sender).Parent.Tag;
            using (var db = new BibliotekaDB())
            {
                if ((Czytelnik)UserSingleton.Instance.GetLoggedUser() != null)
                {
                    Czytelnik reader = db.Czytelnik.Find(((Czytelnik)UserSingleton.Instance.GetLoggedUser()).CzytelnikID);
                    //reader.Czytelnik_Wiadomość
                    //    .Remove(reader
                    //        .Czytelnik_Wiadomość
                    //        .Where(readerMsg => readerMsg.WiadomośćID == msg.WiadomośćID)
                    //        .FirstOrDefault());
                    Czytelnik_Wiadomość readerMsg = db.Czytelnik_Wiadomość
                        .Single(readerMsgTemp => readerMsgTemp.WiadomośćID == msg.WiadomośćID);
                    if (readerMsg != null)
                        readerMsg.Stan = 2;
                }
                else
                {
                    Bibliotekarz librarian = db.Bibliotekarz.Find(((Bibliotekarz)UserSingleton.Instance.GetLoggedUser()).BibliotekarzID);
                    //librarian.Bibliotekarz_Wiadomość
                    //    .Remove(librarian
                    //        .Bibliotekarz_Wiadomość
                    //        .Where(librarianMsg => librarianMsg.WiadomośćID == librarianMsg.WiadomośćID)
                    //        .FirstOrDefault());
                    Bibliotekarz_Wiadomość librarianMsg = db.Bibliotekarz_Wiadomość
                        .Single(librarianMsgTemp => librarianMsgTemp.WiadomośćID == msg.WiadomośćID);
                    if (librarianMsg != null)
                        librarianMsg.Stan = 2;
                }
                db.SaveChanges();
            }
            msgListFlowPanel.SuspendLayout();
            msgListFlowPanel.Controls.Remove(((Button)sender).Parent);
            msgListFlowPanel.ResumeLayout();

            DeleteLonelyMessage(msg);
        }

        private void DeleteLonelyMessage(Wiadomość msg)
        {
            using (var db = new BibliotekaDB())
            {
                msg = db.Wiadomość.Find(msg.WiadomośćID);
                bool isDeleted = true;
                if (msg.Bibliotekarz_Wiadomość.Count != 0)
                    foreach(var elem in msg.Bibliotekarz_Wiadomość)
                        if (elem.Stan == null || elem.Stan == 1)
                        isDeleted = false;
                if (msg.Czytelnik_Wiadomość.Count != 0)
                foreach (var elem in msg.Czytelnik_Wiadomość)
                        if (elem.Stan == null || elem.Stan == 1)
                            isDeleted = false;
                if (isDeleted)
                {
                    db.Wiadomość.Remove(msg);
                    db.SaveChanges();
                }
            }
        }

        private void MsgButton_Click(object sender, EventArgs e)
        {
            ReadMessageForm readMsgForm;
            if ((Czytelnik)UserSingleton.Instance.GetLoggedUser() != null)
            {
                using (var db = new BibliotekaDB())
                {
                    Czytelnik reader = db.Czytelnik.Find(((Czytelnik)UserSingleton.Instance.GetLoggedUser()).CzytelnikID);
                    Czytelnik_Wiadomość readerMsg = reader
                        .Czytelnik_Wiadomość
                        .Where(readerMsgTemp => readerMsgTemp.Wiadomość.WiadomośćID == ((Wiadomość)((CustomMessageButton)sender).Tag).WiadomośćID)
                        .FirstOrDefault();
                    if (readerMsg.Stan == null)
                    {
                        readerMsg.Stan = 1;
                        db.SaveChanges();
                    }
                    readMsgForm = new ReadMessageForm(readerMsg);
                }
            }
            else
            {
                using (var db = new BibliotekaDB())
                {
                    Bibliotekarz librarian = db.Bibliotekarz.Find(((Bibliotekarz)UserSingleton.Instance.GetLoggedUser()).BibliotekarzID);
                    Bibliotekarz_Wiadomość librarianMsg = (librarian)
                        .Bibliotekarz_Wiadomość
                        .Where(librarianMsgTemp => librarianMsgTemp.Wiadomość == (Wiadomość)((CustomMessageButton)sender).Tag)
                        .FirstOrDefault();
                    if (librarianMsg.Stan == null)
                    {
                        librarianMsg.Stan = 1;
                        db.SaveChanges();
                    }
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
                if ((Czytelnik)UserSingleton.Instance.GetLoggedUser() != null)
                {
                    Czytelnik reader = db.Czytelnik.Find(((Czytelnik)UserSingleton.Instance.GetLoggedUser()).CzytelnikID);
                    msgList = reader
                        .Czytelnik_Wiadomość
                        .OrderBy(readerMsg => readerMsg.Wiadomość.Data_wysłania)
                        .Where(readerMsg => readerMsg.Nadawca == true)
                        .Select(readerMsg => readerMsg.Wiadomość)
                        .ToList();

                    msgListFlowPanel.SuspendLayout();
                    msgListFlowPanel.Controls.Clear();
                    foreach (var elem in msgList)
                    {
                        Czytelnik_Wiadomość readerMsg = elem.Czytelnik_Wiadomość
                            .SingleOrDefault(readerTemp => readerTemp.CzytelnikID == reader.CzytelnikID);
                        if (readerMsg.Stan == 2)
                            continue;
                        CustomMessageButton msg = new CustomMessageButton(DeleteButton_Click, elem);
                        msg.Tag = elem;
                        msg.Click += MsgButton_Click;
                        msgListFlowPanel.Controls.Add(msg);
                    }
                    msgListFlowPanel.ResumeLayout();
                }
                else
                {
                    Bibliotekarz librarian = db.Bibliotekarz.Find(((Bibliotekarz)UserSingleton.Instance.GetLoggedUser()).BibliotekarzID);
                    msgList = librarian
                        .Bibliotekarz_Wiadomość
                        .OrderBy(librarianMsg => librarianMsg.Wiadomość.Data_wysłania)
                        .Where(librarianMsg => librarianMsg.Nadawca == true)
                        .Select(librarianMsg => librarianMsg.Wiadomość)
                        .ToList();

                    msgListFlowPanel.SuspendLayout();
                    msgListFlowPanel.Controls.Clear();
                    foreach (var elem in msgList)
                    {
                        Bibliotekarz_Wiadomość librarianMsg = elem.Bibliotekarz_Wiadomość
                            .SingleOrDefault(librarianTemp => librarianTemp.BibliotekarzID == librarian.BibliotekarzID);
                        if (librarianMsg.Stan == 2)
                            continue; //Jeżeli stan wiadomośći jest 2 (czyli usunięta) to nie wyświetlaj jej
                        CustomMessageButton msg = new CustomMessageButton(DeleteButton_Click, elem);
                        msg.Tag = elem;
                        msg.Click += MsgButton_Click;
                        msgListFlowPanel.Controls.Add(msg);
                    }
                    msgListFlowPanel.ResumeLayout();
                }
                //msgListFlowPanel.SuspendLayout();
                //msgListFlowPanel.Controls.Clear();
                //foreach (var elem in msgList)
                //{
                //    CustomMessageButton msg = new CustomMessageButton(DeleteButton_Click, elem);
                //    msg.Tag = elem;
                //    msg.Click += MsgButton_Click;
                //    msgListFlowPanel.Controls.Add(msg);
                //}
                //msgListFlowPanel.ResumeLayout();
            }
        }

        private void LoadRecievedMessages()
        {
            using (var db = new BibliotekaDB())
            {
                List<Wiadomość> msgList;
                if ((Czytelnik)UserSingleton.Instance.GetLoggedUser() != null)
                {
                    Czytelnik reader = db.Czytelnik.Find(((Czytelnik)UserSingleton.Instance.GetLoggedUser()).CzytelnikID);
                    msgList = reader
                        .Czytelnik_Wiadomość
                        .OrderBy(readerMsg => readerMsg.Wiadomość.Data_wysłania)
                        .Where(readerMsg => readerMsg.Nadawca == false)
                        .Select(readerMsg => readerMsg.Wiadomość)
                        .ToList();

                    msgListFlowPanel.SuspendLayout();
                    msgListFlowPanel.Controls.Clear();
                    foreach (var elem in msgList)
                    {
                        Czytelnik_Wiadomość readerMsg = elem.Czytelnik_Wiadomość
                            .SingleOrDefault(readerTemp => readerTemp.CzytelnikID == reader.CzytelnikID);
                        if (readerMsg.Stan == 2)
                            continue;
                        CustomMessageButton msg = new CustomMessageButton(DeleteButton_Click, elem, readerMsg.Stan);
                        msg.Tag = elem;
                        msg.Click += MsgButton_Click;
                        msgListFlowPanel.Controls.Add(msg);
                    }
                    msgListFlowPanel.ResumeLayout();
                }
                else
                {
                    Bibliotekarz librarian = db.Bibliotekarz.Find(((Bibliotekarz)UserSingleton.Instance.GetLoggedUser()).BibliotekarzID);
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

                    msgListFlowPanel.SuspendLayout();
                    msgListFlowPanel.Controls.Clear();
                    foreach (var elem in msgList)
                    {
                        Bibliotekarz_Wiadomość librarianMsg = elem.Bibliotekarz_Wiadomość
                            .SingleOrDefault(librarianTemp => librarianTemp.BibliotekarzID == librarian.BibliotekarzID);
                        if (librarianMsg.Stan == 2)
                            continue; //Jeżeli stan wiadomośći jest 2 (czyli usunięta) to nie wyświetlaj jej
                        CustomMessageButton msg = new CustomMessageButton(DeleteButton_Click, elem, librarianMsg.Stan);
                        msg.Tag = elem;
                        msg.Click += MsgButton_Click;
                        msgListFlowPanel.Controls.Add(msg);
                    }
                    msgListFlowPanel.ResumeLayout();
                }
                //msgListFlowPanel.SuspendLayout();
                //msgListFlowPanel.Controls.Clear();
                //foreach (var elem in msgList)
                //{
                //    CustomMessageButton msg = new CustomMessageButton(DeleteButton_Click, elem);
                //    msg.Tag = elem;
                //    msg.Click += MsgButton_Click;
                //    msgListFlowPanel.Controls.Add(msg);
                //}
                //msgListFlowPanel.ResumeLayout();
            }
        }
    }
}
