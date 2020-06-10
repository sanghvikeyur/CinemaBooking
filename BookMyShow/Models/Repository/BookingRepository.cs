using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMyShow.Models.IRepository;

namespace BookMyShow.Models.Repository
{
    public class BookingRepository : BMSDbRepository<Booking>, IBooking
    {

        public BookingRepository(BookMyShowDbContext context) : base(context)
        {

        }
    }
    }