using System;

namespace raftypoile.Models.Main
{
    //login_data is now LoginDatum. Hmpfh! Not that it matters.
    public partial class LoginDatum
    {
        public Guid IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateOnly AccountCreated { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
