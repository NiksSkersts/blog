using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using server.Models;

namespace server.Controllers
{
    [Route("Feeds")]
    [ApiController]
    [Authorize]
    public class Feeds : ControllerBase
    {
        private readonly mainContext _context;
        private readonly IConfiguration _configuration;
        public Feeds(mainContext context,IConfiguration _configuration)
        {
            this._configuration = _configuration;
            _context = context;
        }

        [HttpGet]
        
        public IEnumerable<string> GiveURL()
        {
            var identityName = User.Identity.Name;
            return _context.Feeds.Where(p => p.IdUser.Equals(Guid.Parse(identityName))).Select(p => p.FeedUrl);
        }
    }
}