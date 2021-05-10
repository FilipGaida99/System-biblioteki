namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rezerwacje")]
    public partial class Rezerwacje
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CzytelnikID { get; set; }

        [Column("Data rezerwacji")]
        public DateTime Data_rezerwacji { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long KsiążkaID { get; set; }

        public virtual Czytelnik Czytelnik { get; set; }

        public virtual Książka Książka { get; set; }
    }
}
