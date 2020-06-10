using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BookMyShow.Models;
using BookMyShow.Models.IRepository;
using BookMyShow.Models.Repository;

namespace BookMyShow.Controllers
{
    public class LoginController : Controller
    {
        BookMyShowDbContext BookMyShowDbContext = new BookMyShowDbContext();
        // GET: Login
        //public ActionResult Index(string returnUrl)
        public ActionResult Index()
        {
            return View();
          }
        [HttpPost]
        //public ActionResult Index(Customer customer, string ReturnUrl)
        public ActionResult Index(Customer customer)
        {
            Session["IsAdmin"] = "No";
            var result1 = (from emp in BookMyShowDbContext.Customers where emp.Email == customer.Email && emp.Password == customer.Password select emp.Password).FirstOrDefault();

            string Password = (from emp in BookMyShowDbContext.Customers where emp.Email == customer.Email && emp.Password == customer.Password select emp.Password).FirstOrDefault();
            
            int RoleId = (from emp in BookMyShowDbContext.Customers where emp.Email == customer.Email && emp.Password == customer.Password select emp.RoleID).FirstOrDefault();
            string FirstName = (from emp in BookMyShowDbContext.Customers where emp.Email == customer.Email && emp.Password == customer.Password select emp.FirstName).FirstOrDefault();
            int CustomerId = (from emp in BookMyShowDbContext.Customers where emp.Email == customer.Email && emp.Password == customer.Password select emp.CustomerId).FirstOrDefault();
            if (Password == customer.Password)
            {
                FormsAuthentication.SetAuthCookie(customer.Email, false);
                Session["UserID"] = Guid.NewGuid();
                if (RoleId == 1)
                {
                    Session["IsAdmin"] = "Yes";                    
                }
                else
                {
                    Session["IsAdmin"] = "No";
                }
                Session["FirstName"] = FirstName;
                Session["CustomerId"] = CustomerId;                
                return RedirectToAction("Index", "Dashboard");
            }

            else
            {
                ViewBag.Message = string.Format("UserName or Password is incorrect");

                return View();
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session["UserID"] = null;
            Session["IsAdmin"] = "No";
            return RedirectToAction("Index", "Dashboard");
        }
    }
}