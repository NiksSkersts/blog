using System;
using System.Collections.Generic;

#nullable disable

namespace raftypoile.Models
{
    public partial class Post
    {
        public long IdPost { get; set; }
        public long IdCat { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public long IdAuthor { get; set; }
        public long IdPicture { get; set; }
        public DateTime Date { get; set; }
        public bool Published { get; set; }

        public virtual Author IdAuthorNavigation { get; set; }
        public virtual Category IdCatNavigation { get; set; }
        public virtual Picture IdPictureNavigation { get; set; }
    }
}
