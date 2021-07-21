namespace BibliotekaModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja rezerwacji.
    /// </summary>
    [Table("Rezerwacje")]
    public partial class Rezerwacje
    {
        /// <summary>
        /// ID rezerwującego czytelnika.
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CzytelnikID { get; set; }

        /// <summary>
        /// Data rezerwacji.
        /// </summary>
        [Column("Data rezerwacji")]
        public DateTime Data_rezerwacji { get; set; }

        /// <summary>
        /// ID rezerwowanej książki.
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long KsiążkaID { get; set; }

        /// <summary>
        /// Rezerwujący czytelnik.
        /// </summary>
        public virtual Czytelnik Czytelnik { get; set; }

        /// <summary>
        /// Rezerwowania ksiązka.
        /// </summary>
        public virtual Książka Książka { get; set; }
    }
}
