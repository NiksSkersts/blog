using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using app.Models;
using DynamicData.Binding;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace app.ViewModels
{
    public class VmPosts : ViewModelBase
    {
        public ObservableCollection<Post> Data => LoadData();
        private ObservableCollection<Post> LoadData()
        {
            using (Db = new raftypoileidlvContext())
            {
                Db.Posts.Load();
                return new ObservableCollection<Post>(Db.Posts);   
            }
        }
    }
}