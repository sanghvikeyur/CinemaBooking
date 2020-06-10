using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMyShow.Models.IRepository;

namespace BookMyShow.Models.Repository
{
    public class CustomerRepository : BMSDbRepository<Customer>, ICustomer
    {

        public CustomerRepository(BookMyShowDbContext context) : base(context)
        {

        }
    }
    }