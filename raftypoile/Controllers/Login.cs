using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using raftypoile.Models.Main;

namespace raftypoile.Controllers
{
    [Route("956C67E5-F469-420F-87EA-746E00084AAD")]
    public class Login : ControllerBase
    {
        private readonly mainContext _context;
        public Login(mainContext context) => _context = context;
        [HttpPost]
        [Route("CEE08E7B-8104-4FC0-8B19-2C7B4B94EE96/{username}/{password}")]
        public Guid GiveOutGuid(string username,string password)
        {
            return _context.LoginData.Single(p => p.Username.Equals(username) && p.Password.Equals(password)).IdUser;
        }
    }
}