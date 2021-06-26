using System;
using System.Collections.Generic;

#nullable disable

namespace raftypoile.Models.Main
{
    public partial class Icon
    {
        public Icon()
        {
            Feeds = new HashSet<Feed>();
            SocialMedia = new HashSet<SocialMedium>();
        }

        public long IdIcon { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }

        public virtual ICollection<Feed> Feeds { get; set; }
        public virtual ICollection<SocialMedium> SocialMedia { get; set; }
    }
}
