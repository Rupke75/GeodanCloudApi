using System;
using System.Collections.Generic;
using Geodan.Cloud.Api.Model;
using RestSharp;
using System.Globalization;

namespace Geodan.Cloud.Api
{
    public class BevoegdGezagApi
    {
        public string BaseUrl = "http://services.geodan.nl/regios";
        public string UserId = "fff10c80874d50b985b5a83cd7dde17e";

        public List<Bevoegdgezag> GetBevoegdgezag(double lon, double lat)
        {
            var client = new RestClient { BaseUrl = BaseUrl };
            var request = new RestRequest { Resource = "?lon={lon}&lat={lat}&uid={userId}" };
            request.AddParameter("lon", lon.ToString(CultureInfo.InvariantCulture), ParameterType.UrlSegment);
            request.AddParameter("lat", lat.ToString(CultureInfo.InvariantCulture), ParameterType.UrlSegment);
            request.AddParameter("userId", UserId, ParameterType.UrlSegment);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            return client.Execute<List<Bevoegdgezag>>(request).Data;
        }

        public List<Bevoegdgezag> GetBevoegdgezag(string wktRd)
        {
            var client = new RestClient { BaseUrl = BaseUrl };
            var request = new RestRequest { Resource = "?wkt={wktRd}&uid={userId}" };
            request.AddParameter("wktRd", wktRd, ParameterType.UrlSegment);
            request.AddParameter("userId", UserId, ParameterType.UrlSegment);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            return client.Execute<List<Bevoegdgezag>>(request).Data;
        }
    }
}
