using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CodeHollow.FeedReader;
using DynamicData;
using rss_app.ViewModels;
using rss_app.Services;
using Feed = CodeHollow.FeedReader.Feed;

namespace rss_app.Views
{
    
    public partial class MainWindow : Window
    {
        #region Declare

        private Task Login;
        private Grid _loginScreen;
        private Grid _loadingScreen;
        private Grid _rssScreen;
        private TextBox _username;
        private TextBox _password;
        public static ListBox FilterListBox;
        public static ListBox ListFeedsListBox;
        private LoginControl lgnCntrl = new ();
        private FeedControl feedControl = new ();
        ObservableCollection<FeedItem> feedItems = new();
        #endregion

        #region Methods

        private void TieXamlToCS()
        {
            _username=this.Find<TextBox>("TbUsername");
            _password=this.Find<TextBox>("TbPassword");
            _loginScreen = this.Find<Grid>("LoginScreen");
            _loadingScreen = this.Find<Grid>("LoadingScreen");
            _rssScreen = this.Find<Grid>("RssScreen");
            FilterListBox = this.Find<ListBox>("FilterListBox");
            ListFeedsListBox = this.Find<ListBox>("ListFeedsListBox");
        }

        #endregion
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            TieXamlToCS();
        }

        private async void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            ShowLoadingScreen();
            await Task.Delay(100);
            await PopulateListView();
            EndLoadingScreen();
        }

        private void EndLoadingScreen()
        {
            _loadingScreen.IsVisible = false;
            _rssScreen.IsVisible = true;
        }

        private void ShowLoadingScreen()
        {
            _rssScreen.IsVisible = false;
            _loginScreen.IsVisible = false;
            _loadingScreen.IsVisible = true;
        }

        private async Task GetFeedsFromService()
        {
            var succeeded = false;
            while (!succeeded)
            {
                Login = feedControl.FeedService(await lgnCntrl.GetGuidFromDb(_username.Text, _password.Text));
                succeeded = Login.IsCompleted;
                await Task.Delay(1000);
            }
        }

        private async Task PopulateListView()
        {
            await GetFeedsFromService();
            PopulateFilterListView();
            foreach (var feed in feedControl.Feeds.Select(p=>p.Items).Select(p=>p))
            {
                foreach (var feeditem in feed)
                {
                    feedItems.Add(feeditem);
                }
            }
            ListFeedsListBox.Items = feedItems.Select(p=>p.Title);
        }

        private async Task PopulateFilterListView()
        {
            FilterListBox.Items = feedControl.Feeds.Select(p => p.Title);
        }
    }
}