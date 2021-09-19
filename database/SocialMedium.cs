using System.Collections.Generic;

#nullable disable

namespace database
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
        public long IdIcon { get; set; }

        public virtual Icon IdIconNavigation { get; set; }
        public virtual ICollection<SocialMediaRef> SocialMediaRefs { get; set; }
    }
}
