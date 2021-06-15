using System;
using System.Collections.Generic;

#nullable disable

namespace raftypoile.Models
{
    public partial class Email
    {
        public Email()
        {
            Authors = new HashSet<Author>();
        }

        public long IdEmail { get; set; }
        /// <summary>
        /// email from app
        /// </summary>
        public string Email1 { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
