using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace anaconda
{
    public static class End
    {
        [Function("End")]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "anaconda/end")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger(nameof(End));
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}