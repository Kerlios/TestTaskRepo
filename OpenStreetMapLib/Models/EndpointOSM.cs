using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStreetMapLib.Models
{
    class EndpointOSM
    {
        public string SearchEndpoint { get; set; } = "https://nominatim.openstreetmap.org/search?q=";
        public string AdditionalParams { get; } = "&format=json&polygon_geojson=1";
    }
}
