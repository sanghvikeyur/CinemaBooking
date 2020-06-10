using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMyShow.Models.IRepository;

namespace BookMyShow.Models.Repository
{
    public class CityRepository : BMSDbRepository<City>, ICity
    {
        public CityRepository(BookMyShowDbContext context) : base(context)
        {

        }
        public override City GetById(int id)
        {

            IEnumerable<City> cities = context.Cities;
            City c = cities.FirstOrDefault(x => x.CityId == id);
            return c;
        }

        public override City GetByStateId(int id)
        {
            IEnumerable<City> cities = context.Cities;
            City c = cities.FirstOrDefault(x => x.StateId == id);
            return c;
        }
        
    }
}