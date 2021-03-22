using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

using OpenStreetMapLib.Models;

namespace OpenStreetMapLib.Models
{
    class DataGetter
    {
        private static readonly HttpClient client = new HttpClient();
        // todo create infrastructure for getting data to this lib

        // сделать как можно проще для отправителя (главной программы), т.е.
        // передача в OpenStreetMapLib только поискового запроса
        public static async Task ProcessRepositories(string searchQuery)
        {
            EndpointOSM endpoint = new EndpointOSM();
            var uri = endpoint.SearchEndpoint + searchQuery + endpoint.AdditionalParams;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("user-agent", "Test C# Project v1");

            var stringTask = client.GetStringAsync(uri);

            var msg = await stringTask;
            Console.Write(msg);
        }
    }
}
