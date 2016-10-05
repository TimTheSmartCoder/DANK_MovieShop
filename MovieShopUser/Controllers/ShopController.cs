using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShopBackend;
using MovieShopBackend.Entities;
using MovieShopUser.Models;

namespace MovieShopUser.Controllers
{
    public class ShopController : Controller
    {
        private IManager<Movie> _movieManager = new ManagerFacade().GetMovieManager();
        private IManager<Genre> _GenreManager = new ManagerFacade().GetGenreManager();

        private List<Movie> movies = new List<Movie>();
        private List<Genre> genres = new List<Genre>();

        public ShopController()
        {
            movies = _movieManager.ReadAll();
            genres = _GenreManager.ReadAll();
        }

        [HttpGet]
        public ActionResult Index()
        {
            GenreMovieViewModel viewModel = new GenreMovieViewModel
            {
                Genres = genres,
                Movies = movies
            };

            return View(viewModel);
        }
    }
}