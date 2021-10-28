using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Anaconda.Domain;
using Anaconda.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
//using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace anaconda
{

    public static class HttpExample
    {
        [FunctionName("Info")]
        public static async Task<IActionResult> HandleInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "anaconda/")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name ??= data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            // var logger = log. executionContext.GetLogger(nameof(HandleInfo));
            log.LogInformation("C# HTTP trigger function processed a request.");

            // return await req.CreateJsonResponse(new SnakeInfo());
            return new OkObjectResult(new SnakeInfo());
        }
    }

    /*
    public static class Functions
    {
        [FunctionName("Info")]
        public static async Task<HttpResponseData> HandleInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "anaconda/")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger(nameof(HandleInfo));
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await req.CreateJsonResponse(new SnakeInfo());
        }

        [Function("Start")]
        public static HttpResponseData HandleStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "anaconda/start")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger(nameof(HandleStart));
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return req.CreateResponse(HttpStatusCode.OK);
        }

        [Function("Move")]
        public static async Task<HttpResponseData> HandleMove(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "anaconda/move")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var timer = Stopwatch.StartNew();
            var logger = executionContext.GetLogger(nameof(HandleMove));

            var gameState = await req.ReadFromJsonAsync<GameState>();

            logger.LogInformation("Start decision...");
            timer.Restart();
            var move = DecisionMaker.CalculateMove(gameState, logger);
            logger.LogInformation("Move decided in {ElapsedMilliseconds} ms", timer.ElapsedMilliseconds);

            return await req.CreateJsonResponse(move);
        }

        [Function("End")]
        public static HttpResponseData HandleEnd(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "anaconda/end")] HttpRequestData req,
            FunctionContext executionContext) =>
            req.CreateResponse(HttpStatusCode.OK);
    }

    */
}