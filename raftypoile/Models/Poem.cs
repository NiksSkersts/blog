using System;
using System.Collections.Generic;

#nullable disable

namespace raftypoile.Models
{
    public partial class Poem
    {
        public long IdPoem { get; set; }
        public long IdAuthor { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool Published { get; set; }

        public virtual Author IdAuthorNavigation { get; set; }
    }
}
