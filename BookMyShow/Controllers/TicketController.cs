using BookMyShow.Models;
using BookMyShow.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookMyShow.Controllers
{
    public class TicketController : Controller
    {
        private ITicket ticketrepository;
        private IShow showrepository;
        private IMovie movierepository;
        BookMyShowDbContext BookMyShowDbContext = new BookMyShowDbContext();
        public TicketController(ITicket ticket, IShow show, IMovie movie)
        {
            this.ticketrepository = ticket;
            this.showrepository = show;
            this.movierepository = movie;
        }

        // GET: Ticket
        public ActionResult Index()
        {
            var list = ticketrepository.GetAll().ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            ViewBag.ShowId = new SelectList(showrepository.GetAll(), "ShowId", "ShowTime");
            ViewBag.MovieId = new SelectList(movierepository.GetAll(), "MoviedId", "MovieName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            ticketrepository.Create(ticket);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Ticket ticket, int id)
        {
            ticket = ticketrepository.GetById(id);
            ViewBag.MovieId = new SelectList(movierepository.GetAll(), "MoviedId", "MovieName", ticket.MovieId);
            ViewBag.ShowId = new SelectList(showrepository.GetAll(), "ShowId", "ShowTime", ticket.ShowId);
            return View(ticket);
        }

        [HttpPost]
        public ActionResult Edit(Ticket ticket)
        {
            ticketrepository.Update(ticket);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetMovieShow(int movieid)
        {
            BookMyShowDbContext.Configuration.ProxyCreationEnabled = false;
            var jsonData = BookMyShowDbContext.Shows.Where(d => d.MovieId == movieid);
            var jsonList = new List<object>();
            foreach (var data in jsonData)
            {
                jsonList.Add(new getShow() { Movieid = data.MovieId, ShowId = data.ShowId, Status=data.Status="Active", ShowTime = data.ShowTime.ToString() });
            }
            return Json(jsonList, JsonRequestBehavior.AllowGet);
        }


    }
    public class getShow {
        public int Movieid { get; set; }
        public int ShowId { get; set; }
        public string ShowTime { get; set; }

        public string Status { get; set; }
    }
        
}