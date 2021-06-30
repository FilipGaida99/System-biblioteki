using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Biblioteka
{
    /// <summary>
    /// Klasa odpowiedzialna za komunikację z bazą danych.
    /// </summary>
    public partial class BibliotekaDB : DbContext
    {
        public BibliotekaDB()
            : base("name=BibliotekaDB")
        {
        }

        /// <summary>
        /// Zbiór objektów encji Autor.
        /// </summary>
        public virtual DbSet<Autor> Autor { get; set; }
        /// <summary>
        /// Zbiór objektów encji Bibliotekarz.
        /// </summary>
        public virtual DbSet<Bibliotekarz> Bibliotekarz { get; set; }
        /// <summary>
        /// Zbiór objektów encji Bibliotekarz_Wiadomość.
        /// </summary>
        public virtual DbSet<Bibliotekarz_Wiadomość> Bibliotekarz_Wiadomość { get; set; }
        /// <summary>
        /// Zbiór objektów encji Czytelnik.
        /// </summary>
        public virtual DbSet<Czytelnik> Czytelnik { get; set; }
        /// <summary>
        /// Zbiór objektów encji Czytelnik_Wiadomość.
        /// </summary>
        public virtual DbSet<Czytelnik_Wiadomość> Czytelnik_Wiadomość { get; set; }
        /// <summary>
        /// Zbiór objektów encji Egzemplarz.
        /// </summary>
        public virtual DbSet<Egzemplarz> Egzemplarz { get; set; }
        /// <summary>
        /// Zbiór objektów encji Egzemplarz_elektroniczny.
        /// </summary>
        public virtual DbSet<Egzemplarz_elektroniczny> Egzemplarz_elektroniczny { get; set; }
        /// <summary>
        /// Zbiór objektów encji Kara.
        /// </summary>
        public virtual DbSet<Kara> Kara { get; set; }
        /// <summary>
        /// Zbiór objektów encji Książka.
        /// </summary>
        public virtual DbSet<Książka> Książka { get; set; }
        /// <summary>
        /// Zbiór objektów encji Prolongata.
        /// </summary>
        public virtual DbSet<Prolongata> Prolongata { get; set; }
        /// <summary>
        /// Zbiór objektów encji Rezerwacje.
        /// </summary>
        public virtual DbSet<Rezerwacje> Rezerwacje { get; set; }
        /// <summary>
        /// Zbiór objektów encji Wiadomość.
        /// </summary>
        public virtual DbSet<Wiadomość> Wiadomość { get; set; }
        /// <summary>
        /// Zbiór objektów encji Wydawnictwo.
        /// </summary>
        public virtual DbSet<Wydawnictwo> Wydawnictwo { get; set; }
        /// <summary>
        /// Zbiór objektów encji Wypożyczenie.
        /// </summary>
        public virtual DbSet<Wypożyczenie> Wypożyczenie { get; set; }
        /// <summary>
        /// Zbiór objektów encji Wystawa.
        /// </summary>
        public virtual DbSet<Wystawa> Wystawa { get; set; }

        /// <summary>
        /// Dodanie ograniczeń do encji podczas tworzenia modelu.
        /// </summary>
        /// <param name="modelBuilder">Konfigurator modelu.</param>
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
                .WillCascadeOnDelete();

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
                .HasMany(e => e.Książka);

            modelBuilder.Entity<Wypożyczenie>()
                .HasMany(e => e.Kara)
                .WithRequired(e => e.Wypożyczenie)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Wypożyczenie>()
                .HasMany(e => e.Prolongata)
                .WithRequired(e => e.Wypożyczenie)
                .WillCascadeOnDelete();
        }
    }
}
