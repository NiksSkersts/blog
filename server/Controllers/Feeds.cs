using System;
using System.Collections.Generic;
using System.Linq;
using database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace server.Controllers
{
    [Route("API/Feeds")]
    [ApiController]
    [Authorize]
    public class Feeds : ControllerBase
    {
        private readonly mainContext _context;
        private readonly IConfiguration _configuration;
        public Feeds(mainContext context,IConfiguration configuration)
        {
            this._configuration = configuration;
            _context = context;
        }

        [HttpGet]
        
        public IEnumerable<string> GiveUrl()
        {
            if (User.Identity != null)
            {
                var identityName = User.Identity.Name;
                return _context.Feeds.Where(p => p.IdUser.Equals(Guid.Parse(identityName))).Select(p => p.FeedUrl);
            }

            return null;
        }
    }
}