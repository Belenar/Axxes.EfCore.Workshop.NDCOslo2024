using Axxes.EfCore.Workshop.API.Tenant;
using Axxes.EfCore.Workshop.Domain.Tenants;

namespace Axxes.EfCore.Workshop.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StartWebHost(_ => { }, args);
        }

        public static void StartWebHost(
            Action<IServiceCollection> serviceConfig,
            string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.OperationFilter<TenantHeaderSwaggerAttribute>();
            });

            serviceConfig(builder.Services);
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<TenantService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
