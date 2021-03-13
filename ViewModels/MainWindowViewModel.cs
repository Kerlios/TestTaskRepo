using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using RestSharp;


namespace TestTask.ViewModels
{
    class MainWindowViewModel:BaseViewModel
    {
        private string _address;
        private int _dotsCount;
        private string _filename;
        private static readonly HttpClient _client = new HttpClient();

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
                OnPropertyChanged(nameof(Filename));
            }
        }

        public int DotsCount
        {
            get
            {
                return _dotsCount;
            }
            set
            {
                _dotsCount = value;
                OnPropertyChanged(nameof(DotsCount));
            }
        }

        public async void Search()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            var uri = "https://nominatim.openstreetmap.org/search?q=";
            uri += Address+"&format=json&polygon_geojson=1";
            try
            {
                string responseBody = await _client.GetStringAsync(uri);
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }


            // perform search
            //var uri = "https://nominatim.openstreetmap.org/search?q=";
            //uri += Address;
            //var client = new RestClient(uri);
            //var request = new RestRequest(Method.GET);
            ////request.AddParameter("q", Address, ParameterType.QueryString);

            //IRestResponse response = client.Execute(request);
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{

            //}
            //else
            //    throw new Exception("Expected response status code OK, received response status code " + response.StatusCode);
        }
    }
}
