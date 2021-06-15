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
        public string Icon { get; set; }

        public virtual ICollection<SocialMediaRef> SocialMediaRefs { get; set; }
    }
}
