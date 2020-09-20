using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ELibrary.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorPublisher> AuthorPublisher { get; set; }
        public virtual DbSet<AuthorSet> AuthorSet { get; set; }
        public virtual DbSet<BookSet> BookSet { get; set; }
        public virtual DbSet<PublisherSet> PublisherSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorPublisher>(entity =>
            {
                entity.HasKey(e => new { e.AuthorId, e.PublisherId });

                entity.HasIndex(e => e.PublisherId)
                    .HasName("IX_FK_AuthorPublisher_Publisher");

                entity.Property(e => e.AuthorId).HasColumnName("Author_Id");

                entity.Property(e => e.PublisherId).HasColumnName("Publisher_Id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorPublisher)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorPublisher_Author");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.AuthorPublisher)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorPublisher_Publisher");
            });

            modelBuilder.Entity<AuthorSet>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<BookSet>(entity =>
            {
                entity.HasIndex(e => e.AuthorId)
                    .HasName("IX_FK_BookAuthor");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookSet)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookAuthor");
            });

            modelBuilder.Entity<PublisherSet>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
