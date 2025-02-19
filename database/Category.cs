﻿using System.Collections.Generic;

#nullable disable

namespace database
{
    public partial class Category
    {
        public Category()
        {
            Pictures = new HashSet<Picture>();
            Posts = new HashSet<Post>();
        }

        public long IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
