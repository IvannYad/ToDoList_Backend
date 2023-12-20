using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL.Entity;

namespace ToDoList.DAL.Repository.Interfaces
{
    public interface IToDoTaskRepository : IRepository<ToDoTask>
    {
        void Save();
    }
}
