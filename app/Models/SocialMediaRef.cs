using System;
using System.Collections.Generic;

#nullable disable

namespace app.Models
{
    public partial class SocialMediaRef
    {
        public long IdSocialMediaRef { get; set; }
        public long IdAuthor { get; set; }
        public long IdSocialMedia { get; set; }
        public string Href { get; set; }

        public virtual Author IdAuthorNavigation { get; set; }
        public virtual SocialMedium IdSocialMediaNavigation { get; set; }
    }
}
