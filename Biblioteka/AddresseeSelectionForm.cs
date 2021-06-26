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
    /// <summary>
    /// Formularz wyboru adresatów wiadomości.
    /// </summary>
    public partial class AddresseeSelectionForm : Form
    {
        /// <summary>
        /// Objekt odowiedzialny za zarządzanie listami dostępnych oraz wybranych adresatów.
        /// </summary>
        UsersSelection usersSelection;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public AddresseeSelectionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="usersSelection">Objekt odowiedzialny za zarządzanie listami dostępnych oraz wybranych adresatów.</param>
        public AddresseeSelectionForm(UsersSelection usersSelection)
        {
            InitializeComponent();
            this.usersSelection = usersSelection;

        }

        /// <summary>
        /// Obsługa załadowania formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void AddresseeSelectionForm_Load(object sender, EventArgs e)
        {
            UpdateAvailableListBox();
            UpdateChosenListBox();
        }

        /// <summary>
        /// Obsługa dodania adresata do listy wybranych.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void addAddresseeButton_Click(object sender, EventArgs e)
        {
            if (availableListBox.SelectedIndex == -1)
                return;
            usersSelection.MoveUserRight((string)availableListBox.SelectedItem);

            UpdateAvailableListBox();
            UpdateChosenListBox();
        }

        /// <summary>
        /// Obsługa usunięcia adresata z listy wybranych.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void RemoveAddresseeButton_Click(object sender, EventArgs e)
        {
            if (chosenListBox.SelectedIndex == -1)
                return;

            usersSelection.MoveUserLeft((string)chosenListBox.SelectedItem);

            UpdateAvailableListBox();
            UpdateChosenListBox();
        }

        /// <summary>
        /// Zaktualizowanie listy dostępnych adresatów.
        /// </summary>
        private void UpdateAvailableListBox()
        {
            availableListBox.BeginUpdate();
            availableListBox.Items.Clear();
            availableListBox.Items.AddRange(usersSelection.GetAvailableListStr(availableFilterTextBox.Text).ToArray());
            availableListBox.EndUpdate();
        }

        /// <summary>
        /// Zaktualizowanie listy wybranych adresatów.
        /// </summary>
        private void UpdateChosenListBox()
        {
            chosenListBox.BeginUpdate();
            chosenListBox.Items.Clear();
            chosenListBox.Items.AddRange(usersSelection.GetChosenListStr(chosenFilterTextBox.Text).ToArray());
            chosenListBox.EndUpdate();
        }

        /// <summary>
        /// Obsługa zatwierdzenia wyboru adresatów i zamknięcie formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void selectButton_Click(object sender, EventArgs e)
        {
            usersSelection.UpdateLists();
            this.Close();
        }

        /// <summary>
        /// Obsługa zamknięcia formularza.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Obsługa filtrowania listy dostępnych adresatów.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void availableFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAvailableListBox();
        }

        /// <summary>
        /// Obsługa filtrowania listy wybranych adresatów.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void chosenFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateChosenListBox();
        }
    }
}
