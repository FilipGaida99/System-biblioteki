namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Egzemplarz elektroniczny")]
    public partial class Egzemplarz_elektroniczny
    {
        [Required]
        [StringLength(50)]
        public string Odnośnik { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Nr_inwentarza { get; set; }

        public virtual Egzemplarz Egzemplarz { get; set; }
    }
}
