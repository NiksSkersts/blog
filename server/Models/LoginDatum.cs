using System;

#nullable disable

namespace server.Models
{
    public partial class LoginDatum
    {
        public Guid IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime AccountCreated { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
