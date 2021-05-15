using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class AuthorForm : Form
    {
        public Autor choosedAutor;

        List<Autor> authors;

        public AuthorForm()
        {
            InitializeComponent();
            authors = new List<Autor>();
        }

        private void AutorForm_Load(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                authors = db.Autor.OrderBy(author => author.Nazwisko).ToList();
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
            using (new AppWaitCursor(this, sender))
            {
                using (var db = new BibliotekaDB())
                {
                    authors = db.Autor.Where(author =>
                        author.Imię.Contains(firstNameText.Text) && author.Nazwisko.Contains(surnameText.Text)
                        ).OrderBy(author => author.Nazwisko).ToList();

                    UpdateComboBox();
                }
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex < authors.Count && comboBox.SelectedIndex >= 0)
            {
                choosedAutor = authors[comboBox.SelectedIndex];
                this.Return();
            }
        }

        private void UpdateComboBox()
        {
            comboBox.BeginUpdate();
            comboBox.Items.Clear();
            foreach (var author in authors)
            {
                comboBox.Items.Add($"{author.Imię} {author.Nazwisko}");
            }
            comboBox.EndUpdate();
        }

    }
}
