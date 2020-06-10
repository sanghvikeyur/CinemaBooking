using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMyShow.Models.IRepository;

namespace BookMyShow.Models.Repository
{
    public class OrderRepository : BMSDbRepository<Order>, IOrder
    {

        public OrderRepository(BookMyShowDbContext context) : base(context)
        {

        }
    }
    }