using BookMyShow.Models;
using BookMyShow.Models.IRepository;
using BookMyShow.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookMyShow.Controllers
{
    public class DashboardController : Controller
    {
        private IMovie movierepository;
        private IShow showrepository;
        private IOrder orderrepository;
        BookMyShowDbContext BookMyShowDbContext = new BookMyShowDbContext();
        public DashboardController(IMovie movie,IShow show,IOrder order)
        {
            this.movierepository = movie;
            this.showrepository = show;
            this.orderrepository = order;
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            //Session["Seats"] = string.Empty;            
            Session["BookedSeats"] = string.Empty;
            var list = movierepository.GetAll().ToList();
            return View(list);
        }

        public ActionResult Details(Movie movie,int id)
        {
            movie = movierepository.GetById(id);
            return View(movie);
        }

        public ActionResult Book(Show show,int id)
        {
            var jsonData = BookMyShowDbContext.Shows.Where(d => d.MovieId == id).Where(d=> d.Status == "Active");
            return View(jsonData.ToList());
        }

        public ActionResult SelectSeat(Ticket ticket,int id)
        {
            Session["ShowDate"] = string.Empty;
            Session["ShowTime"] = string.Empty;
            Session["MovieName"] = string.Empty;
            Session["ShowId"] = id;
            var jsonData = BookMyShowDbContext.Tickets.Where(t => t.ShowId == id);
            ViewBag.ShowTime = BookMyShowDbContext.Shows.Where(t => t.ShowId == id).Select(t => t.ShowTime).Single();
            ViewBag.ShowDate = BookMyShowDbContext.Shows.Where(t => t.ShowId == id).Select(t => t.ShowDate).Single();
            int movieid= Convert.ToInt32(BookMyShowDbContext.Shows.Where(t => t.ShowId == id).Select(t => t.MovieId).Single());
            ViewBag.MovieName = BookMyShowDbContext.Movies.Where(t => t.MoviedId == movieid).Select(t => t.MovieName).Single();
            ViewBag.Genre = BookMyShowDbContext.Movies.Where(t => t.MoviedId == movieid).Select(t => t.Genre).Single();
            ViewBag.MovieIcon= BookMyShowDbContext.Movies.Where(t => t.MoviedId == movieid).Select(t => t.Icon).Single();
            Session["ShowDate"] = ViewBag.ShowDate.ToString("dd/MM/yyyy");
            Session["ShowTime"] = ViewBag.ShowTime.ToString();
            Session["MovieName"] = ViewBag.MovieName.ToString();
            return View(jsonData.ToList());
        }

        [AjaxAuthorize]
        [HttpPost]
        public ActionResult FinalBook(Show show,string[] Seat)
        {
            Session["SeatNumber"] = string.Empty;
            Session["TotalAmount"] = string.Empty;
            Seat = Seat.Where(c => c != string.Empty).ToArray();
            int count = 0;
            string seatnumber = string.Empty;            
            double totalamount = 0;
            
            count = Seat.Count();
            int showid = 0;
            showid = Convert.ToInt16(Session["ShowId"].ToString());
            List<string> bookingDetail = new List<string>();
            for (int i = 0; i < count; i++)
            {
                Order order = new Order();
                string tickettype = string.Empty;                
                Ticket ticket = new Ticket();
                tickettype = Seat[i].Substring(0, Seat[i].IndexOf(" "));
                var tt = BookMyShowDbContext.Tickets.Where(d => d.ShowId == showid).Where(d => d.TicketType == tickettype);
                var lst = tt.ToList();
                order.CustomerId = Convert.ToInt16(Session["CustomerId"].ToString());
                order.MovieId = lst.Select(d => d.MovieId).FirstOrDefault();
                order.ShowId = lst.Select(d => d.ShowId).FirstOrDefault();
                order.TicketId = lst.Select(d => d.TicketId).FirstOrDefault();
                order.TotalTickets = 1;
                order.TotalAmount = lst.Select(d => d.Price).FirstOrDefault();
                order.SeatNumber = Seat[i];

                seatnumber=string.Concat(seatnumber,' ', Seat[i]);                
                totalamount += lst.Select(d => d.Price).FirstOrDefault();
                
                orderrepository.Create(order);
            }
            Session["SeatNumber"] = seatnumber;
            Session["TotalAmount"] = totalamount.ToString();
            return Json(new { result = "Redirect", url = Url.Action("DisplayTicket", "Dashboard") });            
        }

        public ActionResult GetBookedSeat()
        {
            int showid = Convert.ToInt32(Session["ShowId"].ToString());
            var getSeat = BookMyShowDbContext.Orders.Where(d => d.ShowId == showid);
            List<string> Seat = new List<string>();
            foreach (var item in getSeat)
            {
                Seat.Add(item.SeatNumber);
            }
            return Json(Seat, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayTicket()
        {
            return View();
        }
    }
}