using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMyShow.Models.IRepository;

namespace BookMyShow.Models.Repository
{
    public class StateRepository : BMSDbRepository<State>, IState
    {

        public StateRepository(BookMyShowDbContext context) : base(context)
        {
               
        }
        public override State GetById(int id)
        {
            IEnumerable<State> states = context.States;
            State s = states.FirstOrDefault(x => x.StateId == id);
            return s;
        }

    }
}