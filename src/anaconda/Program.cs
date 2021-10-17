using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;

namespace anaconda
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults(builder =>
                {
                    builder.UseFunctionExecutionMiddleware();
                })
                //.ConfigureHostConfiguration(builder =>
                //{
                //    // builder.AddUserSecrets<>()
                //    builder.
                //})
                //.ConfigureFunctionsWorker((context, builder) =>
                //{
                //    builder.UseFunctionExecutionMiddleware();
                //})
                .Build();
            host.Run();
        }
    }
}