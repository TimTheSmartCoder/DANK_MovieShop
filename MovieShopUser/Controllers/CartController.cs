using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using MovieShopBackend;
using MovieShopBackend.Entities;

using MovieShopUser.Models.Cart;

namespace MovieShopUser.Controllers
{
    public class CartController : Controller
    {
        private ManagerFacade facade = new ManagerFacade();
        private IManager<Movie> movieManager = new ManagerFacade().GetMovieManager();


        private CartManager manager = new CartManager();
        

        // GET: Cart
        public ActionResult Index()
        {
            
            Session["Manager"] = manager;
            manager.Add(new Movie
            {
                Genre = new Genre { Name = "Action" },
                Id = 1,
                ImageUrl = "http://i.imgur.com/Fh6xlbF.jpg",
                Title = "A Smashing Experience",
                Trailer = "https://www.youtube.com/watch?v=MQqFuGMCaT4",
                Price = 100000,
                Year = 2016

            });

            manager.Add(new Movie
            {
                Genre = new Genre { Name = "Action" },
                Id = 2,
                ImageUrl = "http://images2.fanpop.com/images/photos/7500000/Legolas-the-elves-of-middle-earth-7510893-477-406.jpg",
                Title = "Isengard Tour Guid!",
                Trailer = "https://www.youtube.com/watch?v=uE-1RPDqJAY",
                Price = 100000,
                Year = 2016
            });


            CartViewModel model = new CartViewModel()
            {
                Movies = manager.Movies
            };
            return View(model);
        }


        [ActionName("Add")]
        public ActionResult AddMovie(string prevUrl, int id)
        {
            Movie m = movieManager.ReadOne(id);
            if (m != null)
            {
                manager.Add(m);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return Redirect(prevUrl);
        }

        public ActionResult Delete(int id)
        {
            manager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}