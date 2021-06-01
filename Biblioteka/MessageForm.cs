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

        bool isReader = true; //to pewnie też

        public MessageForm()
        {
            InitializeComponent();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {


            CustomMessageButton asd = new CustomMessageButton(deleteButton_Click);
            asd.Text = "button 1 :)";
            asd.Tag = 1;
            msgListFlowPanel.Controls.Add(asd);
            asd = new CustomMessageButton(deleteButton_Click);
            asd.Text = "button 3 :)";
            asd.Tag = 2;
            msgListFlowPanel.Controls.Add(asd);
            asd = new CustomMessageButton(deleteButton_Click);
            asd.Text = "button 2 :)";
            asd.Tag = 3;
            msgListFlowPanel.Controls.Add(asd);
        }

        private void sendMsgLabel_Click(object sender, EventArgs e)
        {
            WriteMessageForm writeMsgForm = new WriteMessageForm();
            writeMsgForm.Show();
        }

        private void receivedMsgButton_Click(object sender, EventArgs e)
        {

        }

        private void sentMsgButton_Click(object sender, EventArgs e)
        {

        }

        private void msgListFlowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int msgIndex = msgListFlowPanel.Controls.GetChildIndex(((Button)sender).Parent);
        }
    }
}
