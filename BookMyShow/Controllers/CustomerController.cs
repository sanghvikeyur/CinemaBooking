using BookMyShow.Models;
using BookMyShow.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookMyShow.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomer customerrepository;
        private IState staterepository;
        private ICity cityrepository;
        BookMyShowDbContext BookMyShowDbContext = new BookMyShowDbContext();

        public CustomerController(ICustomer customer,IState state, ICity city)
        {
            this.customerrepository = customer;
            this.staterepository = state;
            this.cityrepository = city;
        }

        // GET: Customer
        public ActionResult Index()
        {
            var list = customerrepository.GetAll().ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(staterepository.GetAll(), "StateId", "StateName");
            ViewBag.CityId = new SelectList(cityrepository.GetAll(), "CityId", "CityName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            customer.RoleID = 2;
            customerrepository.Create(customer);
            return RedirectToAction("Index", "Dashboard");
        }
        public ActionResult Edit(Customer customer, int id)
        {
            customer = customerrepository.GetById(id);
            ViewBag.StateId = new SelectList(staterepository.GetAll(), "StateId", "StateName", customer.StateId);
            ViewBag.CityId = new SelectList(cityrepository.GetAll(), "CityId", "CityName", customer.CityId);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            customerrepository.Update(customer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetCity(int stateid)
        {
            BookMyShowDbContext.Configuration.ProxyCreationEnabled = false;
            var jsonData = BookMyShowDbContext.Cities.Where(d => d.StateId == stateid);            
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}