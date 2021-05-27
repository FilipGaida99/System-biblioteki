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

        public AddresseeSelectionForm(UsersSelection usersSelection)
        {
            InitializeComponent();
            this.usersSelection = usersSelection;

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
            if (availableListBox.SelectedIndex == -1)
                return;
            usersSelection.MoveUserRight(availableListBox.SelectedIndex);
            
            availableListBox.BeginUpdate();
            availableListBox.Items.Clear();
            availableListBox.Items.AddRange(usersSelection.GetAvailableListStr().ToArray());
            availableListBox.EndUpdate();

            chosenListBox.BeginUpdate();
            chosenListBox.Items.Clear();
            chosenListBox.Items.AddRange(usersSelection.GetChosenListStr().ToArray());
            chosenListBox.EndUpdate();
        }

        private void removeAddresseeButton_Click(object sender, EventArgs e)
        {
            if (chosenListBox.SelectedIndex == -1)
                return;

            usersSelection.MoveUserLeft(chosenListBox.SelectedIndex);

            chosenListBox.BeginUpdate();
            chosenListBox.Items.Clear();
            chosenListBox.Items.AddRange(usersSelection.GetChosenListStr().ToArray());
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
    }
}
