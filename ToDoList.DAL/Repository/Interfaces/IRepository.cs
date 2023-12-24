using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DAL.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T>? GetAll(Expression<Func<T, bool>>? filter = null);
        T? Get(Expression<Func<T, bool>> selector, bool tracked = true);
        void Add(T item);
        void Update(T item);
        void Remove(T item);
    }
}
