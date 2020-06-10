using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMyShow.Models.IRepository;
using System.Data.Entity;
namespace BookMyShow.Models.Repository
{
    public class StudentResposity : BMSDbRepository<Customer>, ICustomer
    {

        public StudentResposity(BookMyShowDbContext context) : base(context)
        {

        }
        public override IEnumerable<Customer> GetAll()
        {
            return context.Customers.Include(d => d.State).Include(d => d.City).ToList();
            //return base.GetAll();
        }
    }
}