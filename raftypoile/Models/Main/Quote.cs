using System;
using System.Collections.Generic;

#nullable disable

namespace raftypoile.Models.Main
{
    public partial class Quote
    {
        public long IdQuote { get; set; }
        public Guid IdUser { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public long IdSocialMedia { get; set; }

        public virtual SocialMedium IdSocialMediaNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
