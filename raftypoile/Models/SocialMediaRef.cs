using System;
using System.Collections.Generic;

#nullable disable

namespace raftypoile.Models
{
    public partial class SocialMediaRef
    {
        public long IdSocialMediaRef { get; set; }
        public long IdAuthor { get; set; }
        /// <summary>
        /// social media name
        /// </summary>
        public long IdSocialMedia { get; set; }
        /// <summary>
        /// href to social media account
        /// </summary>
        public string Href { get; set; }

        public virtual Author IdAuthorNavigation { get; set; }
        public virtual SocialMedium IdSocialMediaNavigation { get; set; }
    }
}
