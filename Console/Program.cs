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
            var api = new GeocoderApi();
            var results = api.GetSuggestions("parna");

            api.GetLocations(Projection.Rd, results[0].Id);
        }
    }
}
