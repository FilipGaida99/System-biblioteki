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
using System.Data.Entity;

namespace BibliotekaService
{
    /// <summary>
    /// Klasa usługi systemu Windows
    /// </summary>
    public partial class Service1 : ServiceBase
    {
        /// <summary>
        /// Ilość godzin pomiędzy wywołaniami odświeżenia.
        /// </summary>
        const double hoursInterval = 4;
        /// <summary>
        /// Identyfikator w dzienniku zdarzeń dla operacji start i stop.
        /// </summary>
        const int stateInfoID = 0;
        /// <summary>
        /// Identyfikator w dzienniku zdarzeń dla operacji odświeżenia bazy danych.
        /// </summary>
        const int refreshID = 1;
        /// <summary>
        /// Identyfikator w dzienniku zdarzeń dla błędu pliku konfiguracji.
        /// </summary>
        const int configError = 2;
        /// <summary>
        /// Identyfikator w dzienniku zdarzeń dla błędu w obłsudze bazy danych.
        /// </summary>
        const int databaseError = 3;
        /// <summary>
        /// Identyfikator w dzienniku zdarzeń dla błędu w obsłudze mail.
        /// </summary>
        const int emailError = 4;
        /// <summary>
        /// Identyfikator w dzienniku zdarzeń dla informacji o obsłudze mail.
        /// </summary>
        const int emailInfo = 5;
        /// <summary>
        /// Obiekt rozsyłający maile.
        /// </summary>
        private MailSender sender;

        /// <summary>
        /// Konstruktor.
        /// </summary>
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

        /// <summary>
        /// Obsługa rozpoczęcia pracy usługi.
        /// </summary>
        /// <param name="args">Argumenty wiersza poleceń</param>
        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("Start.", EventLogEntryType.Information, stateInfoID);

            try
            {
                sender.OnStart();
            }
            catch
            {
                eventLog.WriteEntry("Błąd tworzenia pliku konfiguracyjnego", EventLogEntryType.Error, configError);
            }

            Timer timer = new Timer();
            timer.Interval = hoursInterval * 60 * 60 * 1000;
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Start();
            Task.Delay(10000).ContinueWith(t => OnTimer(null, null));
        }

        /// <summary>
        /// Obsługa zatrzymania pracy usługi.
        /// </summary>
        protected override void OnStop()
        {
            eventLog.WriteEntry("Stop.");
        }

        /// <summary>
        /// Obsługa cyklicznej pracy usługi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            eventLog.WriteEntry("Odświeżanie kar i powiadomień biblioteki", EventLogEntryType.Information, refreshID);
            try
            {
                RefreshLibrary();
            }
            catch
            {
                eventLog.WriteEntry("Nie można odświeżyć bazy.", EventLogEntryType.Error, databaseError);
            }
        }

        /// <summary>
        /// Odświeżenie kar i powiadomień biblioteki.
        /// </summary>
        private void RefreshLibrary()
        {
            using (var db = new BibliotekaDB())
            {
                Kara.Refresh(db);

                var readers = db.Czytelnik.Where(r => r.Adres_email.Length>0 && r.Czytelnik_Wiadomość.Any(m => !m.Stan.HasValue && !m.Nadawca)).ToList();
                foreach(var reader in readers)
                {
                    string emailBody = "Masz nieprzeczytane wiadomości w swojej bibliotece:\n";
                    var unreadedMessagesToReader = reader.Czytelnik_Wiadomość.Where(m => !m.Stan.HasValue && !m.Nadawca).OrderBy(m => m.Wiadomość.Data_wysłania).ToList();
                    foreach(var messageToReader in unreadedMessagesToReader)
                    {
                        var message = messageToReader.Wiadomość;
                        var librarian = message.Bibliotekarz_Wiadomość.FirstOrDefault().Bibliotekarz;
                        emailBody += $"{librarian.Imię} {librarian.Nazwisko} {message.Data_wysłania}:\n";
                        emailBody += $"{message.Tytuł}\n {message.Treść} \n\n";
                    }

                    try
                    {
                        if(sender.SendMail(reader.Adres_email, $"Wiadomości w bibliotece {DateTime.Now}", emailBody))
                        {
                            eventLog.WriteEntry($"Wysłano maila do {reader.Adres_email} (Identyfikator czytelnika: {reader.CzytelnikID})\n{emailBody}",
                            EventLogEntryType.Information, emailInfo);
                            foreach (var messageToReader in unreadedMessagesToReader)
                            {
                                messageToReader.Stan = 1;
                                db.Entry(messageToReader).State = EntityState.Modified;
                            }
                            db.SaveChanges();
                        }
                    }
                    catch(Exception e)
                    {
                        eventLog.WriteEntry($"Nie można wysłać maila do {reader.Adres_email} (Identyfikator czytelnika: {reader.CzytelnikID})\n{e.Message}", 
                            EventLogEntryType.Error, emailError);
                    }
                }
            }
        }
    }
}
