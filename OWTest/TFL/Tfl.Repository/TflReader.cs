using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Tfl.Contract;
using Tfl.Dto;

namespace Tfl.Repository
{
    public class TflReader : ITflReader
    {
        private const string BaseUrl = "https://api.tfl.gov.uk";

        public IEnumerable<Arrival> GetNextArrivals(string stopPointId, string lineId)
        {
            var url = $"{BaseUrl}/Line/{lineId}/Arrivals/{stopPointId}?direction=inbound";
            return Get<IEnumerable<Arrival>>(url);
        }

        private T Get<T>(string url)
        {
            var restClient = new RestClient(url);
            var request = new RestRequest("/", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = restClient.Execute(request);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
