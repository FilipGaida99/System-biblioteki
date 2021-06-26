namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja wystawy.
    /// </summary>
    [Table("Wystawa")]
    public partial class Wystawa
    {
        /// <summary>
        /// ID wystawy.
        /// </summary>
        public long WystawaID { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        [StringLength(4000)]
        public string Opis { get; set; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Nazwa { get; set; }

        /// <summary>
        /// Data rozpoczęcia.
        /// </summary>
        [Column("Data rozpoczęcia", TypeName = "date")]
        public DateTime Data_rozpoczęcia { get; set; }

        /// <summary>
        /// Data zakończenia.
        /// </summary>
        [Column("Data zakończenia", TypeName = "date")]
        public DateTime D { get; set; }

        /// <summary>
        /// ID bibliotekarza odpowiedzialnego za wystawę.
        /// </summary>
        public long BibliotekarzID { get; set; }

        /// <summary>
        /// Bibliotekarz odpowiedzialny za wystawę.
        /// </summary>
        public virtual Bibliotekarz Bibliotekarz { get; set; }
    }
}
