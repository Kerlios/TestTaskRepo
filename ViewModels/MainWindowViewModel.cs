using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Emit;

namespace TestTask.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private string _address;
        private int _dotsCount;
        private string _filename;
        private static HttpClient _client = new HttpClient();

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
            uri += Address + "&format=json&polygon_geojson=1";
            _client.DefaultRequestHeaders.Add("user-agent", "Test C# Project v1");

            try
            {
                var responseBody = await _client.GetAsync(uri);
                var item = responseBody.Content.ReadAsStringAsync();
                var str = item.Result;
                Console.WriteLine(responseBody.Content);
                JsonConvert.DeserializeObject<object>(str);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        public void LoadLibrary()
        {
            // загрузить dll
            // OpenStreetMapLib.dll
            
            AssemblyName an = AssemblyName.GetAssemblyName(@"C:\Users\Aleksandr\source\repos\TestTaskRepo\OpenStreetMapLib\bin\Debug\OpenStreetMapLib.dll");

            Assembly someAssembly = Assembly.Load(an);

            if (someAssembly != null)
            {
                Type[] types = someAssembly.GetTypes(); // получение всех типов, находящихся в сборке
                Console.WriteLine("Тип в сборке: " + types[0].Name);
                foreach (Type type in types) // производим поиск всех ОПРЕДЕЛЕНИЙ интерфейсов
                {
                    if (type.IsClass && type.Name=="Main_OSM")
                    {
                        Console.WriteLine("Полное имя типа: " + type.Name);
                    }
                }
            }

            Type myclass = someAssembly.GetType("OpenStreetMapLib.Main_OSM");
            MethodInfo[] myMethod = myclass.GetMethods();

            var mainosm = Activator.CreateInstance(myclass);

            myMethod[0].Invoke(mainosm,null);
        }
    }
}