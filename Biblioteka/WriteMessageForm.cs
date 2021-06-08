﻿using System;
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
    public partial class WriteMessageForm : Form
    {

        //List<object> availableList;

        //List<object> chosenList;

        IUsersSelectionGetter userLists;

        //Czytelnik reader; //raczej do zmiany gdy ogarniemy jak chcemy przechowywać zalogowanego użytkownika

        //Bibliotekarz librarian; //tu tak samo

        //bool isReader = true; //to pewnie też

        public WriteMessageForm()
        {
            InitializeComponent();
        }

        private void AddAddresseeButton_Click(object sender, EventArgs e)
        {
            AddresseeSelectionForm adSelFrom = new AddresseeSelectionForm((UsersSelection)userLists);
            adSelFrom.ShowDialog();

            UpdateAddresseeLabel();
        }

        private void UpdateAddresseeLabel()
        {
            if ((Czytelnik)UserSingleton.Instance.GetLoggedUser() != null)
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

        private void WriteMessageForm_Load(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                if ((Czytelnik)UserSingleton.Instance.GetLoggedUser() != null)
                {
                    //reader = db.Czytelnik.Find(1);
                    List<Bibliotekarz> availableList = db.Bibliotekarz
                        .Where(librarian => librarian.Imię != "Biblioteka")
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

                            if ((Czytelnik)UserSingleton.Instance.GetLoggedUser() != null)
                            {
                                db.Czytelnik_Wiadomość.Add(new Czytelnik_Wiadomość 
                                    { CzytelnikID = ((Czytelnik)UserSingleton.Instance.GetLoggedUser()).CzytelnikID,
                                        Nadawca = true, WiadomośćID = msg.WiadomośćID });

                                foreach (var elem in userLists.GetChosenLibrariansList())
                                {
                                    if(elem.BibliotekarzID == 0)
                                    {
                                        Bibliotekarz specialLibrarian = db.Bibliotekarz
                                        .Where(librarian => librarian.Imię == "Biblioteka")
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
                    }
                }
                else
                {
                    MessageBox.Show("Nie można wysłać wiadomości!\n Treść wiadomości jest pusta!",
                          "Pusta treść",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie można wysłać wiadomości!\n Tytuł jest pusty!",
                           "Pusty tytuł",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void CancelMsgButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public abstract class 
    }
    public abstract class UsersSelection : IUsersSelectionGetter
    {
        private UsersSelection() { }

        abstract public void MoveUserRight(string str);

        abstract public void MoveUserLeft(string str);

        abstract public void UpdateLists();

        abstract public List<string> GetAvailableListStr(string filter);

        abstract public List<string> GetChosenListStr(string filter);

        abstract public List<Czytelnik> GetAvailableReadersList();

        abstract public List<Czytelnik> GetChosenReadersList();

        abstract public List<Bibliotekarz> GetAvailableLibrariansList();

        abstract public List<Bibliotekarz> GetChosenLibrariansList();

        abstract public int GetChosenListCount();

        private sealed class ReadersSelection : UsersSelection
        {
            List<Czytelnik> availableListRef;
            List<Czytelnik> chosenListRef;

            List<Czytelnik> availableList;
            List<Czytelnik> chosenList;

            public ReadersSelection(List<Czytelnik> availableList, List<Czytelnik> chosenList)
            {
                this.availableListRef = availableList;
                this.chosenListRef = chosenList;

                this.availableList = new List<Czytelnik>(availableList);
                this.chosenList = new List<Czytelnik>(chosenList);
            }

            private int FindIDInString(string str)
            {
                str = str
                    .Split()
                    .Last()
                    .Trim("()".ToCharArray());
                return Int32.Parse(str);
            }

            //override public void MoveUserRight(int index)
            //{
            //    chosenList.Add(availableList[index]);
            //    chosenList.Sort((x, y) => x.Nazwisko.CompareTo(y));
            //    availableList.RemoveAt(index);
            //}

            override public void MoveUserRight(string str)
            {
                int id = FindIDInString(str);
                int index = availableList.FindIndex(librarian => librarian.CzytelnikID == id);

                chosenList.Add(availableList[index]);
                chosenList.Sort((x, y) => x.Nazwisko.CompareTo(y));
                availableList.RemoveAt(index);
            }

            //override public void MoveUserLeft(int index)
            //{
            //    availableList.Add(availableList[index]);
            //    availableList.Sort((x, y) => x.Nazwisko.CompareTo(y));
            //    chosenList.RemoveAt(index);
            //}

            override public void MoveUserLeft(string str)
            {
                int id = FindIDInString(str);
                int index = chosenList.FindIndex(librarian => librarian.CzytelnikID == id);

                availableList.Add(chosenList[index]);
                availableList.Sort((x, y) => x.Nazwisko.CompareTo(y));
                chosenList.RemoveAt(index);
            }

            override public void UpdateLists()
            {
                availableListRef = availableList;
                chosenListRef = chosenList;
            }

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

            override public List<Czytelnik> GetAvailableReadersList()
            {
                return availableListRef;
            }

            override public List<Czytelnik> GetChosenReadersList()
            {
                return chosenListRef;
            }

            override public List<Bibliotekarz> GetAvailableLibrariansList()
            {
                return null;
            }

            override public List<Bibliotekarz> GetChosenLibrariansList()
            {
                return null;
            }

            override public int GetChosenListCount() {
                return chosenListRef.Count;
            }
        }

        private sealed class LibrariansSelection : UsersSelection
        {
            List<Bibliotekarz> availableListRef;
            List<Bibliotekarz> chosenListRef;

            List<Bibliotekarz> availableList;
            List<Bibliotekarz> chosenList;

            public LibrariansSelection(List<Bibliotekarz> availableList, List<Bibliotekarz> chosenList)
            {
                this.availableListRef = availableList;
                this.chosenListRef = chosenList;

                this.availableList = new List<Bibliotekarz>(availableList);
                this.chosenList = new List<Bibliotekarz>(chosenList);
            }

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

            override public void UpdateLists()
            {

                availableListRef = availableList;
                chosenListRef = chosenList;
            }

            private int compareByLastname(Bibliotekarz x, Bibliotekarz y)
            {
                //Objekt reprezentujący wszystkich bibliotekarzy znajduje się na pierwszym miejscu
                if (x.BibliotekarzID == 0)
                    return -1;
                else if (y.BibliotekarzID == 0)
                    return 1;
                return x.Nazwisko.CompareTo(y.Nazwisko);
            }

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

            override public List<Czytelnik> GetAvailableReadersList()
            {
                return null;
            }

            override public List<Czytelnik> GetChosenReadersList()
            {
                return null;
            }

            override public List<Bibliotekarz> GetAvailableLibrariansList()
            {
                return availableListRef;
            }

            override public List<Bibliotekarz> GetChosenLibrariansList()
            {
                return chosenListRef;
            }

            override public int GetChosenListCount()
            {
                return chosenListRef.Count;
            }
        }

        public static UsersSelection MakeUsersSelection(List<Czytelnik> availableList, List<Czytelnik> chosenList)
        {
            return new ReadersSelection(availableList, chosenList);
        }
        public static UsersSelection MakeUsersSelection(List<Bibliotekarz> availableList, List<Bibliotekarz> chosenList)
        {
            return new LibrariansSelection(availableList, chosenList);
        }
    }
    interface IUsersSelectionGetter
    {
        List<Czytelnik> GetAvailableReadersList();

        List<Czytelnik> GetChosenReadersList();

        List<Bibliotekarz> GetAvailableLibrariansList();

        List<Bibliotekarz> GetChosenLibrariansList();

        int GetChosenListCount();
    }
}