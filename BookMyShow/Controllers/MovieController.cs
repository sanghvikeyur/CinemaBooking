using BookMyShow.Models;
using BookMyShow.Models.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookMyShow.Controllers
{
    public class MovieController : Controller
    {
        private IMovie movierepository;
        BookMyShowDbContext BookMyShowDbContext = new BookMyShowDbContext();
        public MovieController(IMovie movie)
        {
            this.movierepository = movie;
        }

        // GET: Movie
        public ActionResult Index()
        {
            var list = movierepository.GetAll().ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            string filename = Path.GetFileNameWithoutExtension(movie.MovieIcon.FileName);
            string extension = Path.GetExtension(movie.MovieIcon.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            movie.Icon = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            movie.MovieIcon.SaveAs(filename);
            movierepository.Create(movie);
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Movie movie, int id)
        {
            movie = movierepository.GetById(id);
            
            ViewBag.MovieId = new SelectList(movierepository.GetAll(), "MoviedId", "MovieName", movie.MoviedId);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            string filename = Path.GetFileNameWithoutExtension(movie.MovieIcon.FileName);
            string extension = Path.GetExtension(movie.MovieIcon.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            movie.Icon = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            movie.MovieIcon.SaveAs(filename);
            movierepository.Update(movie);
            return RedirectToAction("Index");
        }

        public ActionResult BookTickets(int id)
        {
            var routeValues = new RouteValueDictionary {
                { "id",id} };
            return RedirectToAction("Index","Ticket");
        }

        [AcceptVerbs(HttpVerbs.Post)]
	    public JsonResult PostRating(int rating, int mid)
	    {
	        StarRatings rt = new StarRatings();
	        rt.Rate = rating;
	        rt.MovieId = mid;

            BookMyShowDbContext.StarRatings.Add(rt);
	        BookMyShowDbContext.SaveChanges();

	        return Json("You rated this " + rating.ToString() + " star(s)");
	    }
}
}