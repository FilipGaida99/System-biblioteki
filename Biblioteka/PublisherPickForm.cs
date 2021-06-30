using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Formularz rozszerzający zarządzanie wydawnictwami o możliwość wyboru jednego z nich.
    /// </summary>
    public partial class PublisherPickForm : Biblioteka.PublisherManagementForm
    {
        /// <summary>
        /// Wybrane wydawnictwo.
        /// </summary>
        public Wydawnictwo publisher;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public PublisherPickForm() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obsługa wybrania zaznaczonego wydawnictwa.
        /// </summary>
        /// <param name="sender">Kontrolka.</param>
        /// <param name="e">Argumenty.</param>
        private void pickButton_Click(object sender, EventArgs e)
        {
            using (new AppWaitCursor(this, sender))
            {
                publisher = GetSelectedPublisher();
                if(publisher != null)
                {
                    this.Return();
                }
            }
        }
    }
}
