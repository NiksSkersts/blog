using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using Newtonsoft.Json;
using raftypoile.Models;
using RestSharp.Serialization.Json;
using rss_app.ViewModels;

namespace rss_app.Services
{
    public class LoginControl
    {
        public Guid UserGuid { get; set; }
        public static async Task<Guid> GetGuidFromDb(string username, string password)
        {
            var objtojson = new HttpBody{ username = username,password = password};
            string jsonData = JsonConvert.SerializeObject(objtojson);
            var url = "Login";
            string result = HttpClient.HttpReq(url,jsonData);
            result = result.Trim('"');
            try
            {
                return Guid.Parse(result);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}