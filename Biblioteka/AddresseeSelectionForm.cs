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
            UpdateAvailableListBox();
            UpdateChosenListBox();
        }

        private void addAddresseeButton_Click(object sender, EventArgs e)
        {
            if (availableListBox.SelectedIndex == -1)
                return;
            usersSelection.MoveUserRight((string)availableListBox.SelectedItem);

            UpdateAvailableListBox();
            UpdateChosenListBox();
        }

        private void RemoveAddresseeButton_Click(object sender, EventArgs e)
        {
            if (chosenListBox.SelectedIndex == -1)
                return;

            usersSelection.MoveUserLeft((string)chosenListBox.SelectedItem);

            UpdateAvailableListBox();
            UpdateChosenListBox();
        }

        private void UpdateAvailableListBox()
        {
            availableListBox.BeginUpdate();
            availableListBox.Items.Clear();
            availableListBox.Items.AddRange(usersSelection.GetAvailableListStr(availableFilterTextBox.Text).ToArray());
            availableListBox.EndUpdate();
        }

        private void UpdateChosenListBox()
        {
            chosenListBox.BeginUpdate();
            chosenListBox.Items.Clear();
            chosenListBox.Items.AddRange(usersSelection.GetChosenListStr(chosenFilterTextBox.Text).ToArray());
            chosenListBox.EndUpdate();
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

        private void availableFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAvailableListBox();
        }

        private void chosenFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateChosenListBox();
        }
    }
}
