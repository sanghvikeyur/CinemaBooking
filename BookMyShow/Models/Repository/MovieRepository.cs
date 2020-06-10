using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMyShow.Models.IRepository;

namespace BookMyShow.Models.Repository
{
    public class MovieRepository : BMSDbRepository<Movie>, IMovie
    {

        public MovieRepository(BookMyShowDbContext context) : base(context)
        {

        }
    }
    }