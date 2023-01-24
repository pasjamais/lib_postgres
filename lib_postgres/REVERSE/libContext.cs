using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lib_postgres
{
    public partial class libContext : DbContext
    {
        public libContext()
        {
        }

        public libContext(DbContextOptions<libContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Actions { get; set; } = null!;
        public virtual DbSet<ActionType> ActionTypes { get; set; } = null!;
        public virtual DbSet<Art> Arts { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<AuthorArt> AuthorArts { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Book1> Books1 { get; set; } = null!;
        public virtual DbSet<ChifresName> ChifresNames { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Genre1> Genres1 { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Place> Places { get; set; } = null!;
        public virtual DbSet<Possession> Possessions { get; set; } = null!;
        public virtual DbSet<PublishingHouse> PublishingHouses { get; set; } = null!;
        public virtual DbSet<Series> Series { get; set; } = null!;
        public virtual DbSet<Произведения> Произведенияs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=lib;Username=postgres;Password=62013");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("action");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionType).HasColumnName("action_type");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .HasColumnName("comment");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Place).HasColumnName("place");

                entity.HasOne(d => d.ActionTypeNavigation)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.ActionType)
                    .HasConstraintName("action_action_type_fkey");

                entity.HasOne(d => d.PlaceNavigation)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.Place)
                    .HasConstraintName("action_place_fkey");
            });

            modelBuilder.Entity<ActionType>(entity =>
            {
                entity.ToTable("action_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Art>(entity =>
            {
                entity.ToTable("art");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.OrigLanguage).HasColumnName("orig_language");

                entity.Property(e => e.WritingYear).HasColumnName("writing_year");

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.Arts)
                    .HasForeignKey(d => d.Genre)
                    .HasConstraintName("art_genre_fkey");

                entity.HasOne(d => d.OrigLanguageNavigation)
                    .WithMany(p => p.Arts)
                    .HasForeignKey(d => d.OrigLanguage)
                    .HasConstraintName("art_orig_language_fkey");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AuthorArt>(entity =>
            {
                entity.ToTable("author_art");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Art).HasColumnName("art");

                entity.Property(e => e.Author).HasColumnName("author");

                entity.HasOne(d => d.ArtNavigation)
                    .WithMany(p => p.AuthorArts)
                    .HasForeignKey(d => d.Art)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("author_art_art_fkey");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.AuthorArts)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("author_art_author_fkey");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .HasColumnName("code");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.FamilyNotes).HasColumnName("family_notes");

                entity.Property(e => e.HasJacket).HasColumnName("has_jacket");

                entity.Property(e => e.IdArt).HasColumnName("id_art");

                entity.Property(e => e.IdCity).HasColumnName("id_city");

                entity.Property(e => e.IdLanguage).HasColumnName("id_language");

                entity.Property(e => e.IdPublishingHouse).HasColumnName("id_publishing_house");

                entity.Property(e => e.IdSeries).HasColumnName("id_series");

                entity.Property(e => e.IsArtBook).HasColumnName("is_art_book");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.PublicationYear).HasColumnName("publication_year");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.IdArtNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdArt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_id_art_fkey");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdCity)
                    .HasConstraintName("book_id_city_fkey");

                entity.HasOne(d => d.IdLanguageNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdLanguage)
                    .HasConstraintName("book_id_language_fkey");

                entity.HasOne(d => d.IdPublishingHouseNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdPublishingHouse)
                    .HasConstraintName("book_id_publishing_house_fkey");

                entity.HasOne(d => d.IdSeriesNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdSeries)
                    .HasConstraintName("book_id_series_fkey");
            });

            modelBuilder.Entity<Book1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("books");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.АвторЫ).HasColumnName("Автор(ы)");

                entity.Property(e => e.ГодИздания).HasColumnName("Год издания");

                entity.Property(e => e.Жанр).HasMaxLength(100);

                entity.Property(e => e.Издательство).HasMaxLength(100);

                entity.Property(e => e.Название).HasMaxLength(100);

                entity.Property(e => e.Шифр).HasMaxLength(100);
            });

            modelBuilder.Entity<ChifresName>(entity =>
            {
                entity.HasKey(e => e.IdGenre)
                    .HasName("chifres_names_pkey");

                entity.ToTable("chifres_names");

                entity.Property(e => e.IdGenre)
                    .ValueGeneratedNever()
                    .HasColumnName("id_genre");

                entity.Property(e => e.Chifre).HasColumnName("chifre");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('\"City_id_seq\"'::regclass)");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Genre1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("genres");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bref)
                    .HasMaxLength(5)
                    .HasColumnName("bref");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('registration_id_seq'::regclass)");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.Book).HasColumnName("book");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .HasColumnName("comment");

                entity.Property(e => e.Operation).HasColumnName("operation");

                entity.Property(e => e.Owner).HasColumnName("owner");

                entity.Property(e => e.Place).HasColumnName("place");

                entity.HasOne(d => d.ActionNavigation)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.Action)
                    .HasConstraintName("location_action_fkey");

                entity.HasOne(d => d.BookNavigation)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.Book)
                    .HasConstraintName("location_book_fkey");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("locationn_owner_fkey");

                entity.HasOne(d => d.PlaceNavigation)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.Place)
                    .HasConstraintName("location_place_fkey");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("people");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("place");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .HasColumnName("comment");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Possession>(entity =>
            {
                entity.ToTable("possession");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.Book).HasColumnName("book");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .HasColumnName("comment");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Person).HasColumnName("person");

                entity.HasOne(d => d.ActionNavigation)
                    .WithMany(p => p.Possessions)
                    .HasForeignKey(d => d.Action)
                    .HasConstraintName("possession_action_fkey");

                entity.HasOne(d => d.BookNavigation)
                    .WithMany(p => p.Possessions)
                    .HasForeignKey(d => d.Book)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("possession_book_fkey");

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Possessions)
                    .HasForeignKey(d => d.Person)
                    .HasConstraintName("possession_person_fkey");
            });

            modelBuilder.Entity<PublishingHouse>(entity =>
            {
                entity.ToTable("publishing_house");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.ToTable("series");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Произведения>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("произведения");

                entity.Property(e => e.АвторЫ).HasColumnName("Автор(ы)");

                entity.Property(e => e.Жанр).HasMaxLength(100);

                entity.Property(e => e.Название).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
