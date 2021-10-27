using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using anaconda.Domain;
using anaconda.Model;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace anaconda
{
    public static class Functions
    {
        [Function("Info")]
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
}