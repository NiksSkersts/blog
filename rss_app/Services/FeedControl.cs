using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using JetBrains.Annotations;
using Newtonsoft.Json;
using raftypoile.Models;
using rss_app.ViewModels;

namespace rss_app.Services
{
    public class FeedControl
    {
        private IEnumerable<string> _feeds;
        public ObservableCollection<Feed> Feeds { get; set; }
        public async Task FeedService(Guid guid)
        {
            _feeds = GetStringList(guid);
            Feeds = GetFeeds(_feeds);
        }

        private IEnumerable<string> GetStringList(Guid guid)
        {
            var url = "Feeds/";
            var data = new HttpGuid {guid = guid};
            string jsntoobj = JsonConvert.SerializeObject(data);
            return JsonConvert.DeserializeObject<IEnumerable<string>>(HttpClient.HttpReq(url,jsntoobj));

        }
        private ObservableCollection<Feed> GetFeeds(IEnumerable<string> feeds)
        {
            ObservableCollection<Feed> observableCollection = new();
            foreach (var url in feeds)
            {
                Feed feed = FeedReader.ReadAsync(url).Result;
                observableCollection.Add(feed);
            }
            return observableCollection;
        }
    }
}