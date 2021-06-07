using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Biblioteka
{
    public partial class BibliotekaDB : DbContext
    {
        public BibliotekaDB()
            : base("name=BibliotekaDB")
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Bibliotekarz> Bibliotekarz { get; set; }
        public virtual DbSet<Bibliotekarz_Wiadomość> Bibliotekarz_Wiadomość { get; set; }
        public virtual DbSet<Czytelnik> Czytelnik { get; set; }
        public virtual DbSet<Czytelnik_Wiadomość> Czytelnik_Wiadomość { get; set; }
        public virtual DbSet<Egzemplarz> Egzemplarz { get; set; }
        public virtual DbSet<Egzemplarz_elektroniczny> Egzemplarz_elektroniczny { get; set; }
        public virtual DbSet<Kara> Kara { get; set; }
        public virtual DbSet<Książka> Książka { get; set; }
        public virtual DbSet<Prolongata> Prolongata { get; set; }
        public virtual DbSet<Rezerwacje> Rezerwacje { get; set; }
        public virtual DbSet<Wiadomość> Wiadomość { get; set; }
        public virtual DbSet<Wydawnictwo> Wydawnictwo { get; set; }
        public virtual DbSet<Wypożyczenie> Wypożyczenie { get; set; }
        public virtual DbSet<Wystawa> Wystawa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .HasMany(e => e.Książka)
                .WithMany(e => e.Autor)
                .Map(m => m.ToTable("Książka_Autor").MapLeftKey("AutorID").MapRightKey("KsiążkaID"));

            modelBuilder.Entity<Bibliotekarz>()
                .Property(e => e.Adres_email)
                .IsUnicode(false);

            modelBuilder.Entity<Bibliotekarz>()
                .HasMany(e => e.Wystawa)
                .WithRequired(e => e.Bibliotekarz)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Czytelnik>()
                .Property(e => e.Adres_email)
                .IsUnicode(false);

            modelBuilder.Entity<Egzemplarz>()
                .HasOptional(e => e.Egzemplarz_elektroniczny)
                .WithRequired(e => e.Egzemplarz)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Egzemplarz_elektroniczny>()
                .Property(e => e.Odnośnik)
                .IsUnicode(false);

            modelBuilder.Entity<Książka>()
                .Property(e => e.ISBN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Wydawnictwo>()
                .HasMany(e => e.Książka)
                .WithRequired(e => e.Wydawnictwo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Wypożyczenie>()
                .HasMany(e => e.Kara)
                .WithRequired(e => e.Wypożyczenie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Wypożyczenie>()
                .HasMany(e => e.Prolongata)
                .WithRequired(e => e.Wypożyczenie)
                .WillCascadeOnDelete(false);
        }
    }
}
