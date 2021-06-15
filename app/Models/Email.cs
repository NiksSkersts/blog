using System;
using System.Collections.Generic;

#nullable disable

namespace app.Models
{
    public partial class Email
    {
        public Email()
        {
            Authors = new HashSet<Author>();
        }

        public long IdEmail { get; set; }
        public string Email1 { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
