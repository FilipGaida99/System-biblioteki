namespace BibliotekaModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja kary.
    /// </summary>
    [Table("Kara")]
    public partial class Kara
    {
        /// <summary>
        /// ID kary.
        /// </summary>
        public long KaraID { get; set; }

        /// <summary>
        /// Data nałożenia kary.
        /// </summary>
        [Column("Data nałożenia")]
        public DateTime Data_nałożenia { get; set; }

        /// <summary>
        /// Data amnestii.
        /// </summary>
        [Column("Data amnestii")]
        public DateTime? Data_amnestii { get; set; }

        /// <summary>
        /// ID wypożyczenia, którego dotyczy kara.
        /// </summary>
        public long WypożyczenieID { get; set; }

        /// <summary>
        /// Wypożyczenie, którego dotyczy kara.
        /// </summary>
        public virtual Wypożyczenie Wypożyczenie { get; set; }
    }
}
