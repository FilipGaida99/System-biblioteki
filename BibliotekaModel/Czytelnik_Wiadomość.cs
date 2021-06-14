namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Czytelnik_Wiadomość
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long WiadomośćID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CzytelnikID { get; set; }

        public bool Nadawca { get; set; }

        public bool Przeczytana { get; set; }

        public virtual Czytelnik Czytelnik { get; set; }

        public virtual Wiadomość Wiadomość { get; set; }
    }
}
