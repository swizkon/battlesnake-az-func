using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Anaconda.Domain;
using Anaconda.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace FunctionApp1
{
    public static class Function1
    {

        private static readonly JsonSerializerSettings SerializerOptions = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>
            {
                new StringEnumConverter(true)
            }
        };

        [FunctionName("Function1")]
        public static IActionResult HandleInfo(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "anaconda")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(new SnakeInfo());
        }

        [FunctionName("Start")]
        public static IActionResult HandleStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "anaconda/start")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Start");
            return new OkResult();
        }

        [FunctionName("Move")]
        public static async Task<IActionResult> HandleMove(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "anaconda/move")] HttpRequest req,
            ILogger log)
        {
            var timer = Stopwatch.StartNew();

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var gameState = JsonConvert.DeserializeObject<GameState>(requestBody);

            log.LogInformation("Start decision...");
            timer.Restart();

            var move = DecisionMaker.CalculateMove(gameState, log);
            log.LogInformation("Move decided in {ElapsedMilliseconds} ms", timer.ElapsedMilliseconds);

            return new OkObjectResult(JsonConvert.SerializeObject(move, SerializerOptions));
        }
        
        [FunctionName("End")]
        public static IActionResult HandleEnd(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "anaconda/end")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("End");
            return new OkResult();
        }
    }
}
