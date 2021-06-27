using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using raftypoile.Models.Main;

namespace raftypoile.Controllers
{
    [Route("Feeds/{uuid:guid}")]
    public class Feeds : ControllerBase
    {
        private readonly mainContext _context;
        public Feeds(mainContext context) => _context = context;
        [HttpPost]
        public IEnumerable<string> GiveOutGuid(Guid uuid)
        {
            return _context.Feeds.Where(feed => feed.IdUser == uuid).Select(feed => feed.FeedUrl);
        }
    }
}