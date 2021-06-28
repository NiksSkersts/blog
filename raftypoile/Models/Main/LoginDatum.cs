using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace raftypoile.Models.Main
{
    public partial class LoginDatum
    {
        public Guid IdUser { get; set; }
        [Required(ErrorMessage = "User Name is required")] 
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]  
        public string Password { get; set; }
        public DateTime AccountCreated { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
