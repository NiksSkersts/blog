using System;

#nullable disable

namespace database
{
    public partial class Quote
    {
        public long IdQuote { get; set; }
        public Guid IdUser { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public string Source { get; set; }
        public string Timestamp { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
