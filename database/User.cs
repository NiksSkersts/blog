using System;
using System.Collections.Generic;

#nullable disable

namespace database
{
    public partial class User
    {
        public User()
        {
            Documents = new HashSet<Document>();
            Feeds = new HashSet<Feed>();
            Posts = new HashSet<Post>();
            Quotes = new HashSet<Quote>();
            RecipeUserIndices = new HashSet<RecipeUserIndex>();
            SocialMediaRefs = new HashSet<SocialMediaRef>();
        }

        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long? IdEmail { get; set; }
        public long? IdPicture { get; set; }

        public virtual UserEmail IdEmailNavigation { get; set; }
        public virtual Picture IdPictureNavigation { get; set; }
        public virtual UserLoginDatum UserLoginDatum { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Feed> Feeds { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<RecipeUserIndex> RecipeUserIndices { get; set; }
        public virtual ICollection<SocialMediaRef> SocialMediaRefs { get; set; }
    }
}
