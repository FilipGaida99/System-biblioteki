namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja czytelnika.
    /// </summary>
    [Table("Czytelnik")]
    public partial class Czytelnik
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Czytelnik()
        {
            Czytelnik_Wiadomość = new HashSet<Czytelnik_Wiadomość>();
            Wypożyczenie = new HashSet<Wypożyczenie>();
            Rezerwacje = new HashSet<Rezerwacje>();
        }

        /// <summary>
        /// ID czytelnika.
        /// </summary>
        public long CzytelnikID { get; set; }

        /// <summary>
        /// Imię czytelnika.
        /// </summary>
        [StringLength(20)]
        public string Imię { get; set; }

        /// <summary>
        /// Nazwisko czytelnika.
        /// </summary>
        [StringLength(20)]
        public string Nazwisko { get; set; }

        /// <summary>
        /// Numer telefonu czytelnika.
        /// </summary>
        [Column("Numer telefonu")]
        public int? Numer_telefonu { get; set; }

        /// <summary>
        /// Adres email czytelnika.
        /// </summary>
        [Column("Adres email")]
        [StringLength(50)]
        public string Adres_email { get; set; }

        /// <summary>
        /// Data utworzenia czytelnika.
        /// </summary>
        [Column("Data utworzenia", TypeName = "date")]
        public DateTime Data_utworzenia { get; set; }

        /// <summary>
        /// Otrzymane oraz wysłane wiadomości czytelnika.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Czytelnik_Wiadomość> Czytelnik_Wiadomość { get; set; }

        /// <summary>
        /// Wypożyczenia książek.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypożyczenie> Wypożyczenie { get; set; }

        /// <summary>
        /// Rezerwacje książek.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezerwacje> Rezerwacje { get; set; }
    }
}
