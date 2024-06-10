namespace Axxes.EfCore.Workshop.Start
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Action<IServiceCollection> serviceConfig = services =>
            {
                Data.DependencyResolution.Setup(services);
            };

            API.Program.StartWebHost(serviceConfig, args);
        }
    }
}
