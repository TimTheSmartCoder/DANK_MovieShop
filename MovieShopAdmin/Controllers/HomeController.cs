using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShopBackend;
using MovieShopBackend.Entities;

namespace MovieShopAdmin.Controllers
{
    public class HomeController : Controller
    {
        private IManager<Genre> _gm = new ManagerFacade().GetGenreManager();
        public ActionResult Index()
        {
            if (!_gm.ReadAll().Any())
            {
                _gm.Create(new Genre() {Name = "Tim"});
            }
            List<Genre> allGenres = _gm.ReadAll();
            foreach (Genre genre in allGenres)
            {
                Console.WriteLine(genre.Name);
            }
            return View(_gm.ReadAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}