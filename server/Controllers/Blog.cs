using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Route("Blog")]
    public class Blog : Controller
    {
        #region Declare
        private object _posts;
        private object _expanded;
        private readonly mainContext _context;
        #endregion
        #region init
        public Blog(mainContext context) => _context = context;
        #endregion
        #region Method
        private void Init()
        {
            _posts = _context.Posts
                .Include(p => p.IdUserNavigation)
                .ThenInclude(p => p.IdPictureNavigation)
                .Include(p => p.IdPictureNavigation)
                .Include(p => p.IdCatNavigation);
        }
        private void GetSingle(int i)
        {
            _expanded = _context.Posts
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
            Init();
            return View(_posts);
        }
        [Route("Expanded/{i:int?}")]
        public ViewResult Expanded(int i)
        {
            GetSingle(i);
            return View(_expanded);
        }
        [Route("ExpandedGallery/{i:int?}")]
        public ViewResult ExpandedGallery(int i)
        {
            var picture = _context.Pictures.Single(p => p.IdPicture == i);
            return View(picture);
        }
        [Route("Index/{i:int?}")]
        [Route("Index/{i:int?}/{j:int}")]
        public ViewResult Index(int i, int j)
        {
            switch (i)
            {
                case 0:
                    Init();
                    break;
                case 1:
                    _posts = _context.Posts
                        .Include(p => p.IdUserNavigation)
                        .ThenInclude(p => p.IdPictureNavigation)
                        .Include(p => p.IdPictureNavigation)
                        .Include(p => p.IdCatNavigation)
                        .Where(p => p.IdCat == j);
                    break;
            }

            return View(_posts);
        }
        [Route("Gallery")]
        public ViewResult Gallery()
        {
            var pictures = _context.Pictures.Where(p => p.Published).Select(p => p);
            Init();
            return View(pictures);
        }
        #endregion
    }
}
