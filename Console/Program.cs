using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geodan.Cloud.Api;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var geocoderApi = new GeocoderApi();
            var results = geocoderApi.GetSuggestions("parna");

            geocoderApi.GetLocations(Projection.Rd, results[0].Id);

            var regiosApi = new BevoegdGezagApi();
            var bevoegGezag = regiosApi.GetBevoegdgezag(5.1234, 52.1234);
        }
    }
}
