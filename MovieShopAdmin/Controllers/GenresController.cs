using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieShopBackend;
using MovieShopBackend.Contexts;
using MovieShopBackend.Entities;

namespace MovieShopAdmin.Controllers
{
    public class GenresController : Controller
    {
       
        private IManager<Genre> _manager = new ManagerFacade().GetGenreManager();
        
        // GET: Genres
        public ActionResult Index()
        {
            return View(_manager.ReadAll());
        }

        // GET: Genres/Details/5
        public ActionResult Details(int id)
        {
            
            Genre genre = _manager.ReadOne(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                _manager.Create(genre);                
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
            
            Genre genre = _manager.ReadOne(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                _manager.Update(genre);               
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            
            Genre genre = _manager.ReadOne(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre genre = _manager.ReadOne(id);
            _manager.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // _manager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
