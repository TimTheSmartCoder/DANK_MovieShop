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
            _movieManager.Create(new Movie
            {
                Genre = new Genre{ Name = "Action"},
                Id = 1,
                ImageUrl = "http://i.imgur.com/Fh6xlbF.jpg",
                Title = "A Smashing Experience",
                Trailer = "https://www.youtube.com/watch?v=MQqFuGMCaT4",
                Price = 100000,
                Year = 2016

            });

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