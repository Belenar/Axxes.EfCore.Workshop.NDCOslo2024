﻿// <auto-generated />
using System;
using Axxes.EfCore.Workshop.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Axxes.EfCore.Workshop.Data.Migrations
{
    [DbContext(typeof(MoviesContext))]
    partial class MoviesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Axxes.EfCore.Workshop.Domain.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Axxes.EfCore.Workshop.Domain.Models.Movie", b =>
                {
                    b.Property<int>("ItemKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemKey"));

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MainGenreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("MovieTitle");

                    b.HasKey("ItemKey");

                    b.HasIndex("MainGenreId");

                    b.ToTable("MotionPictures", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("SecondaryGenresId")
                        .HasColumnType("int");

                    b.Property<int>("SecondaryMoviesItemKey")
                        .HasColumnType("int");

                    b.HasKey("SecondaryGenresId", "SecondaryMoviesItemKey");

                    b.HasIndex("SecondaryMoviesItemKey");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("Axxes.EfCore.Workshop.Domain.Models.CinemaMovie", b =>
                {
                    b.HasBaseType("Axxes.EfCore.Workshop.Domain.Models.Movie");

                    b.Property<decimal>("BoxOfficeRevenue")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("CinemaMovies", (string)null);
                });

            modelBuilder.Entity("Axxes.EfCore.Workshop.Domain.Models.TelevisionMovie", b =>
                {
                    b.HasBaseType("Axxes.EfCore.Workshop.Domain.Models.Movie");

                    b.Property<string>("NetworkFirstAiredOn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("TelevisionMovies", (string)null);
                });

            modelBuilder.Entity("Axxes.EfCore.Workshop.Domain.Models.Movie", b =>
                {
                    b.HasOne("Axxes.EfCore.Workshop.Domain.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("MainGenreId");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("Axxes.EfCore.Workshop.Domain.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("SecondaryGenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Axxes.EfCore.Workshop.Domain.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("SecondaryMoviesItemKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Axxes.EfCore.Workshop.Domain.Models.CinemaMovie", b =>
                {
                    b.HasOne("Axxes.EfCore.Workshop.Domain.Models.Movie", null)
                        .WithOne()
                        .HasForeignKey("Axxes.EfCore.Workshop.Domain.Models.CinemaMovie", "ItemKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Axxes.EfCore.Workshop.Domain.Models.TelevisionMovie", b =>
                {
                    b.HasOne("Axxes.EfCore.Workshop.Domain.Models.Movie", null)
                        .WithOne()
                        .HasForeignKey("Axxes.EfCore.Workshop.Domain.Models.TelevisionMovie", "ItemKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Axxes.EfCore.Workshop.Domain.Models.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
