namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wystawa")]
    public partial class Wystawa
    {
        public long WystawaID { get; set; }

        [StringLength(4000)]
        public string Opis { get; set; }

        [Required]
        [StringLength(50)]
        public string Nazwa { get; set; }

        [Column("Data rozpoczęcia", TypeName = "date")]
        public DateTime Data_rozpoczęcia { get; set; }

        [Column("Data zakończenia", TypeName = "date")]
        public DateTime Data_zakończenia { get; set; }

        public long BibliotekarzID { get; set; }

        public virtual Bibliotekarz Bibliotekarz { get; set; }
    }
}
