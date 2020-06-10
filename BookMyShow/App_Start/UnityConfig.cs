using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using BookMyShow.Models.IRepository;
using BookMyShow.Models.Repository;
namespace BookMyShow
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
                        
            container.RegisterType<ICity, CityRepository>();
            container.RegisterType<ICustomer, CustomerRepository>();
            container.RegisterType<IMovie, MovieRepository>();
            container.RegisterType<IOrder, OrderRepository>();
            container.RegisterType<IShow, ShowRepository>();
            container.RegisterType<IState, StateRepository>();
            container.RegisterType<ITicket, TicketRepository>();
            container.RegisterType<IBooking, BookingRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}