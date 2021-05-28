namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prolongata")]
    public partial class Prolongata
    {
        public long ProlongataID { get; set; }

        [Column("Data prolongaty")]
        public DateTime? Data_prolongaty { get; set; }

        public byte? Status { get; set; }

        public long WypożyczenieID { get; set; }

        public virtual Wypożyczenie Wypożyczenie { get; set; }
    }
}
