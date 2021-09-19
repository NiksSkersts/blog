using System;
using System.Collections.Generic;

#nullable disable

namespace database
{
    public partial class Post
    {
        public Post()
        {
            InverseTranslationToNavigation = new HashSet<Post>();
        }

        public long IdPost { get; set; }
        public long IdCat { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public Guid IdUser { get; set; }
        public long? IdPicture { get; set; }
        public DateTime Date { get; set; }
        public bool Published { get; set; }
        public int Language { get; set; }
        public long? TranslationTo { get; set; }

        public virtual Category IdCatNavigation { get; set; }
        public virtual Picture IdPictureNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual Language LanguageNavigation { get; set; }
        public virtual Post TranslationToNavigation { get; set; }
        public virtual ICollection<Post> InverseTranslationToNavigation { get; set; }
    }
}
