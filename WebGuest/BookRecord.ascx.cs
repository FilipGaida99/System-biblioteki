﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteka;

namespace WebGuest
{
    public partial class BookRecord : System.Web.UI.UserControl
    {
        public long managedBookID;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new BibliotekaDB())
            {
                Książka managedBook = db.Książka.Find(managedBookID);
                Title.Text = managedBook.Tytuł;
                ISBN.Text = managedBook.ISBN;
                Year.Text = managedBook.Rok_wydania.Year.ToString();
                Publisher.Text = managedBook.Wydawnictwo.Nazwa;
                var authorsList = managedBook.Autor.ToList();
                Authors.Text = authorsList[0].Imię + " " + authorsList[0].Nazwisko;
                for (int i = 1; i < authorsList.Count; i++)
                {
                    Authors.Text += ", ";
                    Authors.Text += authorsList[i].Imię + " " + authorsList[i].Nazwisko;
                }
            }
            ShowLink.NavigateUrl = $"~/BookDetails.aspx?id={managedBookID}";
        }
    }
}