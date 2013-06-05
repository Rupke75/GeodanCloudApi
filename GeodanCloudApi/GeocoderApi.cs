using Geodan.Cloud.Api.Model;
using RestSharp;
using System.Collections.Generic;

namespace Geodan.Cloud.Api
{
    public enum Projection
    {
        Rd,
        LatLon
    }

    public class GeocoderApi
    {
        public string BaseUrl = "http://geoserver.nl/geocoder/";
        public string UserId = "fff10c80874d50b985b5a83cd7dde17e";

        public List<GeoSuggestion> GetSuggestions(string searchText)
        {
            var client = new RestClient {BaseUrl = BaseUrl};
            var request = new RestRequest {Resource = "geosuggest.aspx?format=json&search={searchText}"};
            request.AddParameter("searchText", searchText, ParameterType.UrlSegment);
            request.AddParameter("userId", UserId, ParameterType.UrlSegment);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var suggestions = client.Execute<List<GeoSuggestion>>(request);
            return suggestions.Data;
        }

        public List<Location> GetLocations(Projection projection, string id)
        {
            var client = new RestClient {BaseUrl = BaseUrl};
            string resource;
            switch (projection)
            {
                case Projection.Rd:
                    resource = "nladdress.aspx";
                    break;
                case Projection.LatLon:
                    resource = "nladdressll.aspx";
                    break;
                default:
                    resource = "nladdress.aspx";
                    break;
            }
            var request = new RestRequest { Resource = string.Format("{0}?format=json&request=idlookup&id={{id}}&uid={{userId}}", resource) };
            request.AddParameter("id", id, ParameterType.UrlSegment);
            request.AddParameter("userId", UserId, ParameterType.UrlSegment);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var locations = client.Execute<List<Location>>(request);
            return locations.Data;
        }
    }
}
