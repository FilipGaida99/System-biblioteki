namespace BibliotekaModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja książki.
    /// </summary>
    public partial class Książka
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Książka()
        {
            Egzemplarz = new HashSet<Egzemplarz>();
            Rezerwacje = new HashSet<Rezerwacje>();
            Autor = new HashSet<Autor>();
        }

        /// <summary>
        /// ID książki.
        /// </summary>
        public long KsiążkaID { get; set; }

        /// <summary>
        /// Maksymalny okres wypożyczenia.
        /// </summary>
        [Column("Maksymalny okres wypożyczenia")]
        public long Maksymalny_okres_wypożyczenia { get; set; }

        /// <summary>
        /// ISBN.
        /// </summary>
        [Required]
        [StringLength(17)]
        public string ISBN { get; set; }

        /// <summary>
        /// Rok wydania.
        /// </summary>
        [Column("Rok wydania", TypeName = "date")]
        public DateTime Rok_wydania { get; set; }

        /// <summary>
        /// Tytuł.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Tytuł { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        [StringLength(4000)]
        public string Opis { get; set; }

        /// <summary>
        /// ID wydawnictwa.
        /// </summary>
        public long WydawnictwoID { get; set; }

        /// <summary>
        /// Egzemplarze książki.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Egzemplarz> Egzemplarz { get; set; }

        /// <summary>
        /// Rezerwacje książki.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezerwacje> Rezerwacje { get; set; }

        /// <summary>
        /// Wydawnictwo odpowiedzialne za książkę.
        /// </summary>
        public virtual Wydawnictwo Wydawnictwo { get; set; }

        /// <summary>
        /// Autor książki.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autor> Autor { get; set; }
    }
}
