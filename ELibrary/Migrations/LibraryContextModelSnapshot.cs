﻿// <auto-generated />
using ELibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ELibrary.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ELibrary.Models.AuthorPublisher", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnName("Author_Id")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnName("Publisher_Id")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "PublisherId");

                    b.HasIndex("PublisherId")
                        .HasName("IX_FK_AuthorPublisher_Publisher");

                    b.ToTable("AuthorPublisher");
                });

            modelBuilder.Entity("ELibrary.Models.AuthorSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthorSet");
                });

            modelBuilder.Entity("ELibrary.Models.BookSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .HasName("IX_FK_BookAuthor");

                    b.ToTable("BookSet");
                });

            modelBuilder.Entity("ELibrary.Models.PublisherSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PublisherSet");
                });

            modelBuilder.Entity("ELibrary.Models.AuthorPublisher", b =>
                {
                    b.HasOne("ELibrary.Models.AuthorSet", "Author")
                        .WithMany("AuthorPublisher")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK_AuthorPublisher_Author")
                        .IsRequired();

                    b.HasOne("ELibrary.Models.PublisherSet", "Publisher")
                        .WithMany("AuthorPublisher")
                        .HasForeignKey("PublisherId")
                        .HasConstraintName("FK_AuthorPublisher_Publisher")
                        .IsRequired();
                });

            modelBuilder.Entity("ELibrary.Models.BookSet", b =>
                {
                    b.HasOne("ELibrary.Models.AuthorSet", "Author")
                        .WithMany("BookSet")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK_BookAuthor")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}