using System;

namespace raftypoile.Models.Main
{
    public partial class SocialMediaRef
    {
        public long IdSocialMediaRef { get; set; }
        public Guid IdUser { get; set; }
        /// <summary>
        /// social media name
        /// </summary>
        public long IdSocialMedia { get; set; }
        /// <summary>
        /// href to social media account
        /// </summary>
        public string Href { get; set; }

        public virtual SocialMedium IdSocialMediaNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
