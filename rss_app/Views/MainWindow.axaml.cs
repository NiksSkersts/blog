using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DynamicData;
using rss_app.ViewModels;
using rss_app.Services;
using Feed = CodeHollow.FeedReader.Feed;

namespace rss_app.Views
{
    
    public partial class MainWindow : Window
    {
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
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            this.Find<Grid>("GridLogin").IsVisible = false;
        }
    }
}