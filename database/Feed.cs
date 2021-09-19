using System;

#nullable disable

namespace database
{
    public partial class Feed
    {
        public long IdFeed { get; set; }
        public Guid IdUser { get; set; }
        public string FeedName { get; set; }
        public long IdIcon { get; set; }
        public string FeedUrl { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual Icon IdIconNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
