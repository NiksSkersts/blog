using System.Collections.Generic;

namespace raftypoile.Models.Main
{
    public partial class Picture
    {
        public Picture()
        {
            Posts = new HashSet<Post>();
            Users = new HashSet<User>();
        }

        public long IdPicture { get; set; }
        public string AlternativeText { get; set; }
        public long IdCategory { get; set; }
        public bool Published { get; set; }
        public string SourceHeader { get; set; }
        public string SourcePreview { get; set; }
        public string SourceOriginal { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
