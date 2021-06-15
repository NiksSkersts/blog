using System;
using System.Collections.Generic;

#nullable disable

namespace app.Models
{
    public partial class SocialMedium
    {
        public SocialMedium()
        {
            SocialMediaRefs = new HashSet<SocialMediaRef>();
        }

        public long IdSocialMedia { get; set; }
        public string Name { get; set; }
        public string BaseLink { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<SocialMediaRef> SocialMediaRefs { get; set; }
    }
}
