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
    /// <summary>
    /// Klasa obiektu rozsyłającego maile.
    /// </summary>
    public class MailSender
    {
        /// <summary>
        /// Ścieżka pliku konfiguracji
        /// </summary>
        private static readonly string configFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Config.txt";

        /// <summary>
        /// Klucz w plilku konfiguracji dla adresu email.
        /// </summary>
        const string addressKey = "Email";
        /// <summary>
        /// Klucz w plilku konfiguracji dla hasła.
        /// </summary>
        const string passwordKey = "Password";
        /// <summary>
        /// Klucz w plilku konfiguracji dla serwera SMTP.
        /// </summary>
        const string serverKey = "Server";
        /// <summary>
        /// Klucz w plilku konfiguracji dla portu serwera.
        /// </summary>
        const string portKey = "Port";
        /// <summary>
        /// Znak rozdzielający kolejne pary klucz-wartość w pliku konfiguracyjnym. Domyślnie nowa linia.
        /// </summary>
        static readonly string splitChar = Environment.NewLine;
        /// <summary>
        /// Znak rozdzielający klucz od wartości w pliku konfiguracyjnym.
        /// </summary>
        const char assignChar = '=';

        /// <summary>
        /// Odczytany z pliku konfiguracyjnego adres email.
        /// </summary>
        private string fromAddress;
        /// <summary>
        /// Odczytane z pliku konfiguracyjnego hasło.
        /// </summary>
        private string password;
        /// <summary>
        /// Odczytany z pliku konfiguracyjnego serwer SMTP.
        /// </summary>
        private string server;
        /// <summary>
        /// Odczytany z pliku konfiguracyjnego port serwera.
        /// </summary>
        private int? port;

        /// <summary>
        /// Inicializacja po starcie programu.
        /// </summary>
        public void OnStart()
        {
            if (!File.Exists(configFilePath))
            {
                CreateNewConfigFile();
            }
        }

        /// <summary>
        /// Procedura wysłania maila.
        /// </summary>
        /// <param name="toAddress">Adresat.</param>
        /// <param name="subject">Tytuł.</param>
        /// <param name="body">Treść.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Utworzenie nowego pliku konfiguracyjnego.
        /// </summary>
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

        /// <summary>
        /// Odczyt danych z pliku konfiguraycjnego.
        /// </summary>
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
