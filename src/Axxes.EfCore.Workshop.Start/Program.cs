using System.Runtime.InteropServices;

namespace Axxes.EfCore.Workshop.Start
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Action<IServiceCollection> serviceConfig = services =>
            {
            };

            API.Program.StartWebHost(serviceConfig, args);
        }
    }
}
