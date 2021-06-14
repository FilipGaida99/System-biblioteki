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
using System.IO;

namespace BibliotekaService
{
    public partial class Service1 : ServiceBase
    {
        const int hoursInterval = 4;
        static readonly string configFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Config.txt";
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
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("Start.");

            if(!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Config.txt"))
            {
                CreateNewConfigFile();
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
                //TODO rozsyłanie maili
            }
        }

        private void CreateNewConfigFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(configFilePath, false);
                sw.WriteLine("Email:");
                sw.WriteLine("Pasword:");
                sw.WriteLine("Server:");
                sw.Flush();
                sw.Close();
            }
            catch
            {
                eventLog.WriteEntry("Blad tworzenia pliku konfiguracyjnego", EventLogEntryType.Information);
            }
        }
    }
}
