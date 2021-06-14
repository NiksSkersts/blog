using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using raftypoile.Models;

namespace raftypoile.Controllers
{
    [Route("Blog")]
    public class PostsController : Controller
    {
        //DECLARE
        private readonly raftypoileidlvContext _context;
        private object _posts;
        private object _expanded;
        //FUNCTIONS
        private void Init()
        {
            _posts = _context.Posts
                .Include(p => p.IdAuthorNavigation)
                .ThenInclude(p => p.IdPictureNavigation)
                .Include(p => p.IdPictureNavigation)
                .Include(p=>p.IdCatNavigation)
                .Include(p=>p.IdAuthorNavigation.IdDocumentNavigation)
                .ThenInclude(p=>p.IdDocumentTypeNavigation);
        }
        private void GetSingle(int i)
        {
            _expanded = _context.Posts
                .Include(p => p.IdAuthorNavigation)
                .ThenInclude(p => p.IdPictureNavigation)
                .Include(p => p.IdPictureNavigation)
                .Include(p=>p.IdCatNavigation)
                .Include(p=>p.IdAuthorNavigation.IdDocumentNavigation)
                .ThenInclude(p=>p.IdDocumentTypeNavigation).Single(p=>p.IdPost==i);
        }
        public PostsController(raftypoileidlvContext context) => _context = context;
        //ROUTED FUNCTIONS AND VIEWS
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
            var _picture = _context.Pictures.Single(p => p.IdPicture == i);
            return View(_picture);
        }
        [Route("Index/{i:int?}")]
        [Route("Index/{i:int?}/{j:int}")]
        public ViewResult Index(int i,int j)
        {
            switch (i)
            {
                case 0:
                    Init();
                    break;
                case 1:
                    _posts = _context.Posts
                        .Include(p => p.IdAuthorNavigation)
                        .ThenInclude(p => p.IdPictureNavigation)
                        .Include(p => p.IdPictureNavigation)
                        .Include(p=>p.IdCatNavigation)
                        .Include(p=>p.IdAuthorNavigation.IdDocumentNavigation)
                        .ThenInclude(p=>p.IdDocumentTypeNavigation)
                        .Where(p=>p.IdCat == j);
                    break;
            }

            return View(_posts);
        }
        [Route("Gallery")]
        public ViewResult Gallery()
        {
            var _pictures = _context.Pictures.Where(p => p.Published==true).Select(p => p);
            Init();
            return View(_pictures);
        }

    }
}