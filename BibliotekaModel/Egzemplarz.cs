namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Egzemplarz")]
    public partial class Egzemplarz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Egzemplarz()
        {
            Wypożyczenie = new HashSet<Wypożyczenie>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Nr_inwentarza { get; set; }

        [Column("Rok wydruku", TypeName = "date")]
        public DateTime Rok_wydruku { get; set; }

        public long KsiążkaID { get; set; }

        [Column("Rok wydruku", TypeName = "date")]
        public DateTime Rok_wydruku { get; set; }

        public virtual Egzemplarz_elektroniczny Egzemplarz_elektroniczny { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypożyczenie> Wypożyczenie { get; set; }

        public virtual Książka Książka { get; set; }
    }
}
