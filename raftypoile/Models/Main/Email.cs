using System.Collections.Generic;

namespace raftypoile.Models.Main
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
