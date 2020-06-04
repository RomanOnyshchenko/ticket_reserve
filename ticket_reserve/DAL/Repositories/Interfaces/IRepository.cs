using System;
using System.Collections.Generic;
using System.Text;
using ticket_reserve.DAL.Entities;
using ticket_reserve.DAL.Repositories.Interfaces;

namespace ticket_reserve.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate, int pageNumber = 0, int pageSize = 10);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
