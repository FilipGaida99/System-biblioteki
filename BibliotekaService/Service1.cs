using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;
using System.Timers;

namespace BibliotekaService
{
    public partial class Service1 : ServiceBase
    {
        const int hoursInterval = 1;
        private MailSender sender;

        public Service1()
        {
            InitializeComponent();
            eventLog = new EventLog();
            if (!EventLog.SourceExists("BibliotekaPubliczna"))
            {
                EventLog.CreateEventSource(
                    "BibliotekaPubliczna", "BibliotekaLog");
            }
            eventLog.Source = "BibliotekaPubliczna";
            eventLog.Log = "BibliotekaLog";
            sender = new MailSender();
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("Start.");

            try
            {
                sender.OnStart();
            }
            catch
            {
                eventLog.WriteEntry("Blad tworzenia pliku konfiguracyjnego", EventLogEntryType.Error);
            }

            RefreshLibrary();
            Timer timer = new Timer();
            timer.Interval = hoursInterval * 60 * 60 * 1000;
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            eventLog.WriteEntry("Stop.");
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            eventLog.WriteEntry("Odswiezanie kar i powiadomien biblioteki", EventLogEntryType.Information);
            RefreshLibrary();
        }

        private void RefreshLibrary()
        {
            using (var db = new BibliotekaDB())
            {
                Kara.Refresh(db);

                var readers = db.Czytelnik.Where(r => r.Czytelnik_Wiadomość.Any(m => !m.Przeczytana && !m.Nadawca)).ToList();
                foreach(var reader in readers)
                {
                    string emailBody = "Masz nieprzeczytane wiadomości w swojej bibliotece:\n";
                    var unreadedMessagesToReader = reader.Czytelnik_Wiadomość.Where(m => !m.Przeczytana && !m.Nadawca).OrderBy(m => m.Wiadomość.Data_wysłania).ToList();
                    foreach(var messageToReader in unreadedMessagesToReader)
                    {
                        var message = messageToReader.Wiadomość;
                        var librarian = message.Bibliotekarz_Wiadomość.FirstOrDefault().Bibliotekarz;
                        emailBody += $"{librarian.Imię} {librarian.Nazwisko} {message.Data_wysłania}:\n";
                        emailBody += $"{message.Tytuł}\n {message.Treść} \n\n";
                    }

                    sender.SendMail(reader.Adres_email, $"Wiadomości w bibliotece {DateTime.Now}", emailBody);
                }
            }
        }
    }
}
