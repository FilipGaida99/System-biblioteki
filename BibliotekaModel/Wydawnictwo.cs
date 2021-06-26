namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja wydawnictwa.
    /// </summary>
    [Table("Wydawnictwo")]
    public partial class Wydawnictwo
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wydawnictwo()
        {
            Książka = new HashSet<Książka>();
        }

        /// <summary>
        /// ID wydawnictwa.
        /// </summary>
        public long WydawnictwoID { get; set; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        [StringLength(200)]
        public string Nazwa { get; set; }

        /// <summary>
        /// Książki wydawnictwa.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Książka> Książka { get; set; }
    }
}
