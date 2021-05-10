namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bibliotekarz")]
    public partial class Bibliotekarz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bibliotekarz()
        {
            Bibliotekarz_Wiadomość = new HashSet<Bibliotekarz_Wiadomość>();
            Wystawa = new HashSet<Wystawa>();
        }

        public long BibliotekarzID { get; set; }

        [StringLength(20)]
        public string Imię { get; set; }

        [StringLength(20)]
        public string Nazwisko { get; set; }

        [Column("Numer telefonu")]
        public int? Numer_telefonu { get; set; }

        [Column("Adres email")]
        [StringLength(50)]
        public string Adres_email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bibliotekarz_Wiadomość> Bibliotekarz_Wiadomość { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wystawa> Wystawa { get; set; }
    }
}
