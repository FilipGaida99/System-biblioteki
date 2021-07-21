namespace BibliotekaModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja wiadomości bibliotekarza.
    /// </summary>
    public partial class Bibliotekarz_Wiadomość
    {
        /// <summary>
        /// ID wiadomości.
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long WiadomośćID { get; set; }

        /// <summary>
        /// ID bibliotekarza.
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long BibliotekarzID { get; set; }

        /// <summary>
        /// Czy jest nadawcą.
        /// </summary>
        public bool Nadawca { get; set; }

        /// <summary>
        /// Stan wiadomości:
        /// null - nieprzeczytane
        /// 1 - przeczytane
        /// 2 - usunięte.
        /// </summary>
        public byte? Stan { get; set; }

        /// <summary>
        /// Bibliotekarz, którego dotyczy wiadomość.
        /// </summary>
        public virtual Bibliotekarz Bibliotekarz { get; set; }

        /// <summary>
        /// Wiadomość.
        /// </summary>
        public virtual Wiadomość Wiadomość { get; set; }
    }
}
