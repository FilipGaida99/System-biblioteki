namespace BibliotekaModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja prolongaty.
    /// </summary>
    [Table("Prolongata")]
    public partial class Prolongata
    {
        /// <summary>
        /// ID prolongaty
        /// </summary>
        public long ProlongataID { get; set; }

        /// <summary>
        /// Data prolongaty
        /// </summary>
        [Column("Data prolongaty")]
        public DateTime? Data_prolongaty { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public byte? Status { get; set; }

        /// <summary>
        /// ID wyporzyczenia, którego dotyczy prolongata
        /// </summary>
        public long WypożyczenieID { get; set; }

        /// <summary>
        /// Wyporzyczenie, którego dotyczy prolongata
        /// </summary>
        public virtual Wypożyczenie Wypożyczenie { get; set; }
    }
}
