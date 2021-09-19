using System.Collections.Generic;

#nullable disable

namespace database
{
    public partial class UserEmail
    {
        public UserEmail()
        {
            Users = new HashSet<User>();
        }

        public long IdEmail { get; set; }
        public string Email { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
