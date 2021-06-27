using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using rss_app.Views;
using Feed = CodeHollow.FeedReader.Feed;

namespace rss_app.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Declare
        private static readonly string _username;
        private static readonly string _password;

        #endregion

        #region getters and setters

        private static string Username => _username;

        private static string Password => _password;
        #endregion
    }
}