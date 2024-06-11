using Axxes.EfCore.Workshop.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace Axxes.EfCore.Workshop.Tests.Helpers;

public class DbContextHelper
{
    public static MoviesContext CreateMoviesContext()
    {
        // Should come from pipeline/config/env
        var connectionString =
            """
            Data Source = (localdb)\MSSQLLocalDB;
            Initial Catalog = NDC_Oslo_Test;
            Integrated Security = True;
            """;

        var optionsBuilder = new DbContextOptionsBuilder<MoviesContext>()
            .UseSqlServer(connectionString);

        var options = optionsBuilder.Options;

        var context = new MoviesContext(options);

        return context;
    } 
}