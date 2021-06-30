using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class User
    {
        public User()
        {
            Documents = new HashSet<Document>();
            Feeds = new HashSet<Feed>();
            Posts = new HashSet<Post>();
            Quotes = new HashSet<Quote>();
            SocialMediaRefs = new HashSet<SocialMediaRef>();
            UserIndices = new HashSet<UserIndex>();
        }

        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long IdEmail { get; set; }
        public long IdPicture { get; set; }

        public virtual Email IdEmailNavigation { get; set; }
        public virtual Picture IdPictureNavigation { get; set; }
        public virtual LoginDatum LoginDatum { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Feed> Feeds { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<SocialMediaRef> SocialMediaRefs { get; set; }
        public virtual ICollection<UserIndex> UserIndices { get; set; }
    }
}
