using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaService;

namespace testemail
{
    class Program
    {
        static void Main(string[] args)
        {
            MailSender sender = new MailSender();
            sender.OnStart();
            sender.SendMail("fgaida99@outlook.com", "Test2312", "Dupa");
        }
    }
}
