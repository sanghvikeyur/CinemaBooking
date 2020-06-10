using BookMyShow.Models;
using BookMyShow.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookMyShow.Controllers
{
    public class ShowController : Controller
    {
        private IShow showrepository;
        private IMovie movierepository;
        public ShowController(IShow show, IMovie movie)
        {
            this.showrepository = show;
            this.movierepository = movie;
        }
        // GET: Show
        public ActionResult Index()
        {
            var list = showrepository.GetAll().ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(movierepository.GetAll(), "MoviedId", "MovieName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Show show)
        {
            showrepository.Create(show);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Show show, int id)
        {
            show = showrepository.GetById(id);
            ViewBag.MovieId = new SelectList(movierepository.GetAll(), "MoviedId", "MovieName", show.MovieId);
            return View(show);
         }

        [HttpPost]
        public ActionResult Edit(Show show)
        {
            showrepository.Update(show);
            return RedirectToAction("Index");
        }
    }   
}