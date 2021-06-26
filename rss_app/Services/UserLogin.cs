using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Avalonia.Controls;
using rss_app.ViewModels;

namespace rss_app.Services
{
    public class UserLogin
    {
        public Guid Login(string username, string password)
        {
            var url =
                "https://localhost:5001/956C67E5-F469-420F-87EA-746E00084AAD/CEE08E7B-8104-4FC0-8B19-2C7B4B94EE96/" +
                username + "/" + password;
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Content-Length"] = "0";
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using var streamReader = new StreamReader(httpResponse.GetResponseStream());
            string result = streamReader.ReadToEnd();
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