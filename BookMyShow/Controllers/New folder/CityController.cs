using BookMyShow.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMyShow.Models;

namespace BookMyShow.Controllers
{
    public class CityController : Controller
    {
        private IState staterepository;
        private ICity cityrepository;

        public CityController(IState state, ICity city)
        {
            this.staterepository = state;
            this.cityrepository = city;
        }

        // GET: City
        public ActionResult Index()
        {
            var list = cityrepository.GetAll().ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(staterepository.GetAll(), "StateId", "StateName");
            ViewBag.CityId = new SelectList(cityrepository.GetAll(), "CityId", "CityName"); 
            return View();
        }

        [HttpPost]
        public ActionResult Create(City city)
        {
            cityrepository.Create(city);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(City city, int id)
        {
            city = cityrepository.GetById(id);
            ViewBag.StateId = new SelectList(staterepository.GetAll(), "StateId", "StateName",city.StateId);
            ViewBag.CityId = new SelectList(cityrepository.GetAll(), "CityId", "CityName",city.CityId);
            return View(city);
        }

        [HttpPost]
        public ActionResult Edit(City city)
        {
            cityrepository.Update(city);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetCity(int stateid)
        {
            var jsonData = cityrepository.GetByStateId(stateid);
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}