using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ViServiceAdapter
{
    internal class Program
    {
        public static Options Options;
        static void Main(string[] args)
        {
            Console.WriteLine("Vi Service Adapter Start!");

            var result = Parser.Default.ParseArguments<Options>(args);
            if (result.Errors.Any())
                return;

            Options = result.Value;
            Console.WriteLine(Options);
            //return;
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
           Host
               .CreateDefaultBuilder(args)
               .UseWindowsService(options =>
               {
                   options.ServiceName = Options.ServiceName;
               })
               .ConfigureServices((context, collection) =>
               {
                   collection.AddHostedService<AdapterService>();
               });
    }
}