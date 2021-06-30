using System;

#nullable disable

namespace server.Models
{
    public partial class SocialMediaRef
    {
        public long IdSocialMediaRef { get; set; }
        public Guid IdUser { get; set; }
        public long IdSocialMedia { get; set; }
        public string Href { get; set; }

        public virtual SocialMedium IdSocialMediaNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
