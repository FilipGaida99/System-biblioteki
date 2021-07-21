namespace BibliotekaModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja bibliotekarza.
    /// </summary>
    [Table("Bibliotekarz")]
    public partial class Bibliotekarz
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bibliotekarz()
        {
            Bibliotekarz_Wiadomość = new HashSet<Bibliotekarz_Wiadomość>();
            Wystawa = new HashSet<Wystawa>();
        }

        /// <summary>
        /// ID bibliotekarza.
        /// </summary>
        public long BibliotekarzID { get; set; }

        /// <summary>
        /// Imię bibliotekarza.
        /// </summary>
        [StringLength(20)]
        public string Imię { get; set; }

        /// <summary>
        /// Nazwisko bibliotekarza.
        /// </summary>
        [StringLength(20)]
        public string Nazwisko { get; set; }

        /// <summary>
        /// Numer telefonu bibliotekarza.
        /// </summary>
        [Column("Numer telefonu")]
        public int? Numer_telefonu { get; set; }

        /// <summary>
        /// Adres email bibliotekarza.
        /// </summary>
        [Column("Adres email")]
        [StringLength(50)]
        public string Adres_email { get; set; }

        /// <summary>
        /// Otrzymane oraz wysłane wiadomości bibliotekarza.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bibliotekarz_Wiadomość> Bibliotekarz_Wiadomość { get; set; }

        /// <summary>
        /// Wystawy, za które jest odpowiedzialny bibliotekarz.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wystawa> Wystawa { get; set; }

        /// <summary>
        /// Nazwa specjalnego bibliotekarza
        /// </summary>
        public const string specialLibrarianName = "Biblioteka";
    }
}
