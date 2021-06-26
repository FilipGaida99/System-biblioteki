namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Encja egzemplarza elektronicznego.
    /// </summary>
    [Table("Egzemplarz elektroniczny")]
    public partial class Egzemplarz_elektroniczny
    {
        /// <summary>
        /// Odnośnik do książki elektronicznej.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Odnośnik { get; set; }

        /// <summary>
        /// Numer Inwentarza.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Nr_inwentarza { get; set; }

        /// <summary>
        /// Egzemplarz.
        /// </summary>
        public virtual Egzemplarz Egzemplarz { get; set; }
    }
}
