using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaService
{
    public class MailSender
    {
        private static readonly string configFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Config.txt";

        const string addressKey = "Email";
        const string passwordKey = "Password";
        const string serverKey = "Server";
        const string portKey = "Port";
        static readonly string splitChar = Environment.NewLine;
        const char assignChar = '=';

        private string fromAddress;
        private string password;
        private string server;
        private int? port;

        public void OnStart()
        {
            if (!File.Exists(configFilePath))
            {
                CreateNewConfigFile();
            }
        }

        public bool SendMail(string toAddress, string subject, string body)
        {
            ReadConfigFile();
            MailMessage message = new MailMessage(fromAddress, toAddress, subject, body);
            SmtpClient client = new SmtpClient(server);
            if (port.HasValue)
            {
                client.Port = port.Value;
            }
            client.Credentials = new NetworkCredential(fromAddress, password);
            client.EnableSsl = true;
            client.Send(message);
            return true;
        }

        private void CreateNewConfigFile()
        {
            StreamWriter sw = new StreamWriter(configFilePath, false);
            sw.WriteLine(addressKey + assignChar);
            sw.WriteLine(passwordKey + assignChar);
            sw.WriteLine(serverKey + assignChar);
            sw.WriteLine(portKey + assignChar);
            sw.Flush();
            sw.Close();
        }

        private void ReadConfigFile()
        {
            string configuration = File.ReadAllText(configFilePath);
            var dictionary = configuration.Split(new[] { splitChar }, StringSplitOptions.RemoveEmptyEntries)
               .Select(part => part.Split(assignChar))
               .ToDictionary(split => split[0], split => split[1]);

            fromAddress = dictionary[addressKey];
            password = dictionary[passwordKey];
            server = dictionary[serverKey];
            int _port = 0;
            if(int.TryParse(dictionary[portKey], out _port))
            {
                port = _port;
            }
            else
            {
                port = null;
            }

        }
    }
}
