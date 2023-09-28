using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_postgres.DEPLOY
{
    public class libContext_Cascade : libContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
                    .OnDelete(DeleteBehavior.SetNull)

                    .HasConstraintName("art_to_read_toread_art_id_fkey")
                    ;



                entity.HasOne(d => d.ToreadAuthor)
                    .WithMany(p => p.ArtToReadToreadAuthors)
                    .HasForeignKey(d => d.ToreadAuthorId)
                    .HasConstraintName("art_to_read_toread_author_id_fkey");
            });


        }
    }
}
