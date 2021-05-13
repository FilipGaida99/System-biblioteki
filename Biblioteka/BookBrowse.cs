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
    public partial class BookBrowse : Form
    {
        public BookBrowse()
        {
            InitializeComponent();
        }

        private void BookBrowse_Load(object sender, EventArgs e)
        {
            bookSearch.onSearch += OnSearch;
        }

        private void OnSearch()
        {
            bookLayout.Controls.Clear();
            foreach(var book in bookSearch.resultBooks)
            {
                bookLayout.Controls.Add(new BookRecord(book));
            }
        }
    }
}
