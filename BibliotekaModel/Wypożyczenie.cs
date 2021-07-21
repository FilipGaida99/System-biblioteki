namespace BibliotekaModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja wypożyczenia.
    /// </summary>
    public partial class Wypożyczenie
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wypożyczenie()
        {
            Kara = new HashSet<Kara>();
            Prolongata = new HashSet<Prolongata>();
        }

        /// <summary>
        /// ID wypożyczenia.
        /// </summary>
        public long WypożyczenieID { get; set; }

        /// <summary>
        /// Data wypożycznia.
        /// </summary>
        [Column("Data wypożyczenia")]
        public DateTime? Data_wypożyczenia { get; set; }

        /// <summary>
        /// Data zwrotu.
        /// </summary>
        [Column("Data zwrotu")]
        public DateTime? Data_zwrotu { get; set; }

        /// <summary>
        /// ID wypożyczającego czytelnika.
        /// </summary>
        public long CzytelnikID { get; set; }

        /// <summary>
        /// Numer inwentarza.
        /// </summary>
        public long Nr_inwentarza { get; set; }

        /// <summary>
        /// Wypożyczający czytelnik.
        /// </summary>
        public virtual Czytelnik Czytelnik { get; set; }

        /// <summary>
        /// Wypożyczany egzemplarz.
        /// </summary>
        public virtual Egzemplarz Egzemplarz { get; set; }

        /// <summary>
        /// Kary nałożone na wypożyczenie.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kara> Kara { get; set; }

        /// <summary>
        /// Prolongaty wypożyczenia.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prolongata> Prolongata { get; set; }
    }
}
