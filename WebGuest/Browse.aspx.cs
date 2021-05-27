using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteka;


namespace WebGuest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BookSearch.onSearch += OnSearch;
        }

        private void OnSearch()
        {
            var books = BookSearch.booksID;
            if (books != null)
            {
                foreach (var book in books)
                {
                    AddBook(book);
                }
            }
        }

        private void AddBook(long bookID)
        {
            var rec = (BookRecord)Page.LoadControl("~/BookRecord.ascx");
            rec.ID = $"Book{bookID}";
            rec.managedBookID = bookID;
            BookRecordPanel.Controls.Add(rec);
        }
    }
}