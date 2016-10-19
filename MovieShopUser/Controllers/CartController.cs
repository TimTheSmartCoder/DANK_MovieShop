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

        // GET: Cart
        public ActionResult Index()
        {
            CartViewModel model = new CartViewModel()
            {
                Movies = new ShoppingCart(this.HttpContext).GetMoviesInCart()
            };
            return View(model);
        }

        


        [ActionName("Add")]
        public ActionResult AddMovie(string prevUrl, int id)
        {
            if (!IsRented(id))
            {
                Movie m = movieManager.ReadOne(id);
                if (m != null)
                {
                    new ShoppingCart(this.HttpContext).AddMovieToCart(m);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return Redirect(prevUrl);
        }

        public ActionResult Delete(int id)
        {
            new ShoppingCart(this.HttpContext).DeleteFromCart(id);
            return RedirectToAction("Index");
        }

        public bool IsRented(int id)
        {
            if (new ShoppingCart(this.HttpContext).GetMoviesInCart().FirstOrDefault(x => x.Id == id) != null)
            {
                return true;
            }
            return false;
        }
    }
}