using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using anaconda.Model;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace anaconda
{
    public static class Move
    {
        [Function(nameof(Move))]
        public static async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "anaconda/move")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Info");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(new MoveResponse
            {
                Move = "up" ,
                Shout = "Yeah, like..."
            });

            return response;
        }
    }
}