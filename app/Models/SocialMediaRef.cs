using System;
using System.Collections.Generic;

#nullable disable

namespace app.Models
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
    }
}
