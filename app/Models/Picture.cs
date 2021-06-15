using System;
using System.Collections.Generic;

#nullable disable

namespace app.Models
{
    public partial class Picture
    {
        public Picture()
        {
            Authors = new HashSet<Author>();
            Posts = new HashSet<Post>();
        }

        public long IdPicture { get; set; }
        public string AlternativeText { get; set; }
        public long IdCategory { get; set; }
        public bool Published { get; set; }
        public string SourceHeader { get; set; }
        public string SourcePreview { get; set; }
        public string SourceOriginal { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
