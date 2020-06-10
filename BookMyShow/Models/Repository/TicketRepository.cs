using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMyShow.Models.IRepository;

namespace BookMyShow.Models.Repository
{
    public class TicketRepository : BMSDbRepository<Ticket>, ITicket
    {

        public TicketRepository(BookMyShowDbContext context) : base(context)
        {

        }
    }
    }