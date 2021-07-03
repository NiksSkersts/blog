using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Email
    {
        public Email()
        {
            Users = new HashSet<User>();
        }

        public long IdEmail { get; set; }
        public string Email1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
