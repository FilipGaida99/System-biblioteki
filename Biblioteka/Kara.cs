namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kara")]
    public partial class Kara
    {
        public long KaraID { get; set; }

        [Column("Data nałożenia")]
        public DateTime Data_nałożenia { get; set; }

        [Column("Data amnestii")]
        public DateTime? Data_amnestii { get; set; }

        public long WypożyczenieID { get; set; }

        public virtual Wypożyczenie Wypożyczenie { get; set; }
    }
}
