using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using app.Models;
using DynamicData;
using DynamicData.Kernel;
using ReactiveUI;

namespace app.ViewModels
{
    public class Posts : ViewModelBase
    {
        private ObservableCollection<Post> _collection = new(Db.Posts);
        public ObservableCollection<Post> _Posts
        {
            get => _collection;
            set => this.RaiseAndSetIfChanged(ref value, value);
        }
    }
}