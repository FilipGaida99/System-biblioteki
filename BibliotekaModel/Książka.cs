namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Książka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Książka()
        {
            Egzemplarz = new HashSet<Egzemplarz>();
            Rezerwacje = new HashSet<Rezerwacje>();
            Autor = new HashSet<Autor>();
        }

        public long KsiążkaID { get; set; }

        [Column("Maksymalny okres wypożyczenia")]
        public long Maksymalny_okres_wypożyczenia { get; set; }

        [Required]
        [StringLength(17)]
        public string ISBN { get; set; }

        [Column("Rok wydania", TypeName = "date")]
        public DateTime Rok_wydania { get; set; }

        [Required]
        [StringLength(200)]
        public string Tytuł { get; set; }

        [StringLength(4000)]
        public string Opis { get; set; }

        public long WydawnictwoID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Egzemplarz> Egzemplarz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezerwacje> Rezerwacje { get; set; }

        public virtual Wydawnictwo Wydawnictwo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autor> Autor { get; set; }
    }
}
