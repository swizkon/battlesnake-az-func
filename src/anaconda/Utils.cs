using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Microsoft.Azure.Functions.Worker.Http;

namespace anaconda
{
    public static class Utils
    {
        private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        public static async Task<HttpResponseData> CreateJsonResponse(this HttpRequestData req, object data)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data, new JsonObjectSerializer(SerializerOptions));
            
            return response;
        }
    }
}
