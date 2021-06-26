using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using CodeHollow.FeedReader;
using DynamicData;
using DynamicData.Binding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;
using rss_app.Services;
using Feed = CodeHollow.FeedReader.Feed;

namespace rss_app.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Declare
        private bool _notLoggedIn = true;
        private Guid _userGuid = Guid.Empty;
        private IEnumerable<string> _feeds;
        private ObservableCollection<Feed> observableCollection;
        #endregion

        #region getters and setters
        private string UserName { get; set; }
        private string Password { get; set; }

        public bool NotLoggedIn
        {
            get => _notLoggedIn;
            set
            {
                this.RaiseAndSetIfChanged(ref _notLoggedIn, value);
                if (value != false) return;
                var guid = Login(UserName,Password);
                GetUrls(guid);
            }
        }
        public ObservableCollection<Feed> Collection
        {
            get => observableCollection;
            set
            {
                this.RaiseAndSetIfChanged(ref observableCollection, value);
                this.RaisePropertyChanged();
            }
        }

        #endregion
        
        #region Methods
        private Guid Login(string uname, string pass)
        {
            var mLogin = new UserLogin();
            return mLogin.Login(uname,pass);
        }

        private async Task GetUrls(Guid guid)
        {
            _feeds = Services.GetUrlsFromDB.Get(guid);
            Collection = await GetFeeds(_feeds);
        }

        private async Task<ObservableCollection<Feed>> GetFeeds(IEnumerable<string> feeds)
        {
            ObservableCollection<Feed> _feeds = new();
            foreach (var url in feeds)
            {
                Feed _feed = new();
                _feed = await FeedReader.ReadAsync(url);
                _feeds.Add(_feed);
            }

            return _feeds;
        }
        #endregion
    }
}