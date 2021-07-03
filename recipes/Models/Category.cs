using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Category
    {
        public Category()
        {
            Pictures = new HashSet<Picture>();
        }

        public long IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
