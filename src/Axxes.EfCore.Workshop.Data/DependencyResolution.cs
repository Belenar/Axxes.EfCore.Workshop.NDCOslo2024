﻿using Axxes.EfCore.Workshop.Data.Database;
using Axxes.EfCore.Workshop.Data.Repositories;
using Axxes.EfCore.Workshop.Domain.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Axxes.EfCore.Workshop.Data;

public static class DependencyResolution
{
    public static void Setup(IServiceCollection services)
    {
        services.AddTransient<IMovieRepository, MovieRepository>();

        services.AddDbContext<MoviesContext>(builder =>
        {
            builder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=NDC_Oslo; Integrated Security = True ");
        });
    }
}