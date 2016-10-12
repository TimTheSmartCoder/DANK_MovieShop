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
            Populate();
            

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

        public ActionResult Filtert(int id)
        {
            Genre genre = _GenreManager.ReadOne(id);

            if (genre == null) 
            {
                return HttpNotFound();
            }

            GenreMovieViewModel viewModel = new GenreMovieViewModel
            {
                Genres = _GenreManager.ReadAll(),
                Movies = genre.Movies
            };

            return View("Index", viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Movie movie = _movieManager.ReadOne(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }



        private void Populate()
        {
            _GenreManager.Create(new Genre
            {
                Id = 1,
                Name = "All"
            });
            _GenreManager.Create(new Genre
            {
                Id = 2,
                Name = "Action"
            });
            _GenreManager.Create(new Genre
            {
                Id = 3,
                Name = "DickJokes"
            });


            _movieManager.Create(new Movie
            {
                Genre = _GenreManager.ReadOne(2),
                Id = 2,               
                ImageUrl = "http://i.imgur.com/Fh6xlbF.jpg",
                Title = "A Smashing Experience",
                Trailer = "https://www.youtube.com/watch?v=MQqFuGMCaT4",
                Price = 100000,
                Year = 2016

            });

            _movieManager.Create(new Movie
            {
                Genre = _GenreManager.ReadOne(3),
                Id = 3,
                ImageUrl = "http://images2.fanpop.com/images/photos/7500000/Legolas-the-elves-of-middle-earth-7510893-477-406.jpg",
                Title = "Isengard Tour Guid!",
                Trailer = "https://www.youtube.com/watch?v=uE-1RPDqJAY",
                Price = 100000,
                Year = 2016
            });

        }
    }
}