using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using rss_app.ViewModels;

namespace rss_app.Services
{
    public class GetUrlsFromDB
    {
        public static IEnumerable<string> Get(Guid guid)
        {
            var url =
                "https://localhost:5001/Feeds/" + guid;
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Content-Length"] = "0";
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using var streamReader = new StreamReader(httpResponse.GetResponseStream());
            string result = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<string>>(result);
        }
    }
}