using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMyShow.Models;
using BookMyShow.Models.IRepository;

namespace BookMyShow.Controllers
{
    public class StateController : Controller
    {
        private IState staterepository;
        // GET: State

        public StateController(IState state, ICity city)
        {
            this.staterepository = state;
        }
        public ActionResult Index()
        {
            var list = staterepository.GetAll().ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(staterepository.GetAll(), "StateId", "StateName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(State state)
        {            
            staterepository.Create(state);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(State state,int id)
        {            
            state=staterepository.GetById(id);
            //ViewBag.StateId = new SelectList(staterepository.GetAll(), "StateId", "StateName");
            return View(state);
        }

        [HttpPost]
        public ActionResult Edit(State state)
        {
            staterepository.Update(state);
            return RedirectToAction("Index");
        }
    }
}