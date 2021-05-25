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
    public partial class AddresseeSelectionForm : Form
    {
        UsersSelection usersSelection;

        public AddresseeSelectionForm()
        {
            InitializeComponent();
        }

        public AddresseeSelectionForm(List<Bibliotekarz> availableList, List<Bibliotekarz> chosenList)
        {
            InitializeComponent();
            usersSelection = UsersSelection.MakeUsersSelection(availableList, chosenList);

        }

        public AddresseeSelectionForm(List<Czytelnik> availableList, List<Czytelnik> chosenList)
        {
            InitializeComponent();
            usersSelection = UsersSelection.MakeUsersSelection(availableList, chosenList);
        }

        public List<object> GetAvailableList()
        {
            return usersSelection.GetAvailableList();
        }

        public List<object> GetChosenList()
        {
            return usersSelection.GetChosenList();
        }

        private void AddresseeSelectionForm_Load(object sender, EventArgs e)
        {
            availableListBox.BeginUpdate();
            availableListBox.Items.Clear();
            availableListBox.Items.AddRange(usersSelection.GetAvailableListStr().ToArray());
            availableListBox.EndUpdate();

            chosenListBox.BeginUpdate();
            chosenListBox.Items.Clear();
            chosenListBox.Items.AddRange(usersSelection.GetChosenListStr().ToArray());
            chosenListBox.EndUpdate();
        }

        private void addAddresseeButton_Click(object sender, EventArgs e)
        {
            usersSelection.MoveUserRight(availableListBox.SelectedIndex);
            
            availableListBox.BeginUpdate();
            availableListBox.Items.RemoveAt(availableListBox.SelectedIndex);
            availableListBox.EndUpdate();

            chosenListBox.BeginUpdate();
            chosenListBox.Items.Clear();
            chosenListBox.Items.AddRange(usersSelection.GetChosenListStr().ToArray());
            chosenListBox.EndUpdate();
        }

        private void removeAddresseeButton_Click(object sender, EventArgs e)
        {
            usersSelection.MoveUserLeft(availableListBox.SelectedIndex);

            chosenListBox.BeginUpdate();
            chosenListBox.Items.RemoveAt(availableListBox.SelectedIndex);
            chosenListBox.EndUpdate();

            availableListBox.BeginUpdate();
            availableListBox.Items.Clear();
            availableListBox.Items.AddRange(usersSelection.GetAvailableListStr().ToArray());
            availableListBox.EndUpdate();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            usersSelection.UpdateLists();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public abstract class UsersSelection
        {
            private UsersSelection() { }

            public abstract void MoveUserRight(int index);

            public abstract void MoveUserLeft(int index);

            public abstract void UpdateLists();

            public abstract List<string> GetAvailableListStr();

            public abstract List<string> GetChosenListStr();

            public abstract List<object> GetAvailableList();

            public abstract List<object> GetChosenList();

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

                override public void MoveUserRight(int index)
                {
                    chosenList.Add(availableList[index]);
                    chosenList.Sort((x, y) => x.Nazwisko.CompareTo(y));
                    availableList.RemoveAt(index);
                }

                override public void MoveUserLeft(int index)
                {
                    availableList.Add(availableList[index]);
                    availableList.Sort((x, y) => x.Nazwisko.CompareTo(y));
                    chosenList.RemoveAt(index);
                }

                override public void UpdateLists()
                {
                    availableListRef = availableList;
                    chosenListRef = chosenList;
                }

                override public List<string> GetAvailableListStr()
                {
                    List<string> namesList = new List<string>();
                    foreach(var elem in availableList)
                        namesList.Add($"{elem.Imię} {elem.Nazwisko}");
                    return namesList;
                }

                override public List<string> GetChosenListStr()
                {
                    List<string> namesList = new List<string>();
                    foreach (var elem in chosenList)
                        namesList.Add($"{elem.Imię} {elem.Nazwisko}");
                    return namesList;
                }

                override public List<object> GetAvailableList()
                {
                    return availableListRef.Cast<object>().ToList();
                }

                override public List<object> GetChosenList()
                {
                    return chosenListRef.Cast<object>().ToList();
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

                override public void MoveUserRight(int index)
                {
                    //Jeżeli wybrany jest "wszycy bibliotekarze" to nie dodwaj innych bibliotekarzy do listy
                    if (chosenList[0].BibliotekarzID == 0)
                    {
                        return;
                    }
                    if (availableList[index].BibliotekarzID == 0)
                    {
                        foreach (var elem in chosenList) {
                            availableList.Add(elem);
                            chosenList.Remove(elem);
                        }
                        //"Wszycy bibliotekarze" jest zawsze na pierwszym miejscu
                        //dlatego mogę najpierw posortować bo to nie zmieni jego pozycji
                        availableList.Sort(compareByLastname);
                    }
                    chosenList.Add(availableList[index]);
                    chosenList.Sort(compareByLastname);
                    availableList.RemoveAt(index);
                }
                override public void MoveUserLeft(int index)
                {
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
                        return 1;
                    else if (y.BibliotekarzID == 0)
                        return -1;
                    return x.Nazwisko.CompareTo(y.Nazwisko);
                }

                override public List<string> GetAvailableListStr()
                {
                    List<string> namesList = new List<string>();
                    foreach (var elem in availableList)
                        namesList.Add($"{elem.Imię} {elem.Nazwisko}");
                    return namesList;
                }

                override public List<string> GetChosenListStr()
                {
                    List<string> namesList = new List<string>();
                    foreach (var elem in chosenList)
                        namesList.Add($"{elem.Imię} {elem.Nazwisko}");
                    return namesList;
                }

                override public List<object> GetAvailableList()
                {
                    return availableListRef.Cast<object>().ToList();
                }

                override public List<object> GetChosenList()
                {
                    return chosenListRef.Cast<object>().ToList();
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
    }
}
