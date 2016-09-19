using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopBackend.Entities;
using MovieShopBackend.Managers;

namespace MovieShopBackend
{
    public class ManagerFacade
    {
        public IManager<Genre> GetGenreManager()
        {
            return new GenreManager();
        }

    }
}
