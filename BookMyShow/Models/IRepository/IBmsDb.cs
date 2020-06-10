using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyShow.Models.IRepository
{
    public interface IBmsDb<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        T GetById(int id);
        T GetByStateId(int id);
        T GetShowByMovieId(int id);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count(Func<T, bool> predicate);
        bool Any(Func<T, bool> predicate);
        bool Any();
    }
}