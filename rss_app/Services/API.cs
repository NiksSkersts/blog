using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace rss_app.Services
{
    public class API
    {
        private static RestClient client = new();

        private static RestClient CreateClient(string func)
        {
            client.Timeout = -1;
            return new RestClient(new Uri("https://raftypoile.id.lv/" + func));
        }

        public static async Task<string> ConsumeLoginApi(string func,string json)
        {
            client = CreateClient(func);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json,  ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            return response.Content;
        }

        public static async Task<IEnumerable<string>> ConsumeFeedApi(string func,JwtSecurityToken jwtSecurityToken)
        {
            client = CreateClient(func);
            var request = new RestRequest(Method.GET);
            client.Authenticator = new JwtAuthenticator(jwtSecurityToken.RawData);
            IRestResponse response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<IEnumerable<string>>(response.Content);
        }
    }
}