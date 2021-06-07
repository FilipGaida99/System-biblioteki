namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Czytelnik")]
    public partial class Czytelnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Czytelnik()
        {
            Czytelnik_Wiadomość = new HashSet<Czytelnik_Wiadomość>();
            Wypożyczenie = new HashSet<Wypożyczenie>();
            Rezerwacje = new HashSet<Rezerwacje>();
        }

        public long CzytelnikID { get; set; }

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
        public virtual ICollection<Czytelnik_Wiadomość> Czytelnik_Wiadomość { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypożyczenie> Wypożyczenie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezerwacje> Rezerwacje { get; set; }
    }
}
