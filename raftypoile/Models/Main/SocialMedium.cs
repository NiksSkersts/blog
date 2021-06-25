using System.Collections.Generic;

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
        /// <summary>
        /// name of social media
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// base link
        /// </summary>
        public string BaseLink { get; set; }
        /// <summary>
        /// from font-awesome
        /// </summary>
        public long IdIcon { get; set; }

        public virtual Icon IdIconNavigation { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<SocialMediaRef> SocialMediaRefs { get; set; }
    }
}
