using System; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Second.Models;
using PagedList;

namespace Web.Second.Controllers
{
    public class HomeController : Controller
    {
        private ImageContext _db = new ImageContext();

        /*public ActionResult Index(int page = 1, int pageSize = 6)
        {
            var images = _db.Images;
            var records = new PagedList<Image>();

            records.Content = _db.Images
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            records.TotalRecords = _db.Images.Count();
            records.CurrentPage = page;
            records.PageSize = pageSize;
            //ViewBag.Images = images;

            //ViewBag.Count = images.Count();

            return View(records);
        }*/

        public ActionResult Index(int? page)
        {
            var records = new List<Image>();
            records = _db.Images.ToList();

            int pageSize = 6;
            int pageNumber = page ?? 1;

            return View(records.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult List(int? page)
        {
            var records = new List<Image>();
            records = _db.Images.ToList();

            int pageSize = 6;
            int pageNumber = page ?? 1;

            return PartialView(records.ToPagedList(pageNumber, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}