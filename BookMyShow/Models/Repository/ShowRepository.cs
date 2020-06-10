using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMyShow.Models.IRepository;

namespace BookMyShow.Models.Repository
{
    public class ShowRepository : BMSDbRepository<Show>, IShow
    {

        public ShowRepository(BookMyShowDbContext context) : base(context)
        {

        }
        public override Show GetShowByMovieId(int id)
        {
            IEnumerable<Show> shows = context.Shows;
            Show s = shows.FirstOrDefault(x => x.MovieId == id);
            return s;
        }
    }
    }