using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
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
