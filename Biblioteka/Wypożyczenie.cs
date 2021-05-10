namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Wypożyczenie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wypożyczenie()
        {
            Kara = new HashSet<Kara>();
            Prolongata = new HashSet<Prolongata>();
        }

        public long WypożyczenieID { get; set; }

        [Column("Data wypożyczenia")]
        public DateTime? Data_wypożyczenia { get; set; }

        [Column("Data zwrotu")]
        public DateTime? Data_zwrotu { get; set; }

        public long CzytelnikID { get; set; }

        public long Nr_inwentarza { get; set; }

        public virtual Czytelnik Czytelnik { get; set; }

        public virtual Egzemplarz Egzemplarz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kara> Kara { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prolongata> Prolongata { get; set; }
    }
}
