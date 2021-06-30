using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class User
    {
        public User()
        {
            UserIndices = new HashSet<UserIndex>();
        }

        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long IdEmail { get; set; }
        public long IdPicture { get; set; }
        public virtual ICollection<UserIndex> UserIndices { get; set; }
    }
}
