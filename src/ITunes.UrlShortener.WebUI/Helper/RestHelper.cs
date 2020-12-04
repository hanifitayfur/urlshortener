using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace ITunes.UrlShortener.WebUI.Helper
{
    public class RestHelper
    {
        public  static T GetMethod<T>(string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };

            var result = GetResult<T>(client, request, null, headers);

            return result;
        }

        public static T PostMethod<T>(object obj, string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };

            var result = GetResult<T>(client, request, obj, headers);

            return result;
        }

        private static T GetResult<T>(RestClient client, RestRequest request, object obj = null, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            if (obj != null)
            {
                request.AddJsonBody(obj);
            }

            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        }
    }
}