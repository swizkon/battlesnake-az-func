using System.Threading.Tasks;
using anaconda.Model;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace anaconda
{
    public static class Info
    {
        [Function("Info")]
        public static async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "anaconda/")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Info");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = await req.CreateJsonResponse(new SnakeInfo());
            
            return response;
        }
    }
}
