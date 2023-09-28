using System;
using System.Collections.Generic;
using lib_postgres.CRUD;
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
        public virtual DbSet<ArtRead> ArtReads { get; set; } = null!;
        public virtual DbSet<ArtSpecRegister> ArtSpecRegisters { get; set; } = null!;
        public virtual DbSet<ArtToRead> ArtToReads { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<AuthorArt> AuthorArts { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookFormat> BookFormats { get; set; } = null!;
        public virtual DbSet<ChifresName> ChifresNames { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Place> Places { get; set; } = null!;
        public virtual DbSet<Possession> Possessions { get; set; } = null!;
        public virtual DbSet<PublishingHouse> PublishingHouses { get; set; } = null!;
        public virtual DbSet<Query> Queries { get; set; } = null!;
        public virtual DbSet<Series> Series { get; set; } = null!;
        public virtual DbSet<SourceToreadAnother> SourceToreadAnothers { get; set; } = null!;
        public virtual DbSet<SpecRegisterAttribute> SpecRegisterAttributes { get; set; } = null!;
        public virtual DbSet<ViewAction> ViewActions { get; set; } = null!;
        public virtual DbSet<ViewAllRealBook> ViewAllRealBooks { get; set; } = null!;
        public virtual DbSet<ViewArt> ViewArts { get; set; } = null!;
        public virtual DbSet<ViewBook> ViewBooks { get; set; } = null!;
        public virtual DbSet<ViewCode> ViewCodes { get; set; } = null!;
        public virtual DbSet<ViewGenre> ViewGenres { get; set; } = null!;
        public virtual DbSet<ViewHasRead> ViewHasReads { get; set; } = null!;
        public virtual DbSet<ViewMyBook> ViewMyBooks { get; set; } = null!;
        public virtual DbSet<ViewMyBooksInOtherHand> ViewMyBooksInOtherHands { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql(DB_Agent.Get_Connection_String()); 
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

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

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

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Operation).HasColumnName("operation");
            });

            modelBuilder.Entity<Art>(entity =>
            {
                entity.ToTable("art");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

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

            modelBuilder.Entity<ArtRead>(entity =>
            {
                entity.ToTable("art_read");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ArtId).HasColumnName("art_id");

                entity.Property(e => e.BookFormatId).HasColumnName("book_format_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .HasColumnName("comment");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.MarkId).HasColumnName("mark_id");

                entity.Property(e => e.ReadLanguageId).HasColumnName("read_language_id");

                entity.HasOne(d => d.Art)
                    .WithMany(p => p.ArtReads)
                    .HasForeignKey(d => d.ArtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("art_read_art_id_fkey");

                entity.HasOne(d => d.BookFormat)
                    .WithMany(p => p.ArtReads)
                    .HasForeignKey(d => d.BookFormatId)
                    .HasConstraintName("art_read_book_format_id_fkey");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.ArtReads)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("art_read_book_id_fkey");

                entity.HasOne(d => d.Mark)
                    .WithMany(p => p.ArtReads)
                    .HasForeignKey(d => d.MarkId)
                    .HasConstraintName("art_read_mark_id_fkey");

                entity.HasOne(d => d.ReadLanguage)
                    .WithMany(p => p.ArtReads)
                    .HasForeignKey(d => d.ReadLanguageId)
                    .HasConstraintName("art_read_read_language_id_fkey");
            });

            modelBuilder.Entity<ArtSpecRegister>(entity =>
            {
                entity.ToTable("art_spec_register");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ArtId).HasColumnName("art_id");

                entity.Property(e => e.Comment)
                    .HasColumnType("char")
                    .HasColumnName("comment");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.SpecRegisterAttributeId).HasColumnName("spec_register_attribute_id");

                entity.HasOne(d => d.Art)
                    .WithMany(p => p.ArtSpecRegisters)
                    .HasForeignKey(d => d.ArtId)
                    .HasConstraintName("art_spec_register_art_id_fkey");

                entity.HasOne(d => d.SpecRegisterAttribute)
                    .WithMany(p => p.ArtSpecRegisters)
                    .HasForeignKey(d => d.SpecRegisterAttributeId)
                    .HasConstraintName("art_spec_register_spec_register_attribute_id_fkey");
            });

            modelBuilder.Entity<ArtToRead>(entity =>
            {
                entity.ToTable("art_to_read");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Comment)
                    .HasColumnType("character varying")
                    .HasColumnName("comment");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.SourceAnotherId).HasColumnName("source_another_id");

                entity.Property(e => e.SourceArtId).HasColumnName("source_art_id");

                entity.Property(e => e.SourceAuthorId).HasColumnName("source_author_id");

                entity.Property(e => e.ToreadArtId).HasColumnName("toread_art_id");

                entity.Property(e => e.ToreadAuthorId).HasColumnName("toread_author_id");

                entity.HasOne(d => d.SourceAnother)
                    .WithMany(p => p.ArtToReads)
                    .HasForeignKey(d => d.SourceAnotherId)
                    .HasConstraintName("art_to_read_source_another_id_fkey");

                entity.HasOne(d => d.SourceArt)
                    .WithMany(p => p.ArtToReadSourceArts)
                    .HasForeignKey(d => d.SourceArtId)
                    .HasConstraintName("art_to_read_source_art_id_fkey");

                entity.HasOne(d => d.SourceAuthor)
                    .WithMany(p => p.ArtToReadSourceAuthors)
                    .HasForeignKey(d => d.SourceAuthorId)
                    .HasConstraintName("art_to_read_source_author_id_fkey");

                entity.HasOne(d => d.ToreadArt)
                    .WithMany(p => p.ArtToReadToreadArts)
                    .HasForeignKey(d => d.ToreadArtId)
                    .HasConstraintName("art_to_read_toread_art_id_fkey");

                entity.HasOne(d => d.ToreadAuthor)
                    .WithMany(p => p.ArtToReadToreadAuthors)
                    .HasForeignKey(d => d.ToreadAuthorId)
                    .HasConstraintName("art_to_read_toread_author_id_fkey");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

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

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.HasOne(d => d.ArtNavigation)
                    .WithMany(p => p.AuthorArts)
                    .HasForeignKey(d => d.Art)
                    .HasConstraintName("author_art_art_fkey");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.AuthorArts)
                    .HasForeignKey(d => d.Author)
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

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

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

            modelBuilder.Entity<BookFormat>(entity =>
            {
                entity.ToTable("book_format");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
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

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('\"City_id_seq\"'::regclass)");

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

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

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

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

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

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

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("mark");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("people");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

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

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

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

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

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

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Query>(entity =>
            {
                entity.ToTable("query");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Text).HasColumnName("text");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.ToTable("series");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SourceToreadAnother>(entity =>
            {
                entity.ToTable("source_toread_another");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Comment)
                    .HasColumnType("character varying")
                    .HasColumnName("comment");

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SpecRegisterAttribute>(entity =>
            {
                entity.ToTable("spec_register_attribute");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Comment)
                    .HasColumnType("character varying")
                    .HasColumnName("comment");

                entity.Property(e => e.IsDeleted).HasColumnName("_is_deleted");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ViewAction>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_actions");

                entity.Property(e => e.ActionId).HasColumnName("action_id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .HasColumnName("comment");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Place)
                    .HasMaxLength(100)
                    .HasColumnName("place");
            });

            modelBuilder.Entity<ViewAllRealBook>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_all_real_books");

                entity.Property(e => e.UniqueBookId).HasColumnName("unique_book_id");

                entity.Property(e => e.АвторЫ).HasColumnName("Автор(ы)");

                entity.Property(e => e.ГодИздания).HasColumnName("Год издания");

                entity.Property(e => e.Движ)
                    .HasMaxLength(100)
                    .HasColumnName("Движ.");

                entity.Property(e => e.Действие).HasMaxLength(100);

                entity.Property(e => e.Жанр).HasMaxLength(100);

                entity.Property(e => e.Издательство).HasMaxLength(100);

                entity.Property(e => e.Место).HasMaxLength(100);

                entity.Property(e => e.Название).HasMaxLength(100);

                entity.Property(e => e.Шифр).HasMaxLength(100);

                entity.Property(e => e.ЯзыкИздания)
                    .HasColumnType("character varying")
                    .HasColumnName("Язык издания");

                entity.Property(e => e.ЯзыкНаписания)
                    .HasColumnType("character varying")
                    .HasColumnName("Язык написания");
            });

            modelBuilder.Entity<ViewArt>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_arts");

                entity.Property(e => e.АвторЫ).HasColumnName("Автор(ы)");

                entity.Property(e => e.Жанр).HasMaxLength(100);

                entity.Property(e => e.Название).HasMaxLength(100);
            });

            modelBuilder.Entity<ViewBook>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_books");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.АвторЫ).HasColumnName("Автор(ы)");

                entity.Property(e => e.ГодИздания).HasColumnName("Год издания");

                entity.Property(e => e.Жанр).HasMaxLength(100);

                entity.Property(e => e.Издательство).HasMaxLength(100);

                entity.Property(e => e.Название).HasMaxLength(100);

                entity.Property(e => e.Шифр).HasMaxLength(100);
            });

            modelBuilder.Entity<ViewCode>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_codes");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .HasColumnName("code");

                entity.Property(e => e.Genre)
                    .HasMaxLength(100)
                    .HasColumnName("genre");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ViewGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_genres");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ViewHasRead>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_has_read");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.АвторЫ).HasColumnName("Автор(ы)");

                entity.Property(e => e.Впечатление).HasMaxLength(255);

                entity.Property(e => e.Жанр).HasMaxLength(100);

                entity.Property(e => e.Название).HasMaxLength(100);

                entity.Property(e => e.Оценка).HasMaxLength(30);

                entity.Property(e => e.Формат).HasMaxLength(30);

                entity.Property(e => e.ЯзыкОригинала)
                    .HasColumnType("character varying")
                    .HasColumnName("Язык оригинала");
            });

            modelBuilder.Entity<ViewMyBook>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_my_books");

                entity.Property(e => e.UniqueBookId).HasColumnName("unique_book_id");

                entity.Property(e => e.АвторЫ).HasColumnName("Автор(ы)");

                entity.Property(e => e.ГодИздания).HasColumnName("Год издания");

                entity.Property(e => e.Движ)
                    .HasMaxLength(100)
                    .HasColumnName("Движ.");

                entity.Property(e => e.Действие).HasMaxLength(100);

                entity.Property(e => e.Жанр).HasMaxLength(100);

                entity.Property(e => e.Издательство).HasMaxLength(100);

                entity.Property(e => e.Место).HasMaxLength(100);

                entity.Property(e => e.Название).HasMaxLength(100);

                entity.Property(e => e.Шифр).HasMaxLength(100);

                entity.Property(e => e.ЯзыкИздания)
                    .HasColumnType("character varying")
                    .HasColumnName("Язык издания");

                entity.Property(e => e.ЯзыкНаписания)
                    .HasColumnType("character varying")
                    .HasColumnName("Язык написания");
            });

            modelBuilder.Entity<ViewMyBooksInOtherHand>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_my_books_in_other_hands");

                entity.Property(e => e.UniqueBookId).HasColumnName("unique_book_id");

                entity.Property(e => e.АвторЫ).HasColumnName("Автор(ы)");

                entity.Property(e => e.ГодИздания).HasColumnName("Год издания");

                entity.Property(e => e.Движ)
                    .HasMaxLength(100)
                    .HasColumnName("Движ.");

                entity.Property(e => e.Действие).HasMaxLength(100);

                entity.Property(e => e.Жанр).HasMaxLength(100);

                entity.Property(e => e.Издательство).HasMaxLength(100);

                entity.Property(e => e.Место).HasMaxLength(100);

                entity.Property(e => e.Название).HasMaxLength(100);

                entity.Property(e => e.Шифр).HasMaxLength(100);

                entity.Property(e => e.ЯзыкИздания)
                    .HasColumnType("character varying")
                    .HasColumnName("Язык издания");

                entity.Property(e => e.ЯзыкНаписания)
                    .HasColumnType("character varying")
                    .HasColumnName("Язык написания");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
