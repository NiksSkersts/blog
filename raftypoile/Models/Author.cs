using System;
using System.Collections.Generic;

#nullable disable

namespace raftypoile.Models
{
    public partial class Author
    {
        public Author()
        {
            Posts = new HashSet<Post>();
            SocialMediaRefs = new HashSet<SocialMediaRef>();
        }

        public long IdAuthor { get; set; }
        public string Name { get; set; }
        public long IdEmail { get; set; }
        /// <summary>
        /// Author Pic
        /// </summary>
        public long IdPicture { get; set; }
        public long IdDocument { get; set; }

        public virtual Document IdDocumentNavigation { get; set; }
        public virtual Email IdEmailNavigation { get; set; }
        public virtual Picture IdPictureNavigation { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<SocialMediaRef> SocialMediaRefs { get; set; }
    }
}
