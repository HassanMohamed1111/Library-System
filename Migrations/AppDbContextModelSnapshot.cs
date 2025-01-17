﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quiz_2;

#nullable disable

namespace Quiz_2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsAuthorId")
                        .HasColumnType("int");

                    b.Property<int>("booksBookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsAuthorId", "booksBookId");

                    b.HasIndex("booksBookId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<int>("booksBookId")
                        .HasColumnType("int");

                    b.Property<int>("genresGenreId")
                        .HasColumnType("int");

                    b.HasKey("booksBookId", "genresGenreId");

                    b.HasIndex("genresGenreId");

                    b.ToTable("BookGenre");
                });

            modelBuilder.Entity("Quiz_2.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorEmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Quiz_2.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedYear")
                        .HasColumnType("datetime2");

                    b.HasKey("BookId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("Quiz_2.Models.CrediteCard", b =>
                {
                    b.Property<int>("CrediteCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrediteCardId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CrediteCardId");

                    b.HasIndex("AuthorId");

                    b.ToTable("CrediteCards");
                });

            modelBuilder.Entity("Quiz_2.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("Quiz_2.Models.IdentityCard", b =>
                {
                    b.Property<int>("IdentityCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdentityCardId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdentityCardId");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.ToTable("IdentityCards");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Quiz_2.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz_2.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("booksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("Quiz_2.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("booksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz_2.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("genresGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Quiz_2.Models.CrediteCard", b =>
                {
                    b.HasOne("Quiz_2.Models.Author", "Author")
                        .WithMany("CrediteCards")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Quiz_2.Models.IdentityCard", b =>
                {
                    b.HasOne("Quiz_2.Models.Author", "Author")
                        .WithOne("IdentityCard")
                        .HasForeignKey("Quiz_2.Models.IdentityCard", "AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Quiz_2.Models.Author", b =>
                {
                    b.Navigation("CrediteCards");

                    b.Navigation("IdentityCard")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
