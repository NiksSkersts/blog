using System;
using System.Collections.Generic;

#nullable disable

namespace raftypoile.Models.Main
{
    public partial class SocialMedium
    {
        public SocialMedium()
        {
            Quotes = new HashSet<Quote>();
            SocialMediaRefs = new HashSet<SocialMediaRef>();
        }

        public long IdSocialMedia { get; set; }
        public string Name { get; set; }
        public string BaseLink { get; set; }
        public long IdIcon { get; set; }

        public virtual Icon IdIconNavigation { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<SocialMediaRef> SocialMediaRefs { get; set; }
    }
}
