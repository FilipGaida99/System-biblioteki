using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotekaModel;

namespace Biblioteka
{
    /// <summary>
    /// Formularz wysyłania wiadomości.
    /// </summary>
    public partial class WriteMessageForm : Form
    {


        /// <summary>
        /// Objekt do wyciągania list adresatów.
        /// </summary>
        IUsersSelectionGetter userLists;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public WriteMessageForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obsługa dodania adresatów wiadomości.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void AddAddresseeButton_Click(object sender, EventArgs e)
        {
            AddresseeSelectionForm adSelFrom = new AddresseeSelectionForm((UsersSelection)userLists);
            adSelFrom.ShowDialog();

            UpdateAddresseeLabel();
        }

        /// <summary>
        /// Zaktualizowanie labela adresatów na podstawie listy.
        /// </summary>
        private void UpdateAddresseeLabel()
        {
            if (UserSingleton.Instance.GetLoggedUser() as Czytelnik != null)
            {
                addresseeLabel.Text = "";
                foreach (var elem in userLists.GetChosenLibrariansList())
                    addresseeLabel.Text += elem.Imię + " " + elem.Nazwisko + ", ";
                if(addresseeLabel.Text.Length != 0)
                    addresseeLabel.Text = addresseeLabel.Text.Remove(addresseeLabel.Text.Length - 2);
            }
            else
            {
                addresseeLabel.Text = "";
                foreach (var elem in userLists.GetChosenReadersList())
                    addresseeLabel.Text += elem.Imię + " " + elem.Nazwisko + ", ";
                if (addresseeLabel.Text.Length != 0)
                    addresseeLabel.Text = addresseeLabel.Text.Remove(addresseeLabel.Text.Length - 2);
            }
        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void WriteMessageForm_Load(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                if (UserSingleton.Instance.GetLoggedUser() as Czytelnik != null)
                {
                    List<Bibliotekarz> availableList = db.Bibliotekarz
                        .Where(librarian => librarian.Imię != Bibliotekarz.specialLibrarianName)
                        .OrderBy(librarian => librarian.Nazwisko)
                        .ToList();
                    
                    Bibliotekarz allLibrarians = new Bibliotekarz();//Pseudo bibliotekarz reprezentujący wysłanie maila do wszystkich bibliotekarzy
                    allLibrarians.Imię = "Wszyscy";
                    allLibrarians.Nazwisko = "bibliotekarze";
                    allLibrarians.BibliotekarzID = 0;
                    availableList.Insert(0, allLibrarians);

                    userLists = UsersSelection.MakeUsersSelection(availableList, new List<Bibliotekarz>());
                    
                }
                else
                {
                    //librarian = db.Bibliotekarz.Find(1);
                    userLists = UsersSelection.MakeUsersSelection(db.Czytelnik
                        .OrderBy(librarian => librarian.Nazwisko)
                        .ToList(),
                            new List<Czytelnik>());
                }
            }
        }

        /// <summary>
        /// Obsługa wysłania wiadomości i zamknięcia formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void SendMsgButton_Click(object sender, EventArgs e)
        {
            if(msgTitleTextBox.TextLength != 0)
            {
                if (msgContentTextBox.TextLength != 0)
                {
                    if (userLists.GetChosenListCount() != 0)
                    {
                        Wiadomość msg = new Wiadomość();
                        msg.Tytuł = msgTitleTextBox.Text;
                        msg.Treść = msgContentTextBox.Text;
                        msg.Data_wysłania = DateTime.Now;

                        using (var db = new BibliotekaDB())
                        {
                            db.Wiadomość.Add(msg);

                            if (UserSingleton.Instance.GetLoggedUser() as Czytelnik != null)
                            {
                                db.Czytelnik_Wiadomość.Add(new Czytelnik_Wiadomość 
                                    { CzytelnikID = ((Czytelnik)UserSingleton.Instance.GetLoggedUser()).CzytelnikID,
                                        Nadawca = true, WiadomośćID = msg.WiadomośćID });

                                foreach (var elem in userLists.GetChosenLibrariansList())
                                {
                                    if(elem.BibliotekarzID == 0)
                                    {
                                        Bibliotekarz specialLibrarian = db.Bibliotekarz
                                        .Where(librarian => librarian.Imię == Bibliotekarz.specialLibrarianName)
                                        .First();
                                        db.Bibliotekarz_Wiadomość.Add(new Bibliotekarz_Wiadomość
                                            { BibliotekarzID = specialLibrarian.BibliotekarzID, Nadawca = false, WiadomośćID = msg.WiadomośćID });
                                    }
                                    else
                                        db.Bibliotekarz_Wiadomość.Add(new Bibliotekarz_Wiadomość
                                            { BibliotekarzID = elem.BibliotekarzID, Nadawca = false, WiadomośćID = msg.WiadomośćID });
                                }
                            }
                            else
                            {
                                db.Bibliotekarz_Wiadomość.Add(new Bibliotekarz_Wiadomość 
                                    { BibliotekarzID = ((Bibliotekarz)UserSingleton.Instance.GetLoggedUser()).BibliotekarzID,
                                        Nadawca = true, WiadomośćID = msg.WiadomośćID });

                                foreach (var elem in userLists.GetChosenReadersList())
                                    db.Czytelnik_Wiadomość.Add(new Czytelnik_Wiadomość 
                                        { CzytelnikID = elem.CzytelnikID, Nadawca = false, WiadomośćID = msg.WiadomośćID });
                            }
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie można wysłać wiadomości!\n Brak adresatów wiadomości!",
                          "Brak adresatów",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nie można wysłać wiadomości!\n Treść wiadomości jest pusta!",
                          "Pusta treść",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Nie można wysłać wiadomości!\n Tytuł jest pusty!",
                           "Pusty tytuł",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }

        /// <summary>
        /// Obsługa zamknięcia formularza bez wysłania wiadomości.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void CancelMsgButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
    /// <summary>
    /// Klasa obsługująca listy wybranych oraz dostępnych adresatów.
    /// </summary>
    public abstract class UsersSelection : IUsersSelectionGetter
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        private UsersSelection() { }

        /// <summary>
        /// Przenieś użytkownika z listy dostępnych do listy wybranych.
        /// </summary>
        /// <param name="str">Nazwa użytkownika oraz jego id.</param>
        abstract public void MoveUserRight(string str);

        /// <summary>
        /// Przenieś użytkownika z listy wybranych do listy dostępnych.
        /// </summary>
        /// <param name="str">Nazwa użytkownika oraz jego id.</param>
        abstract public void MoveUserLeft(string str);

        /// <summary>
        /// Zaktualizuj listy użytkowników kopiami roboczymi.
        /// </summary>
        abstract public void UpdateLists();

        /// <summary>
        /// Pobierz listę stringów dostępnych użytkowników.
        /// </summary>
        /// <param name="filter">Wzór do filtrowania listy.</param>
        /// <returns>Lista stringów dostępnych użytkowników.</returns>
        abstract public List<string> GetAvailableListStr(string filter);

        /// <summary>
        /// Pobierz listę stringów wybranych użytkowników.
        /// </summary>
        /// <param name="filter">Wzór do filtrowania listy.</param>
        /// <returns>Lista stringów wybranych użytkowników.</returns>
        abstract public List<string> GetChosenListStr(string filter);

        /// <summary>
        /// Pobierz listę dostępnych czytelników.
        /// </summary>
        /// <returns>Lista czytelników.</returns>
        abstract public List<Czytelnik> GetAvailableReadersList();

        /// <summary>
        /// Pobierz listę wybranych czytelników.
        /// </summary>
        /// <returns>Lista czytelników.</returns>
        abstract public List<Czytelnik> GetChosenReadersList();

        /// <summary>
        /// Pobierz listę dostępnych bibliotekarzy.
        /// </summary>
        /// <returns>Lista bibliotekarzy.</returns>
        abstract public List<Bibliotekarz> GetAvailableLibrariansList();

        /// <summary>
        /// Pobierz listę wybranych bibliotekarzy.
        /// </summary>
        /// <returns>Lista bibliotekarzy.</returns>
        abstract public List<Bibliotekarz> GetChosenLibrariansList();

        /// <summary>
        /// Pobierz ilość wybranych użytkowników.
        /// </summary>
        /// <returns>Ilość wybranych użytkowników.</returns>
        abstract public int GetChosenListCount();

        /// <summary>
        /// Klasa obsługująca listy wybranych oraz dostępnych czytelników adresatów.
        /// </summary>
        private sealed class ReadersSelection : UsersSelection
        {
            /// <summary>
            /// Zatwierdzona lista dostępnych czytelników.
            /// </summary>
            List<Czytelnik> availableListRef;

            /// <summary>
            /// Zatwierdzona lista wybranych czytelników.
            /// </summary>
            List<Czytelnik> chosenListRef;

            /// <summary>
            /// Robocza lista dostępnych czytelników.
            /// </summary>
            List<Czytelnik> availableList;

            /// <summary>
            /// Robocza lista wybranych czytelników.
            /// </summary>
            List<Czytelnik> chosenList;

            /// <summary>
            /// Konstruktor.
            /// </summary>
            /// <param name="availableList">Lista dostępnych czytelników.</param>
            /// <param name="chosenList">Lista wybranych czytelników.</param>
            public ReadersSelection(List<Czytelnik> availableList, List<Czytelnik> chosenList)
            {
                this.availableListRef = availableList;
                this.chosenListRef = chosenList;

                this.availableList = new List<Czytelnik>(availableList);
                this.chosenList = new List<Czytelnik>(chosenList);
            }

            /// <summary>
            /// Znajdź i pobierz ID czytelnika z jego nazwy.
            /// </summary>
            /// <param name="str">Nazwa czytelnika.</param>
            /// <returns>ID czytelnika.</returns>
            private int FindIDInString(string str)
            {
                str = str
                    .Split()
                    .Last()
                    .Trim("()".ToCharArray());
                return Int32.Parse(str);
            }

            /// <summary>
            /// Przenieś czytelnika z listy dostępnych do listy wybranych.
            /// </summary>
            /// <param name="str">Nazwa czytelnika oraz jego id.</param>
            override public void MoveUserRight(string str)
            {
                int id = FindIDInString(str);
                int index = availableList.FindIndex(librarian => librarian.CzytelnikID == id);

                chosenList.Add(availableList[index]);
                chosenList.Sort((x, y) => x.Nazwisko.CompareTo(y));
                availableList.RemoveAt(index);
            }

            /// <summary>
            /// Przenieś czytelnika z listy wybranych do listy dostępnych.
            /// </summary>
            /// <param name="str">Nazwa czytelnika oraz jego id.</param>
            override public void MoveUserLeft(string str)
            {
                int id = FindIDInString(str);
                int index = chosenList.FindIndex(librarian => librarian.CzytelnikID == id);

                availableList.Add(chosenList[index]);
                availableList.Sort((x, y) => x.Nazwisko.CompareTo(y));
                chosenList.RemoveAt(index);
            }

            /// <summary>
            /// Zaktualizuj listy czytelników kopiami roboczymi.
            /// </summary>
            override public void UpdateLists()
            {
                availableListRef = availableList;
                chosenListRef = chosenList;
            }

            /// <summary>
            /// Pobierz listę stringów dostępnych czytelników.
            /// </summary>
            /// <param name="filter">Wzór do filtrowania listy.</param>
            /// <returns>Lista stringów dostępnych czytelników.</returns>
            override public List<string> GetAvailableListStr(string filter)
            {
                List<string> namesList = new List<string>();
                foreach (var elem in availableList)
                {
                    string str = $"{elem.Imię} {elem.Nazwisko} ({elem.CzytelnikID})";
                    if (filter.Length == 0 || str.ToLower().Contains(filter.ToLower()))
                        namesList.Add(str);
                }
                return namesList;
            }

            /// <summary>
            /// Pobierz listę stringów wybranych czytelników.
            /// </summary>
            /// <param name="filter">Wzór do filtrowania listy.</param>
            /// <returns>Lista stringów wybranych czytelników.</returns>
            override public List<string> GetChosenListStr(string filter)
            {
                List<string> namesList = new List<string>();
                foreach (var elem in chosenList)
                {
                    string str = $"{elem.Imię} {elem.Nazwisko} ({elem.CzytelnikID})";
                    if (filter.Length == 0 || str.ToLower().Contains(filter.ToLower()))
                        namesList.Add(str);
                }
                return namesList;
            }

            /// <summary>
            /// Pobierz listę dostępnych czytelników.
            /// </summary>
            /// <returns>Lista czytelników.</returns>
            override public List<Czytelnik> GetAvailableReadersList()
            {
                return availableListRef;
            }

            /// <summary>
            /// Pobierz listę wybranych czytelników.
            /// </summary>
            /// <returns>Lista czytelników.</returns>
            override public List<Czytelnik> GetChosenReadersList()
            {
                return chosenListRef;
            }

            /// <summary>
            /// Metoda niedostępna dla tej klasy.
            /// </summary>
            /// <returns>null.</returns>
            override public List<Bibliotekarz> GetAvailableLibrariansList()
            {
                return null;
            }

            /// <summary>
            /// Metoda niedostępna dla tej klasy.
            /// </summary>
            /// <returns>null.</returns>
            override public List<Bibliotekarz> GetChosenLibrariansList()
            {
                return null;
            }

            /// <summary>
            /// Pobierz ilość wybranych użytkowników.
            /// </summary>
            /// <returns>Ilość wybranych użytkowników.</returns>
            override public int GetChosenListCount() {
                return chosenListRef.Count;
            }
        }

        /// <summary>
        /// Klasa obsługująca listy wybranych oraz dostępnych bibliotekarzy adresatów.
        /// </summary>
        private sealed class LibrariansSelection : UsersSelection
        {
            /// <summary>
            /// Zatwierdzona lista dostępnych bibliotekarzy.
            /// </summary>
            List<Bibliotekarz> availableListRef;

            /// <summary>
            /// Zatwierdzona lista wybranych bibliotekarzy.
            /// </summary>
            List<Bibliotekarz> chosenListRef;

            /// <summary>
            /// Robocza lista dostępnych bibliotekarzy.
            /// </summary>
            List<Bibliotekarz> availableList;

            /// <summary>
            /// Robocza lista wybranych bibliotekarzy.
            /// </summary>
            List<Bibliotekarz> chosenList;

            /// <summary>
            /// Konstruktor.
            /// </summary>
            /// <param name="availableList">Lista dostępnych bibliotekarzy.</param>
            /// <param name="chosenList">Lista wybranych bibliotekarzy.</param>
            public LibrariansSelection(List<Bibliotekarz> availableList, List<Bibliotekarz> chosenList)
            {
                this.availableListRef = availableList;
                this.chosenListRef = chosenList;

                this.availableList = new List<Bibliotekarz>(availableList);
                this.chosenList = new List<Bibliotekarz>(chosenList);
            }

            /// <summary>
            /// Znajdź i pobierz ID bibliotekarza z jego nazwy.
            /// </summary>
            /// <param name="str">Nazwa bibliotekarza.</param>
            /// <returns>ID bibliotekarza.</returns>
            private int FindIDInString(string str)
            {
                if (str.Last() != ')') //Jeżeli stringiem są wszyscy bibliotekarze
                    return 0;

                str = str
                    .Split()
                    .Last()
                    .Trim("()".ToCharArray());
                return Int32.Parse(str);
            }


            /// <summary>
            /// Przenieś bibliotekarza z listy dostępnych do listy wybranych.
            /// </summary>
            /// <param name="str">Nazwa czytelnika oraz jego id.</param>
            override public void MoveUserRight(string str)
            {
                int id = FindIDInString(str);
                int index;
                if (id == 0)
                    index = 0;
                else
                    index = availableList.FindIndex(librarian => librarian.BibliotekarzID == id);
                //Jeżeli wybrany jest "wszycy bibliotekarze" to nie dodwaj innych bibliotekarzy do listy
                if (chosenList.Count != 0 && chosenList[0].BibliotekarzID == 0)
                {
                    return;
                }
                if (availableList[index].BibliotekarzID == 0)
                {
                    availableList.AddRange(chosenList);
                    chosenList.Clear();
                    //"Wszycy bibliotekarze" jest zawsze na pierwszym miejscu
                    //dlatego mogę najpierw posortować bo to nie zmieni jego pozycji
                    availableList.Sort(compareByLastname);
                }
                chosenList.Add(availableList[index]);
                chosenList.Sort(compareByLastname);
                availableList.RemoveAt(index);
            }

            /// <summary>
            /// Przenieś bibliotekarza z listy wybranych do listy dostępnych.
            /// </summary>
            /// <param name="str">Nazwa czytelnika oraz jego id.</param>
            override public void MoveUserLeft(string str)
            {
                int id = FindIDInString(str);
                int index;
                if (id == 0)
                    index = 0;
                else
                    index = (int)chosenList.FindIndex(librarian => librarian.BibliotekarzID == id);

                availableList.Add(chosenList[index]);
                availableList.Sort(compareByLastname);
                chosenList.RemoveAt(index);
            }

            /// <summary>
            /// Zaktualizuj listy bibliotekarzy kopiami roboczymi.
            /// </summary>
            override public void UpdateLists()
            {

                availableListRef = availableList;
                chosenListRef = chosenList;
            }

            /// <summary>
            /// Porównaj bibliotekrzy po ich nazwiskach, specjalny bibliotekrz ma priorytet.
            /// </summary>
            /// <param name="x">Bibliotekarz.</param>
            /// <param name="y">Bibliotekarz.</param>
            /// <returns>Wynik porównania.</returns>
            private int compareByLastname(Bibliotekarz x, Bibliotekarz y)
            {
                //Objekt reprezentujący wszystkich bibliotekarzy znajduje się na pierwszym miejscu
                if (x.BibliotekarzID == 0)
                    return -1;
                else if (y.BibliotekarzID == 0)
                    return 1;
                return x.Nazwisko.CompareTo(y.Nazwisko);
            }

            /// <summary>
            /// Pobierz listę stringów dostępnych czytelników.
            /// </summary>
            /// <param name="filter">Wzór do filtrowania listy.</param>
            /// <returns>Lista stringów dostępnych czytelników.</returns>
            override public List<string> GetAvailableListStr(string filter)
            {
                List<string> namesList = new List<string>();
                foreach (var elem in availableList)
                {
                    string str;
                    if (elem.BibliotekarzID == 0)
                        str = $"{elem.Imię} {elem.Nazwisko}";
                    else
                        str = $"{elem.Imię} {elem.Nazwisko} ({elem.BibliotekarzID})";
                    if (filter.Length == 0 || str.ToLower().Contains(filter.ToLower()))
                        namesList.Add(str);
                }
                return namesList;
            }

            /// <summary>
            /// Pobierz listę stringów wybranych bibliotekrzy.
            /// </summary>
            /// <param name="filter">Wzór do filtrowania listy.</param>
            /// <returns>Lista stringów wybranych bibliotekrzy.</returns>
            override public List<string> GetChosenListStr(string filter)
            {
                List<string> namesList = new List<string>();
                foreach (var elem in chosenList)
                {
                    string str;
                    if (elem.BibliotekarzID == 0)
                        str = $"{elem.Imię} {elem.Nazwisko}";
                    else
                        str = $"{elem.Imię} {elem.Nazwisko} ({elem.BibliotekarzID})";
                    if (filter.Length == 0 || str.ToLower().Contains(filter.ToLower()))
                        namesList.Add(str);
                }
                return namesList;
            }

            /// <summary>
            /// Metoda niedostępna dla tej klasy.
            /// </summary>
            /// <returns>null</returns>
            override public List<Czytelnik> GetAvailableReadersList()
            {
                return null;
            }

            /// <summary>
            /// Metoda niedostępna dla tej klasy.
            /// </summary>
            /// <returns>null.</returns>
            override public List<Czytelnik> GetChosenReadersList()
            {
                return null;
            }

            /// <summary>
            /// Pobierz listę dostępnych bibliotekrzy.
            /// </summary>
            /// <returns>Lista bibliotekrzy.</returns>
            override public List<Bibliotekarz> GetAvailableLibrariansList()
            {
                return availableListRef;
            }

            /// <summary>
            /// Pobierz listę wybranych bibliotekrzy.
            /// </summary>
            /// <returns>Lista bibliotekrzy.</returns>
            override public List<Bibliotekarz> GetChosenLibrariansList()
            {
                return chosenListRef;
            }

            /// <summary>
            /// Pobierz ilość wybranych bibliotekarzy.
            /// </summary>
            /// <returns>Ilość wybranych bibliotekarzy.</returns>
            override public int GetChosenListCount()
            {
                return chosenListRef.Count;
            }
        }

        /// <summary>
        /// Utworzenie objektu ReadersSelection.
        /// </summary>
        /// <param name="availableList">Lista dostępnych czytelników.</param>
        /// <param name="chosenList">Lista wybranych czytelników.</param>
        /// <returns>Objekt ReadersSelection.</returns>
        public static UsersSelection MakeUsersSelection(List<Czytelnik> availableList, List<Czytelnik> chosenList)
        {
            return new ReadersSelection(availableList, chosenList);
        }

        /// <summary>
        /// Utworzenie objektu LibrariansSelection.
        /// </summary>
        /// <param name="availableList">Lista dostępnych bibliotekarzy.</param>
        /// <param name="chosenList">Lista wybranych bibliotekarzy.</param>
        /// <returns>Objekt LibrariansSelection.</returns>
        public static UsersSelection MakeUsersSelection(List<Bibliotekarz> availableList, List<Bibliotekarz> chosenList)
        {
            return new LibrariansSelection(availableList, chosenList);
        }
    }

    /// <summary>
    /// Interfejs do pobierania list użytkowników.
    /// </summary>
    interface IUsersSelectionGetter
    {
        /// <summary>
        /// Pobierz listę wybranych użytkowników.
        /// </summary>
        /// <returns>Lista użytkowników.</returns>
        List<Czytelnik> GetAvailableReadersList();

        /// <summary>
        /// Pobierz listę wybranych użytkowników.
        /// </summary>
        /// <returns>Lista użytkowników.</returns>
        List<Czytelnik> GetChosenReadersList();

        /// <summary>
        /// Pobierz listę wybranych użytkowników.
        /// </summary>
        /// <returns>Lista użytkowników.</returns>
        List<Bibliotekarz> GetAvailableLibrariansList();

        /// <summary>
        /// Pobierz listę wybranych użytkowników.
        /// </summary>
        /// <returns>Lista użytkowników.</returns>
        List<Bibliotekarz> GetChosenLibrariansList();

        /// <summary>
        /// Pobierz ilość wybranych użytkowników.
        /// </summary>
        /// <returns>Ilość wybranych użytkowników.</returns>
        int GetChosenListCount();
    }
}