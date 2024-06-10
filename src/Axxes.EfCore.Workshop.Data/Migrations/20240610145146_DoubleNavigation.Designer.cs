﻿// <auto-generated />
using System;
using Axxes.EfCore.Workshop.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Axxes.EfCore.Workshop.Data.Migrations
{
    [DbContext(typeof(MoviesContext))]
    [Migration("20240610145146_DoubleNavigation")]
    partial class DoubleNavigation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MainGenreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("SecondaryGenreId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("MovieTitle");

                    b.HasKey("ItemKey");

                    b.HasIndex("MainGenreId");

                    b.HasIndex("SecondaryGenreId");

                    b.ToTable("MotionPictures", (string)null);
                });

            modelBuilder.Entity("Axxes.EfCore.Workshop.Domain.Models.Movie", b =>
                {
                    b.HasOne("Axxes.EfCore.Workshop.Domain.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("MainGenreId");

                    b.HasOne("Axxes.EfCore.Workshop.Domain.Models.Genre", "SecondaryGenre")
                        .WithMany()
                        .HasForeignKey("SecondaryGenreId");

                    b.Navigation("Genre");

                    b.Navigation("SecondaryGenre");
                });

            modelBuilder.Entity("Axxes.EfCore.Workshop.Domain.Models.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
