
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ToDoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
    public static class DBConfiguration
{
    public static string ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=todo;";
}
}
