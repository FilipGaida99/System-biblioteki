namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja autora.
    /// </summary>
    [Table("Autor")]
    public partial class Autor
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Autor()
        {
            Książka = new HashSet<Książka>();
        }

        /// <summary>
        /// ID autora.
        /// </summary>
        public long AutorID { get; set; }

        /// <summary>
        /// Imię autora.
        /// </summary>
        [StringLength(20)]
        public string Imię { get; set; }

        /// <summary>
        /// Nazwisko autora.
        /// </summary>
        [StringLength(20)]
        public string Nazwisko { get; set; }

        /// <summary>
        /// Książki napisane przez autora.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Książka> Książka { get; set; }
    }
}
