using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace anaconda
{
    public static class Start
    {
        [Function("Start")]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "anaconda/start")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger(nameof(Start));
            logger.LogInformation("C# HTTP trigger function processed a request.");
            
            //response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            //response.WriteString("Welcome to Azure Functions!");

            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}