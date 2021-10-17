//using System.Diagnostics;
//using System.Net;
//using System.Threading.Tasks;
//using anaconda.Model;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Azure.Functions.Worker.Http;
//using Microsoft.Extensions.Logging;

//namespace anaconda
//{
//    public static class Move
//    {
//        [Function(nameof(Move))]
//        public static async Task<HttpResponseData> Run(
//            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "anaconda/move")]
//            HttpRequestData req,
//            FunctionContext executionContext)
//        {
//            var logger = executionContext.GetLogger(nameof(Move));

//            var data = await req.ReadFromJsonAsync<GameState>();

//            logger.LogInformation("DAta {@data}", data);

//            var timer = Stopwatch.StartNew();


//            var response = req.CreateResponse(HttpStatusCode.OK);

//            await response.WriteAsJsonAsync(new MoveResponse
//            {
//                Move = "up",
//                Shout = "Yeah, like..."
//            });

//            logger.LogInformation("Move decided in {ElapsedMilliseconds} ms", timer.ElapsedMilliseconds);
//            return response;
//        }
//    }
//}