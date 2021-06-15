using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using app.Models;
using DynamicData.Binding;
using Microsoft.EntityFrameworkCore;

namespace app.ViewModels
{
    public class VMPosts : ViewModelBase
    {
        private raftypoileidlvContext _Context;
        public IEnumerable<Post> Data => LoadData();

        private IEnumerable<Post> LoadData()
        {
            using raftypoileidlvContext context = new();
            _Context = context;
            _Context.Posts.Load();
            return _Context.Posts.Select(p=>p);
        }
    }
}