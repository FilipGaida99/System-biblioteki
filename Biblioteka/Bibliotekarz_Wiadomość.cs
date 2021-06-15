namespace Biblioteka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bibliotekarz_Wiadomość
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long WiadomośćID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long BibliotekarzID { get; set; }

        public bool Nadawca { get; set; }

        //null - nieprzeczytane
        //1 - przeczytane
        //2 - usunięte
        public byte? Stan { get; set; }

        public virtual Bibliotekarz Bibliotekarz { get; set; }

        public virtual Wiadomość Wiadomość { get; set; }
    }
}
