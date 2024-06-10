﻿using Axxes.EfCore.Workshop.Data.Database.ValueConverters;
using Axxes.EfCore.Workshop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Axxes.EfCore.Workshop.Data.Database.Mapping;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder
            .ToTable("MotionPictures")
            .HasKey(movie => movie.ItemKey);

        builder
            .Property(movie => movie.Title)
            .HasMaxLength(128)
            .HasColumnName("MovieTitle");

        builder.Property(movie => movie.ReleaseDate)
            .HasColumnType("datetime")
            .HasConversion(new DateOnlyToDateTimeConverter());
    }
}

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder
            .HasMany(genre => genre.Movies)
            .WithOne(movie => movie.Genre)
            .HasPrincipalKey(genre => genre.Id)
            .HasForeignKey(movie => movie.MainGenreId);

        builder
            .HasMany(genre => genre.SecondaryMovies)
            .WithMany(movie => movie.SecondaryGenres);
    }
}