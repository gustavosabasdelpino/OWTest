using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tfl.Contract;
using Tfl.Dto;

namespace Tfl.Repository
{
    public class TflReader: ITflReader
    {
        static HttpClient htttpClient = new HttpClient();

        private const string BaseUrl = "https://api.tfl.gov.uk";

        public IEnumerable<Arrival> GetNextArrivals(string stopPointId, string lineId)
        {
            var url = $"{BaseUrl}/Line/{lineId}/Arrivals/{stopPointId}?direction=inbound";
            return Get<IEnumerable<Arrival>>(url).Result;
        }

        private async Task<T> Get<T>(string url)
        {
            HttpResponseMessage response = await htttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return  JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            throw  new ApplicationException($"Response from {url} was not succesful");
        }
    }
}
