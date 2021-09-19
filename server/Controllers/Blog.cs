using System;
using System.Linq;
using database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers
{
    [Route("Blog")]
    [Controller]
    public class Blog : Controller
    {
        #region Declare
        private readonly mainContext _context;
        private static int Language { get; set; } = 1;
        #endregion

        #region API
        [Route("API/Lang")]
        [HttpPost]
        public void LangSwitch([FromBody] HttpGetLang model)
        {
            Language = model.id;
        }
        [Route("API/Lang")]
        [HttpGet]
        public IActionResult GiveLang()
        {
            var res = new OkObjectResult(Language);
            return res;
        }
        #endregion
        #region init
        public Blog(mainContext context) => _context = context;
        #endregion
        #region Method
        private object Init()
        {
            ViewBag.Language = 1;
             return _context.Posts
                .Include(p => p.IdUserNavigation)
                .ThenInclude(p => p.IdPictureNavigation)
                .Include(p => p.IdPictureNavigation)
                .Include(p => p.IdCatNavigation);
        }
        private object GetSingle(int i)
        {
            return _context.Posts
                .Include(p => p.IdUserNavigation)
                .ThenInclude(p => p.IdPictureNavigation)
                .Include(p => p.IdPictureNavigation)
                .Include(p => p.IdCatNavigation).Single(p=>p.IdPost==i);
        }
        #endregion
        #region Routes
        [Route("/")]
        public ViewResult Main()
        {
            return View(Init());
        }
        [Route("/{i:int?}")]
        public ViewResult Expanded(int i)
        {
            return View(GetSingle(i));
        }
        [Route("/Index")]
        public ViewResult Index()
        {
            return View(Init());
        }
        [Route("/Gallery")]
        public ViewResult Gallery()
        {
            Init();
            return View(_context.Pictures.Select(p => p));
        }
        [Route("/About")]
        public ViewResult About()
        {
            return View(GetSingle(11));
        }
        #endregion
    }
    public class HttpGetLang
    {
        public int id { get; set; }
    }
}
