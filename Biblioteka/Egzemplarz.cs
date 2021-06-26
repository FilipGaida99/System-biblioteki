namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja egzemplarza.
    /// </summary>
    [Table("Egzemplarz")]
    public partial class Egzemplarz
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Egzemplarz()
        {
            Wypożyczenie = new HashSet<Wypożyczenie>();
        }

        /// <summary>
        /// Numer inwentarza.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Nr_inwentarza { get; set; }

        /// <summary>
        /// ID książki, której jest egzemplarzem.
        /// </summary>
        public long KsiążkaID { get; set; }

        /// <summary>
        /// Rok wydruku.
        /// </summary>
        [Column("Rok wydruku", TypeName = "date")]
        public DateTime Rok_wydruku { get; set; }

        /// <summary>
        /// Objekt egzemplarza elektronicznego,
        /// jeżeli nie jest elektroniczny to jest równe null.
        /// </summary>
        public virtual Egzemplarz_elektroniczny Egzemplarz_elektroniczny { get; set; }

        /// <summary>
        /// Wypożyczenia egzemplarza.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypożyczenie> Wypożyczenie { get; set; }

        /// <summary>
        /// Książka, której jest egzemplarzem.
        /// </summary>
        public virtual Książka Książka { get; set; }
    }
}
