namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja wiadomości.
    /// </summary>
    public partial class Wiadomość
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wiadomość()
        {
            Bibliotekarz_Wiadomość = new HashSet<Bibliotekarz_Wiadomość>();
            Czytelnik_Wiadomość = new HashSet<Czytelnik_Wiadomość>();
        }

        /// <summary>
        /// ID wiadomości.
        /// </summary>
        public long WiadomośćID { get; set; }

        /// <summary>
        /// Tytuł.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Tytuł { get; set; }

        /// <summary>
        /// Treść.
        /// </summary>
        [Required]
        [StringLength(4000)]
        public string Treść { get; set; }


        /// <summary>
        /// Data wysłania.
        /// </summary>
        [Column("Data wysłania")]
        public DateTime Data_wysłania { get; set; }

        /// <summary>
        /// Bibliotekarze, których dotyczy wiadomość.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bibliotekarz_Wiadomość> Bibliotekarz_Wiadomość { get; set; }

        /// <summary>
        /// Czytelnicy, których dotyczy wiadomość.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Czytelnik_Wiadomość> Czytelnik_Wiadomość { get; set; }

    }
}
