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
    public partial class AutorForm : Form
    {
        public Autor choosedAutor;

        List<Autor> autors;

        public AutorForm()
        {
            InitializeComponent();
            autors = new List<Autor>();
        }

        private void AutorForm_Load(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                autors = db.Autor.OrderBy(autor => autor.Nazwisko).ToList();
                UpdateComboBox();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            choosedAutor = new Autor { Imię = firstNameText.Text, Nazwisko = surnameText.Text };
            this.Return();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                autors = db.Autor.Where(autor =>
                    autor.Imię.Contains(firstNameText.Text) && autor.Nazwisko.Contains(surnameText.Text)
                    ).OrderBy(autor => autor.Nazwisko).ToList();

                UpdateComboBox();
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex < autors.Count && comboBox.SelectedIndex >= 0)
            {
                choosedAutor = autors[comboBox.SelectedIndex];
                this.Return();
            }
        }

        private void UpdateComboBox()
        {
            comboBox.BeginUpdate();
            comboBox.Items.Clear();
            foreach (var autor in autors)
            {
                comboBox.Items.Add($"{autor.Imię} {autor.Nazwisko}");
            }
            comboBox.EndUpdate();
        }

    }
}
